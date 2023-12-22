using StudyGuidance.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StudyGuidance.AppLogic
{
    public class QuestionService : IQuestionService
    {
        public IReadOnlyList<Question> AddUntilFourOptionsPerQuestion(IReadOnlyList<Question> questions)
        {
            List<Question> modifiedQuestions = new List<Question>();

            foreach (Question question in questions)
            {
                if (question.Options.Count < 4)
                {
                    int emptyOptionsToAdd = 4 - question.Options.Count;

                    for (int i = 0; i < emptyOptionsToAdd; i++)
                    {
                        question.Options.Add(new Option());
                    }
                }
                else if (question.Options.Count > 4)
                {
                    var remainingOptions = question.Options.Skip(4).ToList();

                    while (remainingOptions.Count > 0)
                    {
                        var newQuestion = new Question
                        {
                            Options = remainingOptions.Take(4).ToList(),
                            QuestionId = question.QuestionId,
                            Phrase = question.Phrase,
                            QuestionType = question.QuestionType,
                        };

                        modifiedQuestions.Add(newQuestion);

                        remainingOptions = remainingOptions.Skip(4).ToList();
                    }

                    question.Options = question.Options.Take(4).ToList();
                }

                modifiedQuestions.Add(question);
            }

            foreach (var question in modifiedQuestions)
            {
                while (question.Options.Count < 4)
                {
                    question.Options.Add(new Option());
                }
            }

            return modifiedQuestions.AsReadOnly();
        }
    }
}
