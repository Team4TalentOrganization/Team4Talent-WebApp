using StudyGuidance.Domain.Exceptions;

namespace StudyGuidance.Domain
{
    public class Question
    {
        private string _phrase = string.Empty;
        private List<Option> _options = new List<Option>();

        public int QuestionId { get; set; }

        public string Phrase
        {
            get => _phrase;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new BusinessException("Phrase cannot be null or empty");
                }

                _phrase = value;
            }
        }

        public List<Option> Options
        {
            get => _options;
            set
            {
                if (value == null || !value.Any())
                {
                    throw new BusinessException("Options list cannot be null or empty.");
                }

                _options = value;
            }
        }
    }
}
