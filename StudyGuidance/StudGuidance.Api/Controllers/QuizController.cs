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
        private readonly IQuestionModificationService _questionModificationService;
        public QuizController(IQuizRepository questionRepository, IQuestionModificationService questionModificationService)
        {
            _questionRepository = questionRepository;
            _questionModificationService = questionModificationService;
        }

        [HttpGet("questions")]
        public async Task<IActionResult> GetAllQuestions()
        {
            IReadOnlyList<Question> allQuestions = await _questionRepository.GetQuestionsAsync();
            allQuestions = _questionModificationService.ModifyQuestions(allQuestions);

            if (allQuestions.Count <= 0) 
            {
                return NotFound("AllQuestions bevat geen inhoud");
            }

            return Ok(allQuestions);
        }

        [HttpGet("standardquizquestions")]
        public async Task<IActionResult> GetAllStandardQuizQuestions()
        {
            IReadOnlyList<Question> allStandardQuizQuestions = await _questionRepository.GetStandardQuizQuestionsAsync();
            allStandardQuizQuestions = _questionModificationService.ModifyQuestions(allStandardQuizQuestions);

            if (allStandardQuizQuestions.Count <= 0)
            {
                return NotFound("AllStandardQuizQuestions bevat geen inhoud");
            }

            return Ok(allStandardQuizQuestions);
        }

        [HttpGet("tinderquizquestions")]
        public async Task<IActionResult> GetAllTinderQuizQuestions()
        {
            IReadOnlyList<Question> allTinderQuizQuestions = await _questionRepository.GetTinderQuizQuestionsAsync();
            allTinderQuizQuestions = _questionModificationService.ModifyQuestions(allTinderQuizQuestions);

            if (allTinderQuizQuestions.Count <= 0)
            {
                return NotFound("AllTinderQuizQuestions bevat geen inhoud");
            }

            return Ok(allTinderQuizQuestions);
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

        [HttpGet("jobsByFilter")]
        public async Task<IActionResult> GetAllJobsByFilter([FromQuery] List<string> subdomains, [FromQuery] bool workInTeam, [FromQuery] bool workOnSite)
        {
            IReadOnlyList<Job> allJobsByFilter = await _questionRepository.GetJobsByFilterAsync(subdomains, workInTeam, workOnSite);

            if (allJobsByFilter.Count <= 0)
            {
                return NotFound("jobsByFilter bevat geen inhoud");
            }

            return Ok(allJobsByFilter);
        }
    }
}
