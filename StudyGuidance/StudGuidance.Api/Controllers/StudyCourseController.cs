using Microsoft.AspNetCore.Mvc;
using StudyGuidance.AppLogic;

namespace StudGuidance.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudyCourseController: ControllerBase
    {
        private readonly IStudyCourseRepository _studyCourseRepository;

        public StudyCourseController(IStudyCourseRepository studyCourseRepository)
        {
            _studyCourseRepository = studyCourseRepository;
        }

        [HttpGet("locations")]
        public async Task<IActionResult> GetAllLocations() 
        {
            return Ok(await _studyCourseRepository.GetAllLocationsAsync());
        }

        [HttpGet("diploma")]
        public async Task<IActionResult> GetAllDiplomas()
        {
            return Ok(await _studyCourseRepository.GetAllDiplomasAsync());
        }
    }
}
