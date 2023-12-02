using StudyGuidance.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StudyGuidance.AppLogic
{
    public class QuestionModificationService : IQuestionModificationService
    {
        public IReadOnlyList<Question> ModifyQuestions(IReadOnlyList<Question> questions)
        {
            List<Question> modifiedQuestions = new List<Question>();

            foreach (Question question in questions)
            {
                // Check if the current question has fewer than 4 options
                if (question.Options.Count < 4)
                {
                    // Calculate the number of empty options to add
                    int emptyOptionsToAdd = 4 - question.Options.Count;

                    // Add new empty options to the current question
                    for (int i = 0; i < emptyOptionsToAdd; i++)
                    {
                        question.Options.Add(new Option()); // You can change this to the default value for new options
                    }
                }
                else if (question.Options.Count > 4)
                {
                    // Create a new question with the remaining options
                    var remainingOptions = question.Options.Skip(4).ToList();

                    // Keep creating new questions until all remaining options are used
                    while (remainingOptions.Count > 0)
                    {
                        var newQuestion = new Question
                        {
                            Options = remainingOptions.Take(4).ToList(),
                            QuestionId = question.QuestionId, // Use the same QuestionId if needed
                            Phrase = question.Phrase // Add a suffix to indicate continuation
                        };

                        // Insert the new question right after the current question
                        modifiedQuestions.Add(newQuestion);

                        // Trim the remaining options
                        remainingOptions = remainingOptions.Skip(4).ToList();
                    }

                    // Trim the current question's options to the first 4
                    question.Options = question.Options.Take(4).ToList();
                }

                // Add the modified or original question to the list
                modifiedQuestions.Add(question);
            }

            // Ensure that every question has exactly 4 options
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
