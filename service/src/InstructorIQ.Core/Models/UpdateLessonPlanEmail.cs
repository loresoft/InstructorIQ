namespace InstructorIQ.Core.Models
{
    public class UpdateLessonPlanEmail : EmailModelBase
    {
        public string InstructorName { get; set; }

        public string SenderName { get; set; }

        public string SenderEmailAddress { get; set; }

        public string TopicTitle { get; set; }
    }
}