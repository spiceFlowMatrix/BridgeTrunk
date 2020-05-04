using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Helpers;
using Application.Interfaces;
using Bridge.Application.Interfaces;
using Bridge.Application.Models;
using Bridge.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Courses.Queries.GetCoursePreviewById {
    public class GetCoursePreviewByIdQueryHandler : IRequestHandler<GetCoursePreviewByIdQuery, ApiResponse> {
        private readonly IBridgeDbContext _dbContext;
        private readonly ICurrentUserService _userService;
        private readonly IUserHelper _userHelper;
        public GetCoursePreviewByIdQueryHandler (IBridgeDbContext dbContext, ICurrentUserService userService, IUserHelper userHelper) {
            _dbContext = dbContext;
            _userService = userService;
            _userHelper = userHelper;
        }

        public async Task<ApiResponse> Handle (GetCoursePreviewByIdQuery request, CancellationToken cancellationToken) {
            ApiResponse res = new ApiResponse ();
            try {
                // if (_userService.RoleList.Contains (Roles.admin.ToString ())||
                // _userService.RoleList.Contains (Roles.teacher.ToString ())||
                // _userService.RoleList.Contains (Roles.student.ToString ())) {
                string certificate = Path.GetFileName ("../../training24-28e994f9833c.json");
                // if (request.StudentId == 0)
                // {
                //     var coursePreview = await (from c in _dbContext.Course
                //     .Where(x=>x.Id==request.Id && x.IsDeleted == false)
                //     select new CoursePreviewVm {
                //         Id= c.Id,
                //         Code=c.Code,
                //         Description=c.Description,
                //         //Image =
                //         Name=c.Name,
                //         chapters = (from ch in _dbContext.Chapter
                //         .Where(x=>x.CourseId == c.Id && x.IsDeleted==false)
                //         select new ChapterPreviewModel{
                //               Id = ch.Id,
                //               Code = ch.Code,
                //               Name = ch.Name,
                //               itemorder = ch.ItemOrder,
                //               //quizs = ,
                //               assignments = (from a in _dbContext.Assignment
                //               .Where(x=>x.ChapterId==ch.Id && x.IsDeleted == false)
                //               select new AssignmentPreviewModel{
                //                                   id = a.Id,
                //                                   name = a.Name,
                //                                   code = a.Code,
                //                                   description = a.Description,
                //                                   itemorder = a.ItemOrder,
                //                                   type = 3
                //               }).OrderBy(x=>x.itemorder).ToList(),
                //               lessons = (from l in _dbContext.lesson
                //               .Where(x=>x.IsDeleted == false && x.ChapterId == ch.Id)
                //               select new {
                //                              id = l.Id,
                //                               name = l.Name,
                //                               code = l.Code,
                //                               description = l.Description,
                //                               itemorder = l.ItemOrder,
                //                               type = 1
                //               }
                //               ).ToList()
                //         }).ToList(),

                //     }).FirstOrDefaultAsync();
                // }
                // if (request.StudentId == 0) {
                CoursePreviewVm coursePreview = new CoursePreviewVm ();
                var course = await _dbContext.Course.FirstOrDefaultAsync (x => x.Id == request.Id);
                if (course != null) {
                    coursePreview.Id = course.Id;
                    coursePreview.Code = course.Code;
                    coursePreview.Description = course.Description;
                    if (!string.IsNullOrEmpty (course.Image)) {
                        if (course.Image.Contains ("t24-primary-image-storage"))
                            coursePreview.Image = course.Image;
                        else
                            coursePreview.Image = _userHelper.getUrl (course.Image, certificate);
                    }
                    coursePreview.Name = course.Name;
                    var chapters = await _dbContext.Chapter.Where (x => x.CourseId == course.Id &&
                        x.IsDeleted == false
                    ).ToListAsync ();
                    List<ChapterPreviewModel> chapterPM = new List<ChapterPreviewModel> ();
                    foreach (var item in chapters) {
                        ChapterPreviewModel obj = new ChapterPreviewModel ();
                        obj.Id = item.Id;
                        obj.Code = item.Code;
                        obj.Name = item.Name;
                        obj.itemorder = item.ItemOrder;
                        var quizList = await _dbContext.chapterQuiz.Where (x => x.ChapterId == item.Id &&
                            x.IsDeleted == false
                        ).ToListAsync ();
                        List<QuizPreviewModel> quizPreviewModel = new List<QuizPreviewModel> ();
                        if (quizList != null) {
                            foreach (var data in quizList) {
                                var quiz = await _dbContext.Quiz.FirstOrDefaultAsync (x => x.Id == data.QuizId);
                                if (quiz != null) {
                                    if (request.StudentId == 0) {
                                    QuizPreviewModel qpm = new QuizPreviewModel () {
                                    id = quiz.Id,
                                    name = quiz.Name,
                                    code = quiz.Code,
                                    numquestions = quiz.NumQuestions,
                                    itemorder = data.ItemOrder,
                                    type = 2
                                        };
                                        quizPreviewModel.Add (qpm);
                                    } else {
                                        QuizPreviewModel qpm = new QuizPreviewModel () {
                                            id = quiz.Id,
                                            name = quiz.Name,
                                            code = quiz.Code,
                                            numquestions = quiz.NumQuestions,
                                            itemorder = data.ItemOrder,
                                        };
                                        quizPreviewModel.Add (qpm);
                                    }
                                }
                            }
                            quizPreviewModel = quizPreviewModel.OrderBy (x => x.itemorder).ToList ();
                        } else {
                            obj.quizs = null;
                        }
                        var assignments = await _dbContext.Assignment.Where (x => x.ChapterId == item.Id &&
                            x.IsDeleted == false
                        ).ToListAsync ();
                        List<AssignmentPreviewModel> assignmentPreviewModel = new List<AssignmentPreviewModel> ();
                        if (assignments != null) {
                            if (request.StudentId == 0) {
                                assignmentPreviewModel = assignments.Select (x => new AssignmentPreviewModel {
                                    id = x.Id,
                                        name = x.Name,
                                        code = x.Code,
                                        description = x.Description,
                                        itemorder = x.ItemOrder,
                                        type = 3
                                }).OrderBy (x => x.itemorder).ToList ();
                            } else {
                                assignmentPreviewModel = assignments.Select (x => new AssignmentPreviewModel {
                                    id = x.Id,
                                        name = x.Name,
                                        code = x.Code,
                                        description = x.Description,
                                        assignmentfiles = GetAssignmentFilesByAssignmentId (x.Id, certificate)
                                }).OrderBy (x => x.itemorder).ToList ();
                                obj.assignments = assignmentPreviewModel;
                            }
                        } else {
                            obj.assignments = null;
                        }
                        var lessons = await _dbContext.Lesson.Where (x => x.ChapterId == item.Id &&
                            x.IsDeleted == false
                        ).ToListAsync ();
                        List<LessonPreviewModel> lessonPreviewModel = new List<LessonPreviewModel> ();
                        if (request.StudentId == 0) {
                            if (lessons.Count != 0) {
                                lessonPreviewModel = lessons.Select (x => new LessonPreviewModel {
                                    id = x.Id,
                                        name = x.Title,
                                        description = x.Description,
                                        itemorder = x.ItemOrder,
                                        type = 1
                                }).OrderBy (x => x.itemorder).ToList ();
                                List<object> listObj = lessonPreviewModel.Cast<object> ().ToList ();
                                if (quizPreviewModel.Count != 0)
                                    listObj.AddRange (quizPreviewModel);
                                if (assignmentPreviewModel.Count != 0)
                                    listObj.AddRange (assignmentPreviewModel);
                                obj.lessons = listObj;
                            } else {
                                List<object> listObj = lessonPreviewModel.Cast<object> ().ToList ();
                                if (quizPreviewModel.Count != 0)
                                    listObj.AddRange (quizPreviewModel);
                                if (assignmentPreviewModel.Count != 0)
                                    listObj.AddRange (assignmentPreviewModel);
                                obj.lessons = listObj;
                            }
                        } else {
                            if (lessons.Count != 0) {
                                try {
                                    lessonPreviewModel = lessons.Select (x => new LessonPreviewModel {
                                        id = x.Id,
                                            name = x.Title,
                                            description = x.Description,
                                            itemorder = x.ItemOrder,
                                            lessonfiles = GetLessionFilesByLessionId (x.Id, request.StudentId, certificate),
                                            assignment = _dbContext.LessonAssignments.Where (x => x.LessonId == x.Id &&
                                                x.IsDeleted == false
                                            ).Select (x => new ResponseLessionAssignmentDTO {
                                                id = Convert.ToInt32 (x.Id),
                                                    name = x.Name,
                                                    code = x.Code,
                                                    description = x.Description,
                                                    assignmentfiles = GetLessonAssignmentFilesByAssignmentId (x.Id, certificate)
                                            }).FirstOrDefault ()
                                    }).OrderBy (x => x.itemorder).ToList ();
                                } catch (Exception ex) {
                                    Console.WriteLine (ex.Message);
                                }
                                List<object> listObj = lessonPreviewModel.Cast<object> ().ToList ();
                                if (quizPreviewModel.Count != 0)
                                    listObj.AddRange (quizPreviewModel);
                                obj.lessons = listObj;
                            } else {
                                List<object> listObj = lessonPreviewModel.Cast<object> ().ToList ();
                                if (quizPreviewModel.Count != 0)
                                    listObj.AddRange (quizPreviewModel);
                                obj.lessons = listObj;

                            }

                        }
                        chapterPM.Add (obj);
                    }
                    chapterPM = chapterPM.OrderBy (x => x.itemorder).ToList ();
                    coursePreview.chapters = chapterPM;
                    res.data = coursePreview;
                    res.response_code = 0;
                    res.message = "Course detail";
                    res.status = "Success";
                    res.ReturnCode = 200;
                } else {
                    res.response_code = 1;
                    res.message = "Course not found";
                    res.status = "Success";
                    res.ReturnCode = 404;
                }
                // }
                // } else {
                //     res.response_code = 1;
                //     res.message = "You are not authorized";
                //     res.status = "Unsuccess";
                //     res.ReturnCode = 401;
                // }
            } catch (Exception ex) {
                res.ReturnCode = 500;
                res.response_code = 2;
                res.message = ex.Message;
                res.status = "Failure";
            }
            return res;
        }

        public List<ResponseLessonAssignmentFileDTO> GetLessonAssignmentFilesByAssignmentId (long Id, string Certificate) {
            List<LessonAssignmentFile> AssignmentFiles = _dbContext.LessonAssignmentFiles.Where (x => x.AssignmentId == Id &&
                x.IsDeleted == false
            ).ToList ();
            List<ResponseLessonAssignmentFileDTO> AssignmentFileList = new List<ResponseLessonAssignmentFileDTO> ();
            List<ResponseFilesModel> responseFilesModelList = new List<ResponseFilesModel> ();
            foreach (var AssignmentFile in AssignmentFiles) {
                ResponseLessonAssignmentFileDTO responseAssignmentFileModel = new ResponseLessonAssignmentFileDTO ();
                Files newFiles = _dbContext.Files.FirstOrDefault (x => x.Id == AssignmentFile.FileId &&
                    x.IsDeleted == false
                );
                if (newFiles != null) {
                    ResponseFilesModel responseFilesModel = new ResponseFilesModel ();
                    var filetyped = _dbContext.FileTypes.FirstOrDefault (x => x.Id == newFiles.Id);
                    responseFilesModel.Id = newFiles.Id;
                    responseFilesModel.name = newFiles.Name;
                    responseFilesModel.filename = newFiles.FileName;
                    responseFilesModel.filetypeid = newFiles.FileTypeId;
                    responseFilesModel.url = _userHelper.getUrl (newFiles.Url, Certificate);
                    responseFilesModel.description = newFiles.Description;
                    responseFilesModel.filetypename = filetyped.Filetype;
                    responseFilesModel.filesize = newFiles.FileSize;
                    responseAssignmentFileModel.id = AssignmentFile.Id;
                    responseAssignmentFileModel.files = responseFilesModel;
                    AssignmentFileList.Add (responseAssignmentFileModel);
                }
            }
            return AssignmentFileList;
        }
        public List<ResponseAssignmentFileModel> GetAssignmentFilesByAssignmentId (long Id, string Certificate) {
            var AssignmentFiles = _dbContext.AssignmentFile.Where (x => x.AssignmentId == Id &&
                x.IsDeleted == false
            ).ToList ();
            List<ResponseAssignmentFileModel> AssignmentFileList = new List<ResponseAssignmentFileModel> ();
            List<ResponseFilesModel> responseFilesModelList = new List<ResponseFilesModel> ();
            foreach (var AssignmentFile in AssignmentFiles) {
                ResponseAssignmentFileModel responseAssignmentFileModel = new ResponseAssignmentFileModel ();
                Files newFiles = _dbContext.Files.FirstOrDefault (x => x.Id == AssignmentFile.FileId &&
                    x.IsDeleted == false
                );
                ResponseFilesModel responseFilesModel = new ResponseFilesModel ();
                var filetyped = _dbContext.FileTypes.FirstOrDefault (x => x.Id == newFiles.Id);
                responseFilesModel.Id = newFiles.Id;
                responseFilesModel.name = newFiles.Name;
                if (!string.IsNullOrEmpty (newFiles.Url))
                    responseFilesModel.url = _userHelper.getUrl (newFiles.Url, Certificate);
                //responseFilesModel.url = newFiles.Url;
                responseFilesModel.filename = newFiles.FileName;
                responseFilesModel.filetypeid = newFiles.FileTypeId;
                responseFilesModel.description = newFiles.Description;
                responseFilesModel.filetypename = filetyped.Filetype;
                responseFilesModel.filesize = newFiles.FileSize;

                responseAssignmentFileModel.id = AssignmentFile.Id;
                responseAssignmentFileModel.files = responseFilesModel;
                AssignmentFileList.Add (responseAssignmentFileModel);
            }
            return AssignmentFileList;
        }
        public List<ResponseLessonFileModel> GetLessionFilesByLessionId (long Id, long studentid, string Certificate) {
            List<LessonFile> lessonFiles = _dbContext.LessonFile.Where (x => x.LessionId == Id &&
                x.IsDeleted == false
            ).ToList ();
            List<ResponseLessonFileModel> LessonFileList = new List<ResponseLessonFileModel> ();
            List<ResponseFilesModel> responseFilesModelList = new List<ResponseFilesModel> ();
            foreach (var lessonFile in lessonFiles) {
                ResponseLessonFileModel responseLessonFileModel = new ResponseLessonFileModel ();
                Files newFiles = _dbContext.Files.FirstOrDefault (x => x.Id == lessonFile.FileId &&
                    x.IsDeleted == false
                );
                ResponseFilesModel responseFilesModel = new ResponseFilesModel ();
                var filetyped = _dbContext.FileTypes.FirstOrDefault (x => x.Id == newFiles.Id);
                responseFilesModel.Id = newFiles.Id;
                responseFilesModel.name = newFiles.Name;
                responseFilesModel.url = _userHelper.getUrl (newFiles.Url, Certificate);
                responseFilesModel.filename = newFiles.FileName;
                responseFilesModel.filetypeid = newFiles.FileTypeId;
                responseFilesModel.description = newFiles.Description;
                responseFilesModel.filetypename = filetyped.Filetype;
                responseFilesModel.filesize = newFiles.FileSize;
                responseFilesModel.duration = newFiles.Duration;
                responseFilesModel.totalpages = newFiles.TotalPages;
                responseLessonFileModel.progress = _dbContext.StudentLessonProgress.Where (x => x.LessonId == Id && x.StudentId == studentid).
                Select (x => new ResponseStudentLessonProgressModel {
                    id = x.Id,
                        lessonid = x.LessonId,
                        lessonstatus = x.LessonStatus,
                        studentid = x.StudentId,
                        lessonprogress = x.LessonProgress
                }).FirstOrDefault ();
                responseLessonFileModel.id = lessonFile.Id;
                responseLessonFileModel.files = responseFilesModel;
                LessonFileList.Add (responseLessonFileModel);
            }
            return LessonFileList;
        }
    }
}