using Microsoft.AspNetCore.Mvc;
using StudyGuidance.AppLogic;
using StudyGuidance.Domain;

namespace StudGuidance.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuizController : ControllerBase
    {
        private readonly IQuizRepository _questionRepository;
        public QuizController(IQuizRepository questionRepository)
        {
            _questionRepository = questionRepository;
        }

        [HttpGet("questions")]
        public async Task<IActionResult> GetAllQuestions()
        {
            IReadOnlyList<Question> allQuestions = await _questionRepository.GetQuestionsAsync();

            if(allQuestions.Count <= 0) 
            {
                return NotFound("AllQuestions bevat geen inhoud");
            }

            return Ok(allQuestions);
        }

        [HttpGet("domains")]
        public async Task<IActionResult> GetAllDomains()
        {
            IReadOnlyList<Option> allDomains = await _questionRepository.GetDomainsAsync();

            if(allDomains.Count <= 0)
            {
                return NotFound("AllDomians bevat geen inhoud");
            }

            return Ok(allDomains);
        }

        [HttpGet("subdomains")]
        public async Task<IActionResult> GetAllSubDomains([FromQuery] List<int> domainId)
        {
            IReadOnlyList<Option> allSubDomains = await _questionRepository.GetSubDomainsAsync(domainId);

            if(allSubDomains.Count == 0) 
            { 
                return NotFound("SubDomains bevat geen inhoud");
            }

            return Ok(allSubDomains);
        }

        [HttpGet("jobs")]
        public async Task<IActionResult> GetAllJobs()
        {
            IReadOnlyList<Job> allJobs = await _questionRepository.GetJobsAsync();

            if (allJobs.Count <= 0)
            {
                return NotFound("AllJobs bevat geen inhoud");
            }

            return Ok(allJobs);
        }

        [HttpGet("jobsBySubDomain")]
        public async Task<IActionResult> GetAllJobs([FromQuery] List<string> subdomains)
        {
            IReadOnlyList<Job> allJobsBySubDomain = await _questionRepository.GetJobsBySubDomain(subdomains);

            if (allJobsBySubDomain.Count <= 0)
            {
                return NotFound("AllJobsBySubDomain bevat geen inhoud");
            }

            return Ok(allJobsBySubDomain);
        }
    }
}
