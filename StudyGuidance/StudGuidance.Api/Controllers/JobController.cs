using Microsoft.AspNetCore.Mvc;
using StudGuidance.Domain.Models;
using StudyGuidance.AppLogic;
using StudyGuidance.Domain;
using StudyGuidance.Domain.Models;
using System.Collections;

namespace StudGuidance.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobController : ControllerBase
    {
        private readonly IJobRepository _jobRepository;
        private readonly IStudyCourseRepository _studyCourseRepository;
        private readonly ITestamonialRepository _testamonialRepository;

        public JobController(IJobRepository jobRepository, IStudyCourseRepository studyCourseRepository, ITestamonialRepository testamonialRepository)
        {
            _jobRepository = jobRepository;
            _studyCourseRepository = studyCourseRepository;
            _testamonialRepository = testamonialRepository;
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

            Testamonial testamonial = await _testamonialRepository.GetTestamonialByJobId(job.JobId);
            IReadOnlyList<StudyCourse> associatedStudyCourses = await _studyCourseRepository.GetStudyCoursesByRelationAsync(job.StudyCourseRelation);
            List<StudyCourseDTO> associatedStudyCoursesDTO = new List<StudyCourseDTO>();

            foreach (StudyCourse course in associatedStudyCourses)
            {
                associatedStudyCoursesDTO.Add(new StudyCourseDTO(course));
            }

            JobDTO jobDTO = new JobDTO(job);
            jobDTO.AssociatedStudyCourses = associatedStudyCoursesDTO;
            if(testamonial != null) 
            {
                jobDTO.Testamonial = testamonial;
            }

            return Ok(jobDTO);
        }

        [HttpPost("jobs/add")]
        public async Task<IActionResult> AddJob([FromBody] JobRequest jobRequest)
        {
            Job job = await _jobRepository.AddJobAsync(jobRequest);
            if (job == null) 
            {
                return NotFound();
            } else
            {
                return Ok(job);
            }
        }

        [HttpPut("jobs/update")]
        public async Task<IActionResult> UpdateJob([FromBody] Job incomingJob)
        {
            Job job = await _jobRepository.ChangeJobAsync(incomingJob);
            if (job == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(job);
            }
        }

        [HttpDelete("jobs/delete/{id}")]
        public async Task<IActionResult> DeleteJob(int id)
        {
            if (await _jobRepository.DeleteJobAsync(id))
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
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
