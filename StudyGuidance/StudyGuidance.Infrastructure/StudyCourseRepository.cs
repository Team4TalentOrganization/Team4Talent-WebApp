using Microsoft.EntityFrameworkCore;
using StudGuidance.Domain.Models;
using StudyGuidance.AppLogic;
using StudyGuidance.Domain;
using StudyGuidance.Domain.Models;
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

        public async Task<StudyCourse> GetStudyCourseAsync(int id)
        {
            return await _context.StudyCourses.FindAsync(id);  
        }

        public async Task<StudyCourse> AddStudyCourseAsync(StudyCourseRequest studyCourseRequest)
        {
            StudyCourse studyCourse = new StudyCourse(studyCourseRequest);
            await _context.StudyCourses.AddAsync(studyCourse);
            await _context.SaveChangesAsync();
            return studyCourse;
        }

        public async Task<StudyCourse> ChangeStudyCourseAsync(StudyCourseDTO studyCourseDTO)
        {
            StudyCourse studyCourse = await _context.StudyCourses.FindAsync(studyCourseDTO.Id);

            if (studyCourse != null)
            {
                studyCourse.School = studyCourseDTO.School;
                studyCourse.Study = studyCourseDTO.Study;

                if (Enum.TryParse(studyCourseDTO.DiplomaType, out Diploma diplomaType))
                {
                    studyCourse.DiplomaType = diplomaType;
                }
                else
                {
                    throw new ArgumentException($"Invalid diploma type: {studyCourseDTO.DiplomaType}");
                }

                if (Enum.TryParse(studyCourseDTO.Location, out Location location))
                {
                    studyCourse.Location = location;
                }
                else
                {
                    throw new ArgumentException($"Invalid location: {studyCourseDTO.Location}");
                }

                studyCourse.JobRelation = studyCourseDTO.JobRelation;

                await _context.SaveChangesAsync();

                return studyCourse;
            }
            else
            {
                throw new ArgumentNullException($"Study course with ID {studyCourseDTO.Id} not found.");
            }
        }

        public async Task<bool> DeleteStudyCourseAsync(int id)
        {
            bool studyCourseExists = await _context.StudyCourses.AnyAsync(c => c.Id == id);

            if (studyCourseExists)
            {
                StudyCourse studyCourse = await _context.StudyCourses.FindAsync(id);
                _context.StudyCourses.Remove(studyCourse);
                await _context.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
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

        public async Task<IReadOnlyList<StudyCourse>> GetStudyCoursesAsync()
        {
            return await _context.StudyCourses.ToListAsync<StudyCourse>();
        }
    }
}
