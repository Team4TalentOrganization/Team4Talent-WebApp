namespace StudyGuidance.Domain
{
    public class Question
    {
        public int QuestionId { get; set; }
        public List<Option> Options { get; set; } = null!;
        public string Phrase {  get; set; } = string.Empty;
    }
}
