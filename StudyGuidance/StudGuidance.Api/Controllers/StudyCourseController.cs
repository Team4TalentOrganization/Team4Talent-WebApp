using Microsoft.AspNetCore.Mvc;
using StudGuidance.Domain.Models;
using StudyGuidance.AppLogic;
using StudyGuidance.Domain;
using StudyGuidance.Domain.Models;

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

        [HttpGet("studycourse/all")]
        public async Task<IActionResult> GetAllStudycourses()
        {
            IReadOnlyList<StudyCourse> studyCourses = await _studyCourseRepository.GetStudyCoursesAsync();
            List<StudyCourseDTO> studyCourseDTOs = new List<StudyCourseDTO>();
            foreach (StudyCourse studyCourse in studyCourses)
            {
                studyCourseDTOs.Add(new StudyCourseDTO(studyCourse));
            }

            return Ok(studyCourseDTOs);
        }

        [HttpGet("studycourse/{id}")]
        public async Task<IActionResult> GetAllStudycourseById(int id)
        {
            StudyCourse studyCourse = await _studyCourseRepository.GetStudyCourseAsync(id);
            return Ok(new StudyCourseDTO(studyCourse));
        }

        [HttpPost("studycourse/add")]
        public async Task<IActionResult> AddStudycourse([FromBody] StudyCourseRequest studyCourseRequest)
        {
            if (studyCourseRequest != null) 
            {
                StudyCourse studyCourse = await _studyCourseRepository.AddStudyCourseAsync(studyCourseRequest);
                return Ok(new StudyCourseDTO(studyCourse));
            } else
            {
                return NotFound();
            }
        }

        [HttpPut("studycourse/update")]
        public async Task<IActionResult> UpdateStudycourse([FromBody] StudyCourseDTO studyCourseDTO)
        {
            if (studyCourseDTO != null)
            {
                StudyCourse studyCourse = await _studyCourseRepository.ChangeStudyCourseAsync(studyCourseDTO);
                return Ok(new StudyCourseDTO(studyCourse));
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete("studycourse/delete/{id}")]
        public async Task<IActionResult> DeleteStudycourse(int id)
        {
            if (await _studyCourseRepository.DeleteStudyCourseAsync(id))
            {
                return Ok();
            } else
            {
                return NotFound();
            }
        }
    }
}
