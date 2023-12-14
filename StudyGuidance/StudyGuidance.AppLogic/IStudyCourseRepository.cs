using StudGuidance.Domain.Models;
using StudyGuidance.Domain;
using StudyGuidance.Domain.Models;
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
        Task<StudyCourse> GetStudyCourseAsync(int id);
        Task<IReadOnlyList<StudyCourse>> GetStudyCoursesAsync();
        Task<StudyCourse> AddStudyCourseAsync(StudyCourseRequest studyCourseRequest);
        Task<StudyCourse> ChangeStudyCourseAsync(StudyCourseDTO studyCourseDTO);
        Task<bool> DeleteStudyCourseAsync(int id);
        Task<IReadOnlyList<StudyCourse>> GetStudyCoursesByRelationAsync(int relationId);
    }
}
