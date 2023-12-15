using Microsoft.AspNetCore.Mvc;
using StudGuidance.Domain.Models;
using StudyGuidance.AppLogic;
using StudyGuidance.Domain;
using StudyGuidance.Domain.Models;

namespace StudGuidance.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialController : ControllerBase
    {
        private readonly ITestamonialRepository _testimonialRepository;

        public TestimonialController(ITestamonialRepository testamonialRepository)
        {
            _testimonialRepository = testamonialRepository;
        }

        [HttpGet("testimonials/all")]
        public async Task<IActionResult> GetAllTestimonials()
        {
            IReadOnlyList<Testamonial> testamonials = await _testimonialRepository.GetAllTestamonials();
            List<TestimonialDTO> testimonialDTOs = new List<TestimonialDTO>();
            foreach (Testamonial testamonial in testamonials)
            {
                testimonialDTOs.Add(new TestimonialDTO(testamonial));
            }

            return Ok(testimonialDTOs);
        }

        [HttpGet("testimonial/{id}")]
        public async Task<IActionResult> GetTestimonialById(int id)
        {
            Testamonial testamonial = await _testimonialRepository.GetTestimonialById(id);
            if(testamonial == null)
            {
                return NotFound();
            } else
            {
                return Ok(new TestimonialDTO(testamonial));
            }
        }

        [HttpPut("testimonial/update")]
        public async Task<IActionResult> UpdateTestimonial([FromBody] TestimonialDTO testimonialDTO)
        {
            if (testimonialDTO != null)
            {
                Testamonial testamonial = await _testimonialRepository.ChangeTestimonial(testimonialDTO);
                return Ok(new TestimonialDTO(testamonial));
            }
            else
            {
                return NotFound();
            }
        }
    }
}
