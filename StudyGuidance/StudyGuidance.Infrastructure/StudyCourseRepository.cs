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
    internal class StudyCourseRepository: IStudyCourseRepository
    {
        private StudyGuidanceDbContext _context;

        public StudyCourseRepository(StudyGuidanceDbContext context)
        {
            _context = context;
        }

        public async Task<IReadOnlyList<string>> GetAllDiplomasAsync()
        {
            return Enum.GetNames(typeof(Diploma)).ToList();
        }

        public async Task<IReadOnlyList<string>> GetAllLocationsAsync()
        {
            return Enum.GetNames(typeof(Location)).ToList();
        }

        public async Task<IReadOnlyList<StudyCourse>> GetStudyCoursesByRelationAsync(int relationId)
        {
            return await _context.StudyCourses.Where(c => c.JobRelation == relationId).ToListAsync<StudyCourse>();
        }
    }
}
