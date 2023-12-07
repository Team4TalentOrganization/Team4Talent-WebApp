using Microsoft.EntityFrameworkCore;
using StudyGuidance.AppLogic;
using StudyGuidance.Domain;
using System.Linq;

namespace StudyGuidance.Infrastructure
{
    internal class QuizDbRepository: IQuizRepository
    {

        StudyGuidanceDbContext _context;

        public QuizDbRepository(StudyGuidanceDbContext context)
        { 
            _context = context;
        }

        public async Task<IReadOnlyList<Question>> GetQuestionsAsync()
        {
            return await _context.Questions.Include(options => options.Options).ToListAsync<Question>();
        }

        public async Task<IReadOnlyList<Question>> GetStandardQuizQuestionsAsync()
        {
            return await _context.Questions.Where(q => q.QuestionType == QuestionType.StandardQuizQuestion).Include(options => options.Options).ToListAsync<Question>();
        }

        public async Task<IReadOnlyList<Question>> GetTinderQuizQuestionsAsync()
        {
            return await _context.Questions.Where(q => q.QuestionType == QuestionType.TinderQuizQuestion).Include(options => options.Options).ToListAsync<Question>();
        }

        public async Task<IReadOnlyList<Option>> GetDomainsAsync()
        {
            return await _context.Options.Where(o => o.QuestionId == 1).ToListAsync<Option>();
        }

        public async Task<IReadOnlyList<Question>> GetSelectedSubDomainsAsync(List<int> domainIds)
        {
            List<Option> selectedOptions = await _context.Options
                .Where(o => domainIds.Contains(o.OptionRelation))
                .ToListAsync();

            List<Question> questionsWithSelectedOptions = new List<Question>();
            Question questionWithSelectedOption = new Question();
            questionWithSelectedOption.Phrase = "In welk subdomein heb je interesse?";
            questionWithSelectedOption.QuestionType = QuestionType.StandardQuizQuestion;
            foreach (Option option in selectedOptions)
            {
                questionWithSelectedOption.Options.Add(option);
            }
            questionsWithSelectedOptions.Add(questionWithSelectedOption);
            return questionsWithSelectedOptions;

        }

        public async Task<IReadOnlyList<Question>> GetDomainQuestionsAsync()
        {
            return await _context.Questions.Where(q => q.Phrase == "In welk domein heb je interesse?").Include(options => options.Options).ToListAsync<Question>();
        }
    }
}
