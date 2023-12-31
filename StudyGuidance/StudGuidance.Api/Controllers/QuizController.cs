﻿using Microsoft.AspNetCore.Mvc;
using StudyGuidance.AppLogic;
using StudyGuidance.Domain;

namespace StudGuidance.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuizController : ControllerBase
    {
        private readonly IQuizRepository _questionRepository;
        private readonly IQuestionService _questionModificationService;
        public QuizController(IQuizRepository questionRepository, IQuestionService questionModificationService)
        {
            _questionRepository = questionRepository;
            _questionModificationService = questionModificationService;
        }

        [HttpGet("questions")]
        public async Task<IActionResult> GetAllQuestions()
        {
            IReadOnlyList<Question> allQuestions = await _questionRepository.GetQuestionsAsync();
            allQuestions = _questionModificationService.AddUntilFourOptionsPerQuestion(allQuestions);

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
            allDomainQuestions = _questionModificationService.AddUntilFourOptionsPerQuestion(allDomainQuestions);

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
            allStandardQuizQuestions = _questionModificationService.AddUntilFourOptionsPerQuestion(allStandardQuizQuestions);

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
            allTinderQuizQuestions = _questionModificationService.AddUntilFourOptionsPerQuestion(allTinderQuizQuestions);

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
            allSelectedSubDomains = _questionModificationService.AddUntilFourOptionsPerQuestion(allSelectedSubDomains);

            if (allSelectedSubDomains.Count == 0) 
            { 
                return NotFound("SubDomains bevat geen inhoud");
            }

            return Ok(allSelectedSubDomains);
        }

        [HttpGet("subdomains/all")]
        public async Task<IActionResult> GetAllSubDomainsForFilter()
        {
            IReadOnlyList<Option> allSelectedSubDomains = await _questionRepository.GetSelectedSubDomainsForFilterAsync();

            if (allSelectedSubDomains.Count == 0)
            {
                return NotFound("SubDomains bevat geen inhoud");
            }

            return Ok(allSelectedSubDomains);
        }
    }
}
