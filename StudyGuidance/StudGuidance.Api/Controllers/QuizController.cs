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
        public QuizController(IQuizRepository questionRepository)
        {
            _questionRepository = questionRepository;
        }

        [HttpGet("questions")]
        public async Task<IActionResult> GetAllQuestions()
        {
            IReadOnlyList<Question> allQuestions = await _questionRepository.GetQuestionsAsync();
            return Ok(allQuestions);
        }

        [HttpGet("domains")]
        public async Task<IActionResult> GetAllDomains()
        {
            IReadOnlyList<Option> allDomains = await _questionRepository.GetDomainsAsync();
            return Ok(allDomains);
        }

        [HttpGet("subdomains")]
        public async Task<IActionResult> GetAllSubDomains([FromQuery] List<int> domainId)
        {
            IReadOnlyList<Option> allSubDomains = await _questionRepository.GetSubDomainsAsync(domainId);

            if(allSubDomains.Count == 0) { 
                return NotFound();
            }

            return Ok(allSubDomains);
        }
    }
}