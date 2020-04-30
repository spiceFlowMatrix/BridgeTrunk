using Bridge.Application.Interfaces;
using Bridge.Common;
using Bridge.Domain.Common;
using Bridge.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Bridge.Persistence
{
    public class BridgeDbContext : DbContext, IBridgeDbContext
    {
        private readonly ICurrentUserService _currentUserService;
        private readonly IDateTime _dateTime;

        public BridgeDbContext(DbContextOptions<BridgeDbContext> options)
            : base(options)
        {
        }

        public BridgeDbContext(DbContextOptions<BridgeDbContext> options, 
            ICurrentUserService currentUserService, 
            IDateTime dateTime)
            : base(options)
        {
            _currentUserService = currentUserService;
            _dateTime = dateTime;
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Deposit> Deposit { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<Bundle> Bundle { get; set; }
        public DbSet<Course> Course { get; set; }
        public DbSet<CourseRevision> CourseRevision { get; set; }
        public DbSet<Chapter> Chapter { get; set; }
        public DbSet<Lesson> Lesson { get; set; }
        public DbSet<Quiz> Quiz { get; set; }
        public DbSet<QuestionType> QuestionType { get; set; }
        public DbSet<BundleCourse> BundleCourse { get; set; }
        public DbSet<Question> Question { get; set; }
        public DbSet<QuestionAnswer> QuestionAnswer { get; set; }
        public DbSet<Files> Files { get; set; }
        public DbSet<FileTypes> FileTypes { get; set; }
        public DbSet<QuizQuestion> QuizQuestion { get; set; }
        public DbSet<UserCourse> UserCourse { get; set; }
        public DbSet<LessonFile> LessonFile { get; set; }
        public DbSet<UserSessions> UserSessions { get; set; }
        public DbSet<Grade> Grade { get; set; }
        public DbSet<CourseGrade> CourseGrade { get; set; }
        public DbSet<Assignment> Assignment { get; set; }
        public DbSet<AssignmentFile> AssignmentFile { get; set; }
        public DbSet<AssignmentStudent> AssignmentStudent { get; set; }
        public DbSet<QuestionFile> QuestionFile { get; set; }
        public DbSet<UserRole> UserRole { get; set; }
        public DbSet<AnswerFile> AnswerFile { get; set; }
        public DbSet<Contact> Contact { get; set; }
        public DbSet<Feedback> Feedback { get; set; }
        public DbSet<FeedBackCategory> FeedBackCategory { get; set; }
        public DbSet<FeebackTime> FeebackTime { get; set; }
        public DbSet<FeedbackFile> FeedbackFile { get; set; }
        public DbSet<StudentCourseProgress> StudentCourseProgress { get; set; }
        public DbSet<StudentChapterProgress> StudentChapterProgress { get; set; }
        public DbSet<StudentLessonProgress> StudentLessonProgress { get; set; }
        public DbSet<StudentProgress> StudentProgress { get; set; }
        public DbSet<ProgressStatus> ProgressStatus { get; set; }
        public DbSet<SalesAgent> SalesAgent { get; set; }
        public DbSet<CourseDefination> CourseDefination { get; set; }
        public DbSet<Discount> Discount { get; set; }
        public DbSet<AgentCategory> AgentCategory { get; set; }
        public DbSet<Subscriptions> Subscriptions { get; set; }
        public DbSet<SubscriptionMetadata> SubscriptionMetadata { get; set; }
        public DbSet<Currency> Currency { get; set; }
        public DbSet<QuizSummary> QuizSummary { get; set; }
        public DbSet<IndividualDetails> IndividualDetails { get; set; }
        public DbSet<DocumentDetails> DocumentDetails { get; set; }
        public DbSet<SchoolDetails> SchoolDetails { get; set; }
        public DbSet<MetaDataDetail> MetaDataDetail { get; set; }
        public DbSet<CourseItemProgressSync> CourseItemProgressSync { get; set; }
        public DbSet<DefaultValues> DefaultValues { get; set; }
        public DbSet<AssignmentSubmission> AssignmentSubmissions { get; set; }
        public DbSet<FeedBackStaff> FeedBackStaff { get; set; }
        public DbSet<FeedBackTask> FeedBackTask { get; set; }
        public DbSet<FeedBackActivity> FeedBackActivity { get; set; }
        public DbSet<School> School { get; set; }
        public DbSet<ProgessSync> ProgessSync { get; set; }
        public DbSet<QuizTimerSync> QuizTimerSync { get; set; }
        public DbSet<ChapterQuiz> chapterQuiz { get; set; }
        public DbSet<Logs> Logs { get; set; }
        public DbSet<Buckets> Buckets { get; set; }
        public DbSet<FeedBackTaskStatus> FeedBackTaskStatus { get; set; }
        public DbSet<FeedBackTaskStatusOption> FeedBackTaskStatusOption { get; set; }
        public DbSet<PurchagePdf> PurchagePdf { get; set; }
        public DbSet<PurchageUpload> PurchageUpload { get; set; }
        public DbSet<ManagementInfo> ManagementInfo { get; set; }
        public DbSet<DiscussionTopic> DiscussionTopic { get; set; }
        public DbSet<DiscussionFiles> DiscussionFiles { get; set; }
        public DbSet<DiscussionComments> DiscussionComments { get; set; }
        public DbSet<DiscussionCommentFiles> DiscussionCommentFiles { get; set; }
        public DbSet<UserNotifications> UserNotifications { get; set; }
        public DbSet<LogObjectTypes> LogObjectTypes { get; set; }
        public DbSet<LogObject> LogObjects { get; set; }
        public DbSet<NotificationLog> NotificationLogs { get; set; }
        public DbSet<AddtionalServices> AddtionalServices { get; set; }
        public DbSet<Package> Packages { get; set; }
        public DbSet<PackageCourse> PackageCourses { get; set; }
        public DbSet<Books> Books { get; set; }
        public DbSet<TimeInterval> TimeIntervals { get; set; }
        public DbSet<SalesTax> SalesTax { get; set; }
        public DbSet<ERPAccounts> ERPAccounts { get; set; }
        public DbSet<LessonAssignment> LessonAssignments { get; set; }
        public DbSet<LessonAssignmentFile> LessonAssignmentFiles { get; set; }
        public DbSet<AssignmentSubmissionFile> AssignmentSubmissionFiles { get; set; }
        public DbSet<LessonAssignmentSubmission> LessonAssignmentSubmissions { get; set; }
        public DbSet<LessonAssignmentSubmissionFile> LessonAssignmentSubmissionFiles { get; set; }
        public DbSet<AppTimeTrack> AppTimeTracks { get; set; }
        public DbSet<ChapterProgress> ChapterProgresses { get; set; }
        public DbSet<LessonProgress> LessonProgresses { get; set; }
        public DbSet<QuizProgress> QuizProgresses { get; set; }
        public DbSet<FileProgress> FileProgresses { get; set; }
        public DbSet<UserQuizResult> UserQuizResults { get; set; }
        public DbSet<StudParent> StudParents { get; set; }
        public DbSet<DiscussionTopicLikes> DiscussionTopicLikes { get; set; }
        public DbSet<DiscussionCommentLikes> DiscussionCommentLikes { get; set; }
        public DbSet<TermsAndConditions> TermsAndConditions { get; set; }
        //Feedback new module
        public DbSet<TaskFeedBack> TaskFeedBacks { get; set; }
        public DbSet<TaskCategoryFeedBack> TaskCategoryFeedBacks { get; set; }
        public DbSet<TaskFileFeedBack> TaskFileFeedBacks { get; set; }
        public DbSet<TaskActivityFeedBack> TaskActivityFeedBacks { get; set; }
        public DbSet<TaskActivityCategoryFeedBack> TaskActivityCategoryFeedBacks { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            // TODO: See if it's possible to automate more complex database record operations such as running complex queries and feeding query data to database trigger functions (actually triggering stored procedures right from here)
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        // entry.Entity.CreatorUserId =_currentUserService.UserId;
                        entry.Entity.CreationTime = DateTime.Now.ToString();
                        break;
                    case EntityState.Modified:
                        // entry.Entity.LastModifierUserId = _currentUserService.UserId;
                        entry.Entity.LastModificationTime = DateTime.Now.ToString();
                        break;
                }
            }
            
            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // TODO: Ensure all generated data structure naming follows snake casing.
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BridgeDbContext).Assembly);

            var cascadeFKs = modelBuilder.Model.GetEntityTypes()
                .SelectMany(t => t.GetForeignKeys())
                .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);
            foreach (var fk in cascadeFKs)
                fk.DeleteBehavior = DeleteBehavior.Restrict;

            base.OnModelCreating(modelBuilder);
        }
    }
}