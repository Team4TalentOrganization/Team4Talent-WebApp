namespace StudyGuidance.Domain
{
    public class Option
    {
        public int OptionId { get; set; }

        public int OptionRelation {  get; set; }

        public int QuestionId { get; set; }

        public string Content { get; set; } = string.Empty;

        public bool IsChecked { get; set; } = false;
       
    }
}
