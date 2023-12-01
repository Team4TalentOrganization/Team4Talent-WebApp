namespace StudyGuidance.Web.Models
{
    public class Question
    {
        public List<Option> Options { get; set; }
        public int QuestionId { get; set; }
        public string Phrase { get; set; }
    }
}
