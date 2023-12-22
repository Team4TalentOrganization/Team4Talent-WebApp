using StudyGuidance.Domain;
using StudyGuidance.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyGuidance.AppLogic
{
    public interface ITestamonialRepository
    {
        Task<Testamonial> GetTestamonialByJobId(int jobId);
        Task<IReadOnlyList<Testamonial>> GetAllTestamonials();
        Task<Testamonial> GetTestimonialById(int id);
        Task<Testamonial> ChangeTestimonial(TestimonialDTO testimonialDTO);
    }
}
