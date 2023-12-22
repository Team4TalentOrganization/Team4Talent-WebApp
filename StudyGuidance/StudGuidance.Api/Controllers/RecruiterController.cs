using Microsoft.AspNetCore.Mvc;
using StudyGuidance.AppLogic;
using StudyGuidance.Domain;

namespace StudGuidance.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecruiterController : ControllerBase
    {
        private readonly IRecruiterRepository _recruiterRepository;

        public RecruiterController(IRecruiterRepository recruiterRepository)
        {
            _recruiterRepository = recruiterRepository;
        }

        [HttpGet("recruiters")]
        public async Task<IActionResult> GetAllRecruiters()
        {
            IReadOnlyList<Recruiter> allRecruiters = await _recruiterRepository.GetRecruitersAsync();

            if (allRecruiters.Count <= 0)
            {
                return NotFound("AllRecruiters bevat geen inhoud");
            }

            return Ok(allRecruiters);
        }

        [HttpGet("recruiter/{recruiterId}")]
        public async Task<IActionResult> GetRecruiterById(int recruiterId)
        {
            if (await _recruiterRepository.GetRecruiterByIdAsync(recruiterId) != null)
            {
                Recruiter recruiter = await _recruiterRepository.GetRecruiterByIdAsync(recruiterId);
                return Ok(recruiter);
            }
            return NotFound();
        }

        [HttpPut("updaterecruiter/{recruiterId}")]
        public async Task<IActionResult> UpdateRecruiter(int recruiterId, [FromBody] Recruiter recruiter)
        {
            if (await _recruiterRepository.GetRecruiterByIdAsync(recruiterId) == null)
            {
                return NotFound("Recruiter met opgegeven ID bestaat niet");
            }
            await _recruiterRepository.UpdateRecruiterAsync(recruiter);
            return Ok();
        }

        [HttpPost("createrecruiter")]
        public async Task<IActionResult> CreateRecruiter([FromBody] Recruiter recruiter)
        {
            recruiter.RecruiterId = null;
            var createdRecruiter = await _recruiterRepository.AddRecruiter(recruiter);

            return Ok();

        }
        [HttpDelete("deleterecruiter/{recruiterId}")]
        public async Task<IActionResult> DeleteRecruiter(int recruiterId)
        {
            if (await _recruiterRepository.GetRecruiterByIdAsync(recruiterId) != null)
            {
                await _recruiterRepository.DeleteRecruiter(recruiterId);
                return Ok();
            }
            return NotFound();
        }
    }
}
