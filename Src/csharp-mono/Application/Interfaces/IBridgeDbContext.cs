using System.Threading;
using System.Threading.Tasks;
using Bridge.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Bridge.Application.Interfaces
{
    public interface IBridgeDbContext
    {
        DbSet<User> Users { get; set; }
        DbSet<Deposit> Deposit { get; set; }
        DbSet<Role> Role { get; set; }
        DbSet<Bundle> Bundle { get; set; }
        DbSet<Course> Course { get; set; }
        DbSet<CourseRevision> CourseRevision { get; set; }
        DbSet<Chapter> Chapter { get; set; }
        DbSet<Lesson> Lesson { get; set; }
        DbSet<Quiz> Quiz { get; set; }
        DbSet<QuestionType> QuestionType { get; set; }
        DbSet<BundleCourse> BundleCourse { get; set; }
        DbSet<Question> Question { get; set; }
        DbSet<QuestionAnswer> QuestionAnswer { get; set; }
        DbSet<Files> Files { get; set; }
        DbSet<FileTypes> FileTypes { get; set; }
        DbSet<QuizQuestion> QuizQuestion { get; set; }
        DbSet<UserCourse> UserCourse { get; set; }
        DbSet<LessonFile> LessonFile { get; set; }
        DbSet<UserSessions> UserSessions { get; set; }
        DbSet<Grade> Grade { get; set; }
        DbSet<CourseGrade> CourseGrade { get; set; }
        DbSet<Assignment> Assignment { get; set; }
        DbSet<AssignmentFile> AssignmentFile { get; set; }
        DbSet<AssignmentStudent> AssignmentStudent { get; set; }
        DbSet<QuestionFile> QuestionFile { get; set; }
        DbSet<UserRole> UserRole { get; set; }
        DbSet<AnswerFile> AnswerFile { get; set; }
        DbSet<Contact> Contact { get; set; }
        DbSet<Feedback> Feedback { get; set; }
        DbSet<FeedBackCategory> FeedBackCategory { get; set; }
        DbSet<FeebackTime> FeebackTime { get; set; }
        DbSet<FeedbackFile> FeedbackFile { get; set; }
        DbSet<StudentCourseProgress> StudentCourseProgress { get; set; }
        DbSet<StudentChapterProgress> StudentChapterProgress { get; set; }
        DbSet<StudentLessonProgress> StudentLessonProgress { get; set; }
        DbSet<StudentProgress> StudentProgress { get; set; }
        DbSet<ProgressStatus> ProgressStatus { get; set; }
        DbSet<SalesAgent> SalesAgent { get; set; }
        DbSet<CourseDefination> CourseDefination { get; set; }
        DbSet<Discount> Discount { get; set; }
        DbSet<AgentCategory> AgentCategory { get; set; }
        DbSet<Subscriptions> Subscriptions { get; set; }
        DbSet<SubscriptionMetadata> SubscriptionMetadata { get; set; }
        DbSet<Currency> Currency { get; set; }
        DbSet<QuizSummary> QuizSummary { get; set; }
        DbSet<IndividualDetails> IndividualDetails { get; set; }
        DbSet<DocumentDetails> DocumentDetails { get; set; }
        DbSet<SchoolDetails> SchoolDetails { get; set; }
        DbSet<MetaDataDetail> MetaDataDetail { get; set; }
        DbSet<CourseItemProgressSync> CourseItemProgressSync { get; set; }
        DbSet<DefaultValues> DefaultValues { get; set; }
        DbSet<AssignmentSubmission> AssignmentSubmissions { get; set; }
        DbSet<FeedBackStaff> FeedBackStaff { get; set; }
        DbSet<FeedBackTask> FeedBackTask { get; set; }
        DbSet<FeedBackActivity> FeedBackActivity { get; set; }
        DbSet<School> School { get; set; }
        DbSet<ProgessSync> ProgessSync { get; set; }
        DbSet<QuizTimerSync> QuizTimerSync { get; set; }
        DbSet<ChapterQuiz> chapterQuiz { get; set; }
        DbSet<Logs> Logs { get; set; }
        DbSet<Buckets> Buckets { get; set; }
        DbSet<FeedBackTaskStatus> FeedBackTaskStatus { get; set; }
        DbSet<FeedBackTaskStatusOption> FeedBackTaskStatusOption { get; set; }
        DbSet<PurchagePdf> PurchagePdf { get; set; }
        DbSet<PurchageUpload> PurchageUpload { get; set; }
        DbSet<ManagementInfo> ManagementInfo { get; set; }
        DbSet<DiscussionTopic> DiscussionTopic { get; set; }
        DbSet<DiscussionFiles> DiscussionFiles { get; set; }
        DbSet<DiscussionComments> DiscussionComments { get; set; }
        DbSet<DiscussionCommentFiles> DiscussionCommentFiles { get; set; }
        DbSet<UserNotifications> UserNotifications { get; set; }
        DbSet<LogObjectTypes> LogObjectTypes { get; set; }
        DbSet<LogObject> LogObjects { get; set; }
        DbSet<NotificationLog> NotificationLogs { get; set; }
        DbSet<AddtionalServices> AddtionalServices { get; set; }
        DbSet<Package> Packages { get; set; }
        DbSet<PackageCourse> PackageCourses { get; set; }
        DbSet<Books> Books { get; set; }
        DbSet<TimeInterval> TimeIntervals { get; set; }
        DbSet<SalesTax> SalesTax { get; set; }
        DbSet<ERPAccounts> ERPAccounts { get; set; }
        DbSet<LessonAssignment> LessonAssignments { get; set; }
        DbSet<LessonAssignmentFile> LessonAssignmentFiles { get; set; }
        DbSet<AssignmentSubmissionFile> AssignmentSubmissionFiles { get; set; }
        DbSet<LessonAssignmentSubmission> LessonAssignmentSubmissions { get; set; }
        DbSet<LessonAssignmentSubmissionFile> LessonAssignmentSubmissionFiles { get; set; }
        DbSet<AppTimeTrack> AppTimeTracks { get; set; }
        DbSet<ChapterProgress> ChapterProgresses { get; set; }
        DbSet<LessonProgress> LessonProgresses { get; set; }
        DbSet<QuizProgress> QuizProgresses { get; set; }
        DbSet<FileProgress> FileProgresses { get; set; }
        DbSet<UserQuizResult> UserQuizResults { get; set; }
        DbSet<StudParent> StudParents { get; set; }
        DbSet<DiscussionTopicLikes> DiscussionTopicLikes { get; set; }
        DbSet<DiscussionCommentLikes> DiscussionCommentLikes { get; set; }
        DbSet<TermsAndConditions> TermsAndConditions { get; set; }
        //Feedback new module
        DbSet<TaskFeedBack> TaskFeedBacks { get; set; }
        DbSet<TaskCategoryFeedBack> TaskCategoryFeedBacks { get; set; }
        DbSet<TaskFileFeedBack> TaskFileFeedBacks { get; set; }
        DbSet<TaskActivityFeedBack> TaskActivityFeedBacks { get; set; }
        DbSet<TaskActivityCategoryFeedBack> TaskActivityCategoryFeedBacks { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}