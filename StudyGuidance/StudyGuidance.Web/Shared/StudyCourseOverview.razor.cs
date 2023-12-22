using Microsoft.AspNetCore.Components;
using StudyGuidance.Web.ApiClient;
using StudyGuidance.Web.Models;

namespace StudyGuidance.Web.Shared
{
    public partial class StudyCourseOverview : ComponentBase
    {
        private List<StudyCourse> studyCourses = new List<StudyCourse>();
        StudyCourse? currentStudyCourse;
        StudyCourse newStudyCourse = new StudyCourse();
        private Boolean showEditModal;
        private Boolean showAddModal;

        void OnEditClick(StudyCourse studyCourse)
        {
            currentStudyCourse = studyCourse;
            showEditModal = true;
        }

        async Task OnDeleteClick(StudyCourse studyCourse)
        {
            await StudyCourseApiClient.DeleteStudyCourse(studyCourse.Id);
            studyCourses =  await StudyCourseApiClient.GetStudyCoursesAsync();
        }

        async Task OnSaveClick()
        {
            await StudyCourseApiClient.UpdateStudyCourseAsync(currentStudyCourse!);
            studyCourses = await StudyCourseApiClient.GetStudyCoursesAsync();
            showEditModal = false;
        }

        void OnCloseClick()
        {
            showEditModal = false;
        }

        async Task OnAddStudyCourseSaveClick()
        {
            newStudyCourse.JobRelation = 2;
            await StudyCourseApiClient.AddStudyCourse(newStudyCourse!);
            studyCourses = await StudyCourseApiClient.GetStudyCoursesAsync();
            showAddModal = false;
        }
        void OnCloseStudyCourseModalClick()
        {
            showAddModal = false;
        }

        void OnOpenAddModalClick()
        {
            showAddModal = true;
        }

        void OnHomeClick()
        {
            NavigationManager.NavigateTo("/");
        }

        protected override async Task OnInitializedAsync()
        {
            studyCourses = await StudyCourseApiClient.GetStudyCoursesAsync();
        }
    }
}
