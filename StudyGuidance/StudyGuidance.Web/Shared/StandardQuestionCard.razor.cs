using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using StudyGuidance.Web.Models;

namespace StudyGuidance.Web.Shared
{
    public partial class StandardQuestionCard : ComponentBase
    {
        private bool StandardQuizEnded = false;
        private int currentQuestion = 0;
        private List<Question> questionsList = new List<Question>();
        private List<int> domainAnswers = new List<int>();
        private List<int> subDomainAnswers = new List<int>();
        private List<Question> selectedDomains = new List<Question>();
        private bool subDomainsAreSet = false;
        private bool EndButtonDisabled = false;

        private string[] CardClasses = new string[4] { "card text-black h-50 mb-3", "card text-black h-50 mb-3", "card text-black h-50 mb-3", "card text-black h-50 mb-3" };

        private async Task MouseOver(int cardNumber)
        {
            await SetCardClass(cardNumber, CardClasses[cardNumber].Contains("bg-orange-color-click") ? "card text-white bg-orange-color-click h-50 mb-3" : "card text-white bg-orange-color h-50 mb-3");
        }

        private async Task MouseOut(int cardNumber)
        {
            await SetCardClass(cardNumber, CardClasses[cardNumber].Contains("bg-orange-color-click") ? "card text-white bg-orange-color-click h-50 mb-3" : "card text-black h-50 mb-3");
        }

        private async Task SetCardClass(int cardNumber, string cssClass)
        {
            CardClasses[cardNumber] = cssClass;
        }

        private void CardClicked(int cardNumber)
        {
            // Check if the option is not empty before toggling
            if (!IsOptionValueEmpty(GetOptionsForCurrentQuestion()[cardNumber]))
            {
                // Toggle between two states
                if (CardClasses[cardNumber].Contains("bg-orange-color-click"))
                {
                    CardClasses[cardNumber] = "card text-black h-50 mb-3";
                }
                else
                {
                    CardClasses[cardNumber] = "card text-white bg-orange-color-click h-50 mb-3";
                }
            }
            else
            {
                CardClasses[cardNumber] = "card text-black h-50 mb-3";
            }
        }

        private List<string> GetOptionsForCurrentQuestion()
        {
            return GetQuestionAtIndex(currentQuestion)?.Options.Select(option => option.Content).ToList() ?? new List<string>();
        }

        private List<int> GetOptionIdForCurrentQuestion()
        {
            return GetQuestionAtIndex(currentQuestion)?.Options.Select(option => option.OptionId).ToList() ?? new List<int>();
        }

        private string GetCurrentQuestionPhrase()
        {
            return GetQuestionAtIndex(currentQuestion)?.Phrase ?? string.Empty;
        }

        private Question GetQuestionAtIndex(int index)
        {
            return (index >= 0 && index < questionsList.Count) ? questionsList[index] : null;
        }


        private async Task NextQuestionClicked()
        {
            for (int i = 0; i < 4; i++)
            {
                if (CardClasses[i] == "card text-white bg-orange-color-click h-50 mb-3")
                {
                    domainAnswers.Add(GetOptionIdForCurrentQuestion()[i]);

                    if (subDomainsAreSet)
                    {
                        subDomainAnswers.Add(GetOptionIdForCurrentQuestion()[i]);
                    }
                }
            }

            if (currentQuestion == questionsList.Count - 1 && !subDomainsAreSet)
            {
                selectedDomains = await QuizApiClient.GetSubdomains(domainAnswers);
                var questionsWithEmptyOption = new List<Question>();
                var modifiedQuestions = new List<Question>();

                foreach (var selectedDomain in selectedDomains)
                {
                    if (selectedDomain.Options.Any(option => string.IsNullOrEmpty(option.Content)))
                    {
                        questionsWithEmptyOption.Add(selectedDomain);
                    }
                    else
                    {
                        modifiedQuestions.Add(selectedDomain);
                    }
                }

                modifiedQuestions.AddRange(questionsWithEmptyOption);


                modifiedQuestions.ForEach(question =>
                {
                    question.Options.AddRange(Enumerable.Range(0, 4 - question.Options.Count)
                        .Select(_ => new Option()));
                });


                questionsList.AddRange(modifiedQuestions);

                subDomainsAreSet = true;
            }


            ResetCardClasses();
            currentQuestion++;
        }

        private void PreviousQuestionClicked()
        {
            if (currentQuestion > 0)
            {
                currentQuestion--;
                if (GetCurrentQuestionPhrase() == "In welk domein heb je interesse?")
                {
                    questionsList.RemoveAll(questions => questions.Phrase.Contains("In welk subdomein heb je interesse?"));
                    subDomainsAreSet = false;
                    domainAnswers.Clear();
                }
                ResetCardClasses();
            }
        }

        private void ResetCardClasses()
        {
            for (int i = 0; i < CardClasses.Length; i++)
            {
                CardClasses[i] = "card text-black h-50 mb-3";
            }
        }

        private void EndStandardQuiz()
        {
            for (int i = 0; i < 4; i++)
            {
                if (CardClasses[i] == "card text-white bg-orange-color-click h-50 mb-3")
                {
                    if (subDomainsAreSet)
                    {
                        subDomainAnswers.Add(GetOptionIdForCurrentQuestion()[i]);
                    }
                }
            }
            StandardQuizEnded = true;
        }

        private bool AreAnyCardsSelected()
        {
            if (!domainAnswers.Any() && currentQuestion == questionsList.Count)
            {
                return false;
            }
            return true;
        }

        private bool IsOptionValueEmpty(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return true;
            }
            return false;
        }

        protected override async Task OnInitializedAsync()
        {
            var originalQuestionsList = await QuizApiClient.GetAllDomainQuestions();
            var questionsWithEmptyOption = new List<Question>();
            var modifiedQuestions = new List<Question>();

            foreach (var question in originalQuestionsList)
            {
                if (question.Options.Any(option => string.IsNullOrEmpty(option.Content)))
                {
                    questionsWithEmptyOption.Add(question);
                }
                else
                {
                    modifiedQuestions.Add(question);
                }
            }

            modifiedQuestions.AddRange(questionsWithEmptyOption);

            foreach (var question in modifiedQuestions)
            {
                while (question.Options.Count < 4)
                {
                    question.Options.Add(new Option());
                }
            }

            questionsList = modifiedQuestions;

            await JS.InvokeVoidAsync("console.log", questionsList);
        }
    }
}
