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

        public List<Question> GetQuestions()
        {
            return _context.Questions.Include(options => options.Options).ToList();
        }
    }
}
