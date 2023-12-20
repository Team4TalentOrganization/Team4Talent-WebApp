using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.JSInterop;
using StudyGuidance.Domain;
using StudyGuidance.Web.ApiClient;
using StudyGuidance.Web.Models;
using Recruiter = StudyGuidance.Web.Models.Recruiter;


namespace StudyGuidance.Web.Shared
{
    public partial class RecruiterOverview : ComponentBase
    {
        private List<Recruiter> recruiters = new List<Recruiter>();
        Recruiter? currentRecruiter;
        Recruiter? newRecruiter = new Recruiter();
        private Boolean showEditModal;
        private Boolean showAddModal;

        void OnEditClick(Recruiter recruiter)
        {
            currentRecruiter = recruiter;
            showEditModal = true;
        }

        async Task OnDeleteClick(Recruiter recruiter)
        {
            await RecruiterApiClient.DeleteRecruiter(recruiter.RecruiterId);
            recruiters = await RecruiterApiClient.GetRecruitersAsync();
        }

        async Task OnSaveClick()
        {
            await RecruiterApiClient.UpdateRecruiterAsync(currentRecruiter!);
            recruiters = await RecruiterApiClient.GetRecruitersAsync();
            showEditModal = false;
        }

        void OnCloseClick()
        {
            showEditModal = false;
        }

        async Task OnAddRecruiterSaveClick()
        {
            await RecruiterApiClient.AddRecruiter(newRecruiter!);
            recruiters = await RecruiterApiClient.GetRecruitersAsync();
            showAddModal = false;
        }
        void OnCloseRecruiterModalClick()
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
            recruiters = await RecruiterApiClient.GetRecruitersAsync();
        }
    }
}
