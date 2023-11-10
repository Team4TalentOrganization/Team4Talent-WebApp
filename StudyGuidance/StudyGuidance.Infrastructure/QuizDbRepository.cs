using Microsoft.EntityFrameworkCore;
using StudyGuidance.AppLogic;
using StudyGuidance.Domain;

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

        public async Task<IReadOnlyList<Option>> GetDomainsAsync()
        {
            return await _context.Options.Where(o => o.QuestionId == 1).ToListAsync<Option>();
        }

        public async Task<IReadOnlyList<Option>> GetSubDomainsAsync(List<int> domainIds)
        {
            return await _context.Options
                .Where(o => domainIds.Contains(o.OptionRelation))
                .ToListAsync();
        }
    }
}
