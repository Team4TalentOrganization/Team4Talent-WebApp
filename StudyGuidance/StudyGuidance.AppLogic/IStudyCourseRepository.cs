using StudyGuidance.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyGuidance.AppLogic
{
    public interface IStudyCourseRepository
    {
        Task<IReadOnlyList<string>> GetAllDiplomasAsync();
        Task<IReadOnlyList<string>> GetAllLocationsAsync();
        Task<IReadOnlyList<StudyCourse>> GetStudyCoursesByRelationAsync(int relationId);
    }
}
