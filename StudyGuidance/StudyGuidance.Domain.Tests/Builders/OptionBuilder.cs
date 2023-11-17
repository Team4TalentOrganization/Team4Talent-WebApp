using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyGuidance.Domain.Tests.Builders
{
    public class OptionBuilder : BuilderBase<Option>
    {
        public OptionBuilder()
        {
            ConstructItem();
        }

        public OptionBuilder WithOptionId(int optionId)
        {
            SetProperty(o => o.OptionId, optionId);
            return this;
        }

        public OptionBuilder WithOptionRelation(int optionRelation)
        {
            SetProperty(o => o.OptionRelation, optionRelation);
            return this;
        }

        public OptionBuilder WithQuestionId(int questionId)
        {
            SetProperty(o => o.QuestionId, questionId);
            return this;
        }

        public OptionBuilder WithContent(string content)
        {
            SetProperty(o => o.Content, content);
            return this;
        }

        public OptionBuilder IsChecked(bool isChecked)
        {
            SetProperty(o => o.IsChecked, isChecked);
            return this;
        }
    }
}
