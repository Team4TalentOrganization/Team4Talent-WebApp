using Microsoft.EntityFrameworkCore;
using StudyGuidance.AppLogic;
using StudyGuidance.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyGuidance.Infrastructure
{
    internal class QuestionDbRepository: IQuestionRepository
    {

        StudyGuidanceDbContext _context;

        public QuestionDbRepository(StudyGuidanceDbContext context)
        { 
            _context = context;
        }

        public async Task<IReadOnlyList<Question>> GetQuestionsAsync()
        {
            return await _context.Questions.Include(options => options.Options).ToListAsync<Question>();
        }
    }
}
