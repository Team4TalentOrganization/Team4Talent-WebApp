using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyGuidance.Domain.Tests.Builders
{
    public class QuestionBuilder : BuilderBase<Question>
    {
        public QuestionBuilder()
        {
            ConstructItem();
        }

        public QuestionBuilder WithQuestionId(int questionId)
        {
            SetProperty(q => q.QuestionId, questionId);
            return this;
        }

        public QuestionBuilder WithPhrase(string phrase)
        {
            SetProperty(q => q.Phrase, phrase);
            return this;
        }

        public QuestionBuilder WithOptions(List<Option> options)
        {
            SetProperty(q => q.Options, options);
            return this;
        }
    }
}
