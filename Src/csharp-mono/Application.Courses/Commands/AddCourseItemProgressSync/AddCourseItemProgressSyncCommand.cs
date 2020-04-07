using System;
using System.Collections.Generic;
using MediatR;
using Bridge.Application.Models;

namespace Application.Courses.Commands.AddCourseItemProgressSync
{
    public class AddCourseItemProgressSyncCommand: IRequest<ApiResponse>
    {
        public List<AddCourseItemProgressSyncModel> addCourseItemProgressSyncs { get; set; }
    }


    public class AddCourseItemProgressSyncModel
    {
        public long id { get; set; }
        public long userid { get; set; }
        public long lessonid { get; set; }
        public long lessonprogress { get; set; }
        public long quizid { get; set; }
        public long isstatus { get; set; }
    }
}