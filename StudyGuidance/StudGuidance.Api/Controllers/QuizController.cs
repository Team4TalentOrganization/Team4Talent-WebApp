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

        [HttpGet("domainquestions")]
        public async Task<IActionResult> GetAllDomainQuestions()
        {
            IReadOnlyList<Question> allDomainQuestions = await _questionRepository.GetDomainQuestionsAsync();
            allDomainQuestions = _questionModificationService.ModifyQuestions(allDomainQuestions);

            if (allDomainQuestions.Count <= 0)
            {
                return NotFound("AllQuestions bevat geen inhoud");
            }

            return Ok(allDomainQuestions);
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
            IReadOnlyList<Question> allSelectedSubDomains = await _questionRepository.GetSelectedSubDomainsAsync(domainId);
            allSelectedSubDomains = _questionModificationService.ModifyQuestions(allSelectedSubDomains);

            if (allSelectedSubDomains.Count == 0) 
            { 
                return NotFound("SubDomains bevat geen inhoud");
            }

            return Ok(allSelectedSubDomains);
        }
    }
}
