using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Interfaces;
using Bridge.Application.Interfaces;
using Bridge.Application.Models;
using Bridge.Domain.Entities;
using Google.Cloud.Storage.V1;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;

namespace Application.Courses.Queries.GetAllCoursesDetail
{
    public class GetAllCoursesDetailQueryHandler : IRequestHandler<GetAllCoursesDetailQuery, ApiResponse>
    {

        private readonly IBridgeDbContext _dbContext;
        private readonly IHostingEnvironment _env;
        private readonly ICurrentUserService _userService;
        private readonly IUserHelper _userHelper;
        public GetAllCoursesDetailQueryHandler(IBridgeDbContext dbContext, ICurrentUserService userService, IUserHelper userHelper, IHostingEnvironment env)
        {
            _dbContext = dbContext;
            _env = env;
            _userService = userService;
            _userHelper = userHelper;
        }
        public async Task<ApiResponse> Handle(GetAllCoursesDetailQuery request, CancellationToken cancellationToken)
        {
            ApiResponse res = new ApiResponse();
            try
            {
                // var userId = await _userHelper.getUserId(_userService.UserId.ToString());
                 var userId = _userService.UserId;

                if (request.Search == null)
                {
                    res.response_code = 1;
                    res.message = "No data found";
                    res.status = "Success";
                }
                string Certificate = Path.GetFileName ("../../training24-28e994f9833c.json");    //xxx
                string[] filterArray = null;
                string[] gradeArray = null;
                if (!string.IsNullOrEmpty(request.Filter))
                {
                    filterArray = request.Filter.Split(",");
                }
                if (!string.IsNullOrEmpty(request.ByGrade))
                {
                    gradeArray = request.ByGrade.Split(",");
                }
                GetAllCoursesDetailVm getAllDetailsModel = new GetAllCoursesDetailVm();
                List<CourseDetailModel> courseList = new List<CourseDetailModel>();
                List<LessonDetailModel> responseLessonModel = new List<LessonDetailModel>();

                var studentCoursesList = await _dbContext.UserCourse.Where(s => s.UserId == int.Parse(userId)).ToListAsync();
                var coursesList = await _dbContext.Course.Where(x => studentCoursesList.Select(y => y.CourseId).Contains(x.Id)).ToListAsync();
                if (studentCoursesList.Any())
                {
                    foreach (var usercourse in studentCoursesList)
                    {
                        Course course = new Course();
                        List<ResponseGradeModel> gradeModels = await GetGradeByCourseId(usercourse.CourseId);
                        course = coursesList.FirstOrDefault(x => x.Id == usercourse.CourseId);

                        if (course != null)
                        {
                            string imageurl = "";
                            if (!string.IsNullOrEmpty(course.Image))
                            {
                                if (course.Image.Contains("t24-primary-image-storage"))
                                    imageurl = course.Image;
                                else
                                    imageurl =  _userHelper.getUrl(course.Image, Certificate);
                            }

                            CourseDetailModel responseCourseModel = new CourseDetailModel
                            {
                                Name = course.Name,
                                Id = int.Parse(course.Id.ToString()),
                                Image = imageurl,
                                StartDate = usercourse.StartDate,
                                EndDate = usercourse.EndDate,
                                GradeDetails = gradeModels,
                                Description = course.Description
                            };
                            courseList.Add(responseCourseModel);

                            List<Lesson> newLesson = await GetLessonByCourseId(int.Parse(usercourse.CourseId.ToString()));
                            foreach (var lesson in newLesson)
                            {
                                ResponseFilesModel lessonfile = await GetLessionFilesByLessionId1(lesson.Id);

                                var quiz = await _dbContext.chapterQuiz.Where(b => b.ChapterId == lesson.ChapterId.Value).ToListAsync();

                                try
                                {
                                    var lessons = await GetStudentLessonProgressByLession(lesson.Id);

                                    LessonDetailModel rlModel = new LessonDetailModel
                                    {
                                        id = int.Parse(lesson.Id.ToString()),
                                        name = lesson.Title,
                                        chapterid = lesson.ChapterId.Value,
                                        courseid = usercourse.CourseId,
                                        coursename = course.Name,
                                        lessonfileid = lessonfile.Id,
                                        lessonfilename = lessonfile.name,
                                        filetypeid = lessonfile.filetypeid,
                                        filetypename = lessonfile.filetypename,
                                        progressval = lessons.lessonprogress,
                                        lessonquizid = 0
                                    };
                                    responseLessonModel.Add(rlModel);

                                    if (quiz.Count != 0)
                                    {
                                        var lessonsProgress = await GetStudentLessonProgressByLession(lesson.Id);
                                        rlModel = new LessonDetailModel
                                        {
                                            id = int.Parse(lesson.Id.ToString()),
                                            name = lesson.Title,
                                            chapterid = lesson.ChapterId.Value,
                                            courseid = usercourse.CourseId,
                                            coursename = course.Name,
                                            lessonfileid = 0,
                                            lessonfilename = "",
                                            filetypeid = 0,
                                            filetypename = "",
                                            progressval = lessonsProgress.lessonprogress,
                                            lessonquizid = quiz[0].QuizId
                                        };
                                        responseLessonModel.Add(rlModel);
                                    }
                                }
                                catch (Exception ex)
                                {

                                    throw ex;
                                }

                            }
                        }

                        List<Assignment> assignmentList = await GetAssignmentStudentById(int.Parse(userId));
                        List<AssignmentDetails> responseAssignmentModels = new List<AssignmentDetails>();

                        foreach (var assignemnt in assignmentList)
                        {
                            AssignmentDetails responseAssignmentModel = new AssignmentDetails();
                            responseAssignmentModel.id = int.Parse(assignemnt.Id.ToString());
                            responseAssignmentModel.name = assignemnt.Name;

                            Assignment assignment = await _dbContext.Assignment.FirstOrDefaultAsync(x => x.Id == assignemnt.Id);
                            Chapter chapter = await _dbContext.Chapter.FirstOrDefaultAsync(x => x.Id == assignment.ChapterId);

                            Course newCourse = await _dbContext.Course.Where(b => b.Id == chapter.CourseId).SingleOrDefaultAsync();
                            List<ResponseGradeModel> gradeModel = await GetGradeByCourseId(chapter.CourseId);
                            CourseDetailModel responseCourseModel = new CourseDetailModel
                            {
                                Name = newCourse.Name,
                                Id = int.Parse(newCourse.Id.ToString()),
                                Image = newCourse.Image,
                                GradeDetails = gradeModel
                            };

                            responseAssignmentModel.coursewithgrade = responseCourseModel;
                            responseAssignmentModels.Add(responseAssignmentModel);
                        }

                        if (!string.IsNullOrEmpty(request.Search))
                        {
                            List<CourseDetailModel> tempCourseDetails = new List<CourseDetailModel>();
                            List<CourseDetailModel> courseDetailModels1 = new List<CourseDetailModel>();
                            List<CourseDetailModel> courseDetailModels2 = new List<CourseDetailModel>();
                            tempCourseDetails.AddRange(courseList);
                            courseList.Clear();
                            try
                            {
                                courseDetailModels1 = tempCourseDetails.Where(b => b.Name.ToLower().Contains(request.Search.ToLower()) ||
                                !string.IsNullOrEmpty(b.Description) && b.Description.ToLower().Contains(request.Search.ToLower())).ToList();
                                if (courseDetailModels1.Count != 0)
                                {
                                    courseList.AddRange(courseDetailModels1);
                                }
                                responseAssignmentModels = responseAssignmentModels.Where(b => b.name.Any(k => b.name.ToLower().Contains(request.Search.ToLower()))).ToList();
                                responseLessonModel = responseLessonModel.Where(b => b.name.Any(k => b.name.ToLower().Contains(request.Search.ToLower()))).ToList();
                            }
                            catch (Exception ex)
                            {
                                throw ex;
                            }
                        }

                        if (request.Filter != null)
                        {
                            List<CourseDetailModel> tempCourseList = new List<CourseDetailModel>();
                            if (request.Filter.Contains("1"))
                            {
                                foreach (var nc in courseList)
                                {
                                    if (!string.IsNullOrEmpty(nc.StartDate))
                                    {
                                        DateTime parsedDate = DateTime.ParseExact(nc.StartDate, "M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture);
                                        if (parsedDate >= DateTime.Now.Date.AddDays(-5))
                                        {
                                            tempCourseList.Add(nc);
                                        }
                                    }
                                }
                            }
                            if (request.Filter.Contains("2"))
                            {
                                foreach (var nc in courseList)
                                {
                                    if (!string.IsNullOrEmpty(nc.StartDate))
                                    {
                                        DateTime parsedDateStart = DateTime.ParseExact(nc.StartDate, "M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture);
                                        DateTime parsedDateEnd = DateTime.ParseExact(nc.EndDate, "M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture);
                                        if (parsedDateStart >= DateTime.Now && parsedDateEnd <= DateTime.Now)
                                        {
                                            tempCourseList.Add(nc);
                                        }
                                    }
                                }
                            }
                            if (request.Filter.Contains("3"))
                            {
                                foreach (var nc in courseList)
                                {
                                    if (!string.IsNullOrEmpty(nc.EndDate))
                                    {
                                        DateTime parsedDateEnd = DateTime.ParseExact(nc.EndDate, "M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture);
                                        if (parsedDateEnd <= DateTime.Now)
                                        {
                                            tempCourseList.Add(nc);
                                        }
                                    }
                                }
                            }
                            if (request.Filter.Contains("4"))
                            {

                            }
                            tempCourseList = tempCourseList.Distinct().ToList();
                            courseList = tempCourseList;
                            responseLessonModel = null;
                            responseAssignmentModels = null;
                        }
                        if (request.ByGrade != null)
                        {
                            List<CourseDetailModel> tempCourseList = new List<CourseDetailModel>();
                            foreach (var nc in courseList)
                            {
                                List<ResponseGradeModel> gradeModel = await GetGradeByCourseId(nc.Id);
                                foreach (var gm in gradeModel)
                                {
                                    for (int i = 0; i < request.ByGrade.Length; i++)
                                    {
                                        if (gm.id == Convert.ToInt32(request.ByGrade[i]))
                                        {
                                            tempCourseList.Add(nc);
                                        }
                                    }
                                }
                            }
                            tempCourseList = tempCourseList.Distinct().ToList();
                            courseList = tempCourseList;
                            responseLessonModel = null;
                            responseAssignmentModels = null;
                        }

                        getAllDetailsModel.courses = courseList;
                        getAllDetailsModel.lessons = responseLessonModel;
                        getAllDetailsModel.assignment = responseAssignmentModels;


                        res.data = getAllDetailsModel;
                        res.response_code = 0;
                        res.message = "GetAllDetails";
                        res.status = "Success";
                        res.ReturnCode = 200;
                    }
                }

            }
            catch (Exception ex)
            {
                res.ReturnCode = 500;
                res.response_code = 2;
                res.message = ex.Message;
                res.status = "Failure";
            }
            return res;
        }

        public async Task<List<ResponseGradeModel>> GetGradeByCourseId(long id)
        {
            List<CourseGrade> courseGrades = _dbContext.CourseGrade.Where(b => b.CourseId == id).ToList();

            List<ResponseGradeModel> gradedt = new List<ResponseGradeModel>();

            foreach (var cgrd in courseGrades)
            {
                Grade newGrade = await _dbContext.Grade.FirstOrDefaultAsync(x => x.Id == cgrd.Gradeid);

                if (newGrade != null)
                {
                    ResponseGradeModel responseGradeModel = new ResponseGradeModel
                    {
                        id = newGrade.Id,
                        name = newGrade.Name,
                        description = newGrade.Description
                    };
                    gradedt.Add(responseGradeModel);
                }
            }

            return gradedt;
        }

        public async Task<List<Lesson>> GetLessonByCourseId(int id)
        {
            List<Chapter> chapters = await _dbContext.Chapter.Where(b => b.CourseId == id).ToListAsync();

            List<Lesson> lessonsList = new List<Lesson>();
            foreach (var chapter in chapters)
            {
                List<Lesson> lessons = await _dbContext.Lesson.Where(b => b.ChapterId == chapter.Id).ToListAsync();
                lessonsList.AddRange(lessons);
            }

            return lessonsList;
        }

        public async Task<ResponseFilesModel> GetLessionFilesByLessionId1(long Id)
        {
            List<LessonFile> lessonFiles = await _dbContext.LessonFile.Where(x => x.LessionId == Id).ToListAsync();
            var lessonfile = lessonFiles.OrderByDescending(b => b.Id).First();
            ResponseFilesModel responseLessonFileModel = new ResponseFilesModel();
            Files newFiles = await getFilesById(lessonfile.FileId);
            var filetyped = await FileType(newFiles);
            responseLessonFileModel.Id = newFiles.Id;
            responseLessonFileModel.name = newFiles.Name;
            responseLessonFileModel.filetypeid = newFiles.FileTypeId;
            responseLessonFileModel.filetypename = filetyped.Filetype;
            return responseLessonFileModel;
        }

        public async Task<Files> getFilesById(long id)
        {
            return await _dbContext.Files.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<FileTypes> FileType(Files files)
        {
            var roleData = new FileTypes();
            try
            {
                roleData = await _dbContext.FileTypes.FirstOrDefaultAsync(b => b.Id == files.FileTypeId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return roleData;
        }

        public async Task<ResponseStudentLessonProgressModel> GetStudentLessonProgressByLession(long id)
        {
            StudentLessonProgress studentLessonProgress = await _dbContext.StudentLessonProgress.Where(b => b.LessonId == id).SingleOrDefaultAsync();
            ResponseStudentLessonProgressModel responseStudentLessonProgressModel = new ResponseStudentLessonProgressModel();
            if (studentLessonProgress != null)
            {
                responseStudentLessonProgressModel = new ResponseStudentLessonProgressModel
                {
                    id = studentLessonProgress.Id,
                    lessonid = studentLessonProgress.LessonId,
                    lessonstatus = studentLessonProgress.LessonStatus,
                    studentid = studentLessonProgress.StudentId,
                    lessonprogress = studentLessonProgress.LessonProgress
                };
            }
            return responseStudentLessonProgressModel;
        }

        public async Task<List<Assignment>> GetAssignmentStudentById(int id)
        {
            List<Assignment> assignments = new List<Assignment>();
            List<AssignmentStudent> assignmentStudents = await _dbContext.AssignmentStudent.Where(b => b.StudentId == id).ToListAsync();

            foreach (var assignment in assignmentStudents)
            {
                Assignment assignmentd = await _dbContext.Assignment.FirstOrDefaultAsync(x => x.Id == assignment.AssignmentId);
                assignments.Add(assignmentd);
            }

            return assignments;
        }
    }


}