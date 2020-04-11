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
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Courses.Queries.GetCoursePreviewGradeWise {
    public class GetCoursePreviewGradeWiseQueryHandler : IRequestHandler<GetCoursePreviewGradeWiseQuery, ApiResponse> {
        private readonly IBridgeDbContext _dbContext;
        private readonly IUserHelper _userHelper;
        private readonly ICurrentUserService _userService;
        public GetCoursePreviewGradeWiseQueryHandler (IBridgeDbContext dbContext, IUserHelper userHelper, ICurrentUserService userService) {
            _dbContext = dbContext;
            _userHelper = userHelper;
            _userService = userService;
        }

        public async Task<ApiResponse> Handle (GetCoursePreviewGradeWiseQuery request, CancellationToken cancellationToken) {
            ApiResponse res = new ApiResponse ();
            try {
                var userId = _userService.UserId;
                var id = int.Parse (userId);
                string certificate = Path.GetFileName ("../../training24-28e994f9833c.json");
                //update UserCourse table IsExpire field
                (from usercourse in _dbContext.UserCourse join courses in _dbContext.Course on usercourse.CourseId equals courses.Id where usercourse.UserId == id &&
                    (!string.IsNullOrEmpty (usercourse.EndDate) && Convert.ToDateTime (usercourse.EndDate, CultureInfo.InvariantCulture).Date < DateTime.Now.Date)
                    //&& courses.istrial == true
                    select usercourse).ToList ().ForEach (x => x.IsExpire = true);
                await _dbContext.SaveChangesAsync (cancellationToken);

                var user = await _dbContext.Users.FirstOrDefaultAsync (x => x.Id == id);
                object coursePreview = null;

                List<CoursePriviewGradeWiseModel> coursePriviewGradeWiseModels = new List<CoursePriviewGradeWiseModel> ();
                if (user.istrial) {
                    var days = (DateTime.Now.Date - Convert.ToDateTime (user.CreationTime, CultureInfo.InvariantCulture).Date).Days;
                    if (days < 15) {
                        var list = await _dbContext.Course.Where (x => x.istrial == true).ToListAsync ();
                        foreach (var usercourse in list) {
                            var courseGrade = await _dbContext.CourseGrade.Where (x => x.CourseId == usercourse.Id).ToListAsync ();
                            var course = await _dbContext.Course.FirstOrDefaultAsync (x => x.Id == usercourse.Id
                                && x.IsDeleted == false
                            );
                            if (course != null) {
                                foreach (var cgrade in courseGrade) {

                                    List<GradeWiseCoursePriviewModel> coursePriviewModelList = new List<GradeWiseCoursePriviewModel> ();
                                    var grade = await _dbContext.Grade.FirstOrDefaultAsync (x => x.Id == cgrade.Gradeid);
                                    GradeWiseCoursePriviewModel coursePriviewModel = new GradeWiseCoursePriviewModel ();
                                    coursePriviewModel.id = course.Id;
                                    coursePriviewModel.code = course.Code;
                                    coursePriviewModel.description = course.Description;
                                    if (!string.IsNullOrEmpty (course.Image))
                                        coursePriviewModel.image = _userHelper.getUrl (course.Image, certificate);
                                    coursePriviewModel.name = course.Name;
                                    coursePriviewModelList.Add (coursePriviewModel);

                                    CoursePriviewGradeWiseModel coursePriview = new CoursePriviewGradeWiseModel ();
                                    coursePriview.id = grade.Id;
                                    coursePriview.name = grade.Name;
                                    coursePriview.courses = coursePriviewModelList;

                                    CoursePriviewGradeWiseModel cp = coursePriviewGradeWiseModels.Find (b => b.id == grade.Id);
                                    if (cp == null) {
                                        coursePriviewGradeWiseModels.Add (coursePriview);
                                    } else {
                                        cp.courses.Add (coursePriviewModel);
                                    }
                                }
                            }
                        }
                    }
                } else {

                    var list = await _dbContext.UserCourse.Where (x => x.UserId == id && x.IsExpire == false
                         && x.IsDeleted==false
                    ).ToListAsync ();
                    foreach (var usercourse in list) {
                        var courseGrade = await _dbContext.CourseGrade.Where (x => x.CourseId == usercourse.Id).ToListAsync ();
                        var course = await _dbContext.Course.FirstOrDefaultAsync (x => x.Id == usercourse.Id
                            && x.IsDeleted == false
                        );
                        if (course != null) {
                            foreach (var cgrade in courseGrade) {

                                List<GradeWiseCoursePriviewModel> coursePriviewModelList = new List<GradeWiseCoursePriviewModel> ();
                                var grade = await _dbContext.Grade.FirstOrDefaultAsync (x => x.Id == cgrade.Gradeid);
                                GradeWiseCoursePriviewModel coursePriviewModel = new GradeWiseCoursePriviewModel ();
                                coursePriviewModel.id = course.Id;
                                coursePriviewModel.code = course.Code;
                                coursePriviewModel.description = course.Description;
                                if (!string.IsNullOrEmpty (course.Image)) {
                                    if (course.Image.Contains ("t24-primary-image-storage"))
                                        coursePriviewModel.image = course.Image;
                                    else
                                        coursePriviewModel.image = _userHelper.getUrl (course.Image, certificate);
                                }
                                coursePriviewModel.name = course.Name;
                                coursePriviewModel.startdate = usercourse.StartDate;
                                coursePriviewModel.enddate = usercourse.EndDate;
                                coursePriviewModelList.Add (coursePriviewModel);

                                CoursePriviewGradeWiseModel coursePriview = new CoursePriviewGradeWiseModel ();
                                coursePriview.id = grade.Id;
                                coursePriview.name = grade.Name;
                                coursePriview.courses = coursePriviewModelList;

                                CoursePriviewGradeWiseModel cp = coursePriviewGradeWiseModels.Find (b => b.id == grade.Id);
                                if (cp == null) {
                                    coursePriviewGradeWiseModels.Add (coursePriview);
                                } else {
                                    cp.courses.Add (coursePriviewModel);
                                }
                            }
                        }
                    }
                }
                var coursePriviewGradeWiseModelstest = coursePriviewGradeWiseModels;
                res.totalcount = coursePriviewGradeWiseModelstest.Count ();
                if (request.PageNumber != 0 && request.PerPageRecord != 0 && request.GradeId != 0) {
                    coursePriviewGradeWiseModelstest = coursePriviewGradeWiseModelstest.Where (b => b.id == request.GradeId).ToList ();
                    res.totalcount = coursePriviewGradeWiseModelstest.Count ();
                    coursePriviewGradeWiseModelstest = coursePriviewGradeWiseModelstest.Skip (request.PerPageRecord * (request.PageNumber - 1)).
                    Take (request.PerPageRecord).
                    ToList ();

                    if (!string.IsNullOrEmpty (request.Search)) {

                        foreach (var take in coursePriviewGradeWiseModelstest.ToList ()) {
                            bool t1 = take.id.ToString () == request.Search;
                            bool t2 = take.name.ToLower () == request.Search.ToLower ();
                            if (t1 == true || t2 == true)
                                continue;
                            foreach (var coursetake in take.courses.ToList ()) {
                                bool t3 = coursetake.name.ToLower () == request.Search.ToLower ();
                                bool t4 = coursetake.description.ToLower () == request.Search.ToLower ();
                                if (t3 == true || t4 == true)
                                    continue;
                                else
                                    take.courses.Remove (coursetake);
                            }
                            if (take.courses.Count == 0) {
                                coursePriviewGradeWiseModelstest.Remove (take);
                            }
                        }
                    }
                }
                if (request.PageNumber != 0 && request.PerPageRecord != 0) {
                    coursePriviewGradeWiseModelstest = coursePriviewGradeWiseModelstest.Skip (request.PerPageRecord * (request.PageNumber - 1)).
                    Take (request.PerPageRecord).
                    ToList ();
                    if (!string.IsNullOrEmpty (request.Search)) {
                        foreach (var take in coursePriviewGradeWiseModelstest.ToList ()) {
                            bool t1 = take.id.ToString () == request.Search;
                            bool t2 = take.name.ToLower () == request.Search.ToLower ();
                            if (t1 == true || t2 == true)
                                continue;
                            foreach (var coursetake in take.courses.ToList ()) {
                                bool t3 = coursetake.name.ToLower () == request.Search.ToLower ();
                                bool t4 = coursetake.description.ToLower () == request.Search.ToLower ();
                                if (t3 == true || t4 == true)
                                    continue;
                                else
                                    take.courses.Remove (coursetake);
                            }
                            if (take.courses.Count == 0) {
                                coursePriviewGradeWiseModelstest.Remove (take);
                            }
                        }
                    }
                }

                if (!string.IsNullOrEmpty (request.Search)) {
                    foreach (var take in coursePriviewGradeWiseModelstest.ToList ()) {
                        bool t1 = take.id.ToString () == request.Search;
                        bool t2 = take.name.ToLower () == request.Search.ToLower ();
                        if (t1 == true || t2 == true)
                            continue;
                        foreach (var coursetake in take.courses.ToList ()) {
                            bool t3 = coursetake.name.ToLower () == request.Search.ToLower ();
                            bool t4 = coursetake.description.ToLower () == request.Search.ToLower ();
                            if (t3 == true || t4 == true)
                                continue;
                            else
                                take.courses.Remove (coursetake);
                        }
                        if (take.courses.Count == 0) {
                            coursePriviewGradeWiseModelstest.Remove (take);
                        }
                    }
                }

                if (request.GradeId != 0) {
                    coursePriviewGradeWiseModelstest = coursePriviewGradeWiseModelstest.Where (b => b.id == request.GradeId).
                    ToList ();
                    res.totalcount = coursePriviewGradeWiseModelstest.Count ();
                }
                coursePreview = coursePriviewGradeWiseModelstest;

                res.data = coursePreview;
                res.response_code = 0;
                res.message = "Course detail";
                res.status = "Success";
                res.ReturnCode = 200;
            } catch (Exception ex) {
                res.ReturnCode = 500;
                res.response_code = 2;
                res.message = ex.Message;
                res.status = "Failure";
            }
            return res;
        }
    }
}