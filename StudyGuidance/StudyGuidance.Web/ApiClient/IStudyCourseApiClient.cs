using StudyGuidance.Web.Models;

namespace StudyGuidance.Web.ApiClient
{
    public interface IStudyCourseApiClient
    {
        Task<List<StudyCourse>> GetStudyCoursesAsync();

        Task<StudyCourse> GetStudyCourseByIdAsync(int id);

        Task UpdateStudyCourseAsync(StudyCourse studyCourse);

        Task AddStudyCourse(StudyCourse studyCourse);

        Task DeleteStudyCourse(int id);
    }
}
