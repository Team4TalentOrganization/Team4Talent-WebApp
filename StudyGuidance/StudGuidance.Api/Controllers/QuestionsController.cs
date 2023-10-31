using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudyGuidance.AppLogic;
using StudyGuidance.Domain;

namespace StudGuidance.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionsController : ControllerBase
    {
        private readonly IQuestionRepository _questionRepository;
        public QuestionsController(IQuestionRepository questionRepository)
        {
            _questionRepository = questionRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllQuestions()
        {
            IReadOnlyList<Question> allQuestions = await _questionRepository.GetQuestionsAsync();
            return Ok(allQuestions);
        }
    }
}
