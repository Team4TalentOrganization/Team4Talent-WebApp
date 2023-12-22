using StudyGuidance.Web.Models;

namespace StudyGuidance.Web.ApiClient
{
    public class StudyCourseApiClient : BaseApiClient, IStudyCourseApiClient
    {

        private string _url = $"https://localhost:7109/api/";

        public StudyCourseApiClient(HttpClient httpClient, ILogger<StudyCourseApiClient> logger) : base(httpClient, logger)
        {
        }

        public async Task AddStudyCourse(StudyCourse studyCourse)
        {
            await PostJsonAsync<StudyCourse>($"{_url}/studycourse/add", studyCourse);
        }

        public async Task DeleteStudyCourse(int id)
        {
            await DeleteJsonAsync($"{_url}/studycourse/delete/{id}");
        }

        public async Task<StudyCourse> GetStudyCourseByIdAsync(int id)
        {
            return await GetJsonAsync<StudyCourse>($"{_url}/studycourse/{id}");
        }

        public async Task<List<StudyCourse>> GetStudyCoursesAsync()
        {
            return await GetJsonAsync<List<StudyCourse>>($"{_url}/studycourse/all");
        }

        public async Task UpdateStudyCourseAsync(StudyCourse studyCourse)
        {
            await PutJsonAsync<StudyCourse>($"{_url}/studycourse/update/", studyCourse);
        }
    }
}
