using StudyGuidance.Domain.Exceptions;

namespace StudyGuidance.Domain
{
    public class Option
    {
        private string _content = string.Empty;
        private int _optionRelation;
        private int _questionId;

        public int OptionId { get; set; }

        public int OptionRelation
        {
            get => _optionRelation;
            set
            {
                if (value <= 0)
                {
                    throw new BusinessException("OptionRelation must be greater than 0.");
                }

                _optionRelation = value;
            }
        }

        public int QuestionId
        {
            get => _questionId;
            set
            {
                if (value <= 0)
                {
                    throw new BusinessException("QuestionId must be greater than 0.");
                }

                _questionId = value;
            }
        }

        public string Content
        {
            get => _content;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new BusinessException("Content cannot be null or empty.");
                }

                _content = value;
            }
        }

        public bool IsChecked { get; set; } = false;
    }
}
