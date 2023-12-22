using Microsoft.EntityFrameworkCore;
using StudyGuidance.AppLogic;
using StudyGuidance.Domain;
using StudyGuidance.Domain.Models;

namespace StudyGuidance.Infrastructure
{
    internal class TestamonialRepository : ITestamonialRepository
    {
        StudyGuidanceDbContext _context;

        public TestamonialRepository(StudyGuidanceDbContext context)
        {
            _context = context;
        }

        public async Task<Testamonial> ChangeTestimonial(TestimonialDTO testimonialDTO)
        {
            Testamonial testamonial = await _context.Testamonials.FirstOrDefaultAsync(t => t.Id == testimonialDTO.Id);

            if (testamonial != null)
            {
                testamonial.Id = testimonialDTO.Id;
                testamonial.JobId = testimonialDTO.JobId;
                testamonial.JobTitel = testimonialDTO.JobTitel;
                testamonial.Description = testimonialDTO.Description;
                testamonial.Name = testimonialDTO.Name;

                await _context.SaveChangesAsync();

                return testamonial;
            }
            else
            {
                throw new ArgumentNullException($"job for Testimonial with ID {testimonialDTO.JobId} not found.");
            }
        }

        public async Task<IReadOnlyList<Testamonial>> GetAllTestamonials()
        {
            return await _context.Testamonials.ToListAsync();
        }

        public async Task<Testamonial> GetTestamonialByJobId(int jobId)
        {
            var testamonial = await _context.Testamonials
                .Where(t => t.JobId == jobId)
                .FirstOrDefaultAsync();

            return testamonial == null ? throw new InvalidOperationException($"No testimonial found for JobId {jobId}") : testamonial;
        }

        public async Task<Testamonial> GetTestimonialById(int id)
        {
            return await _context.Testamonials.FindAsync(id);
        }
    }
}
