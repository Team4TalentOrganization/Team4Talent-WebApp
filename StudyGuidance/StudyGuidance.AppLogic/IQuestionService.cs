using StudyGuidance.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyGuidance.AppLogic
{
    public interface IQuestionService
    {
        IReadOnlyList<Question> AddUntilFourOptionsPerQuestion(IReadOnlyList<Question> questions);
    }
}
