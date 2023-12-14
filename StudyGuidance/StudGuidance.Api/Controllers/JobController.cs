using Microsoft.AspNetCore.Mvc;
using StudGuidance.Api.Models;
using StudyGuidance.AppLogic;
using StudyGuidance.Domain;
using System.Collections;

namespace StudGuidance.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobController : ControllerBase
    {
        private readonly IJobRepository _jobRepository;
        private readonly IStudyCourseRepository _studyCourseRepository;

        public JobController(IJobRepository jobRepository, IStudyCourseRepository studyCourseRepository)
        {
            _jobRepository = jobRepository;
            _studyCourseRepository = studyCourseRepository;
        }

        [HttpGet("jobs")]
        public async Task<IActionResult> GetAllJobs()
        {
            IReadOnlyList<Job> allJobs = await _jobRepository.GetJobsAsync();

            if (allJobs.Count <= 0)
            {
                return NotFound("AllJobs bevat geen inhoud");
            }

            return Ok(allJobs);
        }

        [HttpGet("jobs/detail/{id}")]
        public async Task<IActionResult> GetJobById(int id)
        {
            Job job = await _jobRepository.GetJobByIdAsync(id);

            if (job == null)
            {
                return NotFound("Job niet gevonden");
            }

            IReadOnlyList<StudyCourse> associatedStudyCourses = await _studyCourseRepository.GetStudyCoursesByRelationAsync(job.StudyCourseRelation);
            List<StudyCourseDTO> associatedStudyCoursesDTO = new List<StudyCourseDTO>();

            foreach (StudyCourse course in associatedStudyCourses)
            {
                associatedStudyCoursesDTO.Add(new StudyCourseDTO(course));
            }

            JobDTO jobDTO = new JobDTO(job);
            jobDTO.AssociatedStudyCourses = associatedStudyCoursesDTO;

            return Ok(jobDTO);
        }

        [HttpGet("jobsByFilter")]
        public async Task<IActionResult> GetAllJobsByFilter([FromQuery] List<int> subdomains, [FromQuery] bool workInTeam, [FromQuery] bool workOnSite)
        {
            IReadOnlyList<Job> allJobsByFilter = await _jobRepository.GetJobsByFilterAsync(subdomains, workInTeam, workOnSite);

            if (allJobsByFilter.Count <= 0)
            {
                return NotFound("jobsByFilter bevat geen inhoud");
            }

            return Ok(allJobsByFilter);
        }
    }
}
