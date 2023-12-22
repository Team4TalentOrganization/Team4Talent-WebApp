using Microsoft.AspNetCore.Components;
using StudyGuidance.Web.Models;

namespace StudyGuidance.Web.Shared
{
    public partial class JobOverviewAdmin : ComponentBase
    {
        private List<Job> jobs = new List<Job>();
        Job? currentJob;
        Job? newJob = new Job();
        private Boolean showEditModal;
        private Boolean showAddModal;
        private string searchTerm = "";

        void OnEditClick(Job job)
        {
            currentJob = job;
            if (currentJob.TestamonialRequest == null) 
            {
                currentJob.TestamonialRequest = new TestamonialRequest();
            } else
            {
                currentJob.TestamonialRequest.Name = job.TestamonialRequest.Name;
                currentJob.TestamonialRequest.Description = job.TestamonialRequest.Description;
                currentJob.TestamonialRequest.JobTitel = job.TestamonialRequest.JobTitel;
            }
            currentJob.TestamonialRequest = job.TestamonialRequest;
            showEditModal = true;
        }

        async Task OnDeleteClick(Job job)
        {
            await JobApiClient.DeleteJob(job.JobId);
            jobs = await JobApiClient.GetJobsAsync();
        }

        async Task OnSaveClick()
        {
            // Check if Testamonial is null and initialize it
            if (currentJob.TestamonialRequest == null)
            {
                currentJob.TestamonialRequest = new TestamonialRequest();
            }

            // Set Testamonial properties from the input fields
            currentJob.TestamonialRequest.Name = currentJob.TestamonialRequest.Name ?? string.Empty;
            currentJob.TestamonialRequest.Description = currentJob.TestamonialRequest.Description ?? string.Empty;
            currentJob.TestamonialRequest.JobTitel = currentJob.TestamonialRequest.JobTitel ?? string.Empty;

            // Ensure that TestamonialRequest property is set correctly
            currentJob.TestamonialRequest = currentJob.TestamonialRequest;

            // Update the job
            await JobApiClient.UpdateJobAsync(currentJob);

            // Refresh the job list
            jobs = await JobApiClient.GetJobsAsync();

            // Close the modal
            showEditModal = false;
        }

        void OnCloseClick()
        {
            showEditModal = false;
        }

        async Task OnAddJobSaveClick()
        {
            // Check if Testamonial is null and initialize it
            if (newJob.TestamonialRequest == null)
            {
                newJob.TestamonialRequest = new TestamonialRequest();
            }

            // Set Testamonial properties from the input fields
            newJob.TestamonialRequest.Name = newJob.TestamonialRequest.Name ?? string.Empty;
            newJob.TestamonialRequest.Description = newJob.TestamonialRequest.Description ?? string.Empty;
            newJob.TestamonialRequest.JobTitel = newJob.TestamonialRequest.JobTitel ?? string.Empty;

            // Ensure that TestamonialRequest property is set correctly
            newJob.TestamonialRequest = newJob.TestamonialRequest;

            // Add the new job
            await JobApiClient.AddJob(newJob);

            // Refresh the job list
            jobs = await JobApiClient.GetJobsAsync();

            // Close the modal
            showAddModal = false;
        }

        void OnCloseJobModalClick()
        {
            showAddModal = false;
        }

        void OnOpenAddModalClick()
        {
            newJob = new Job();
            newJob.TestamonialRequest = new TestamonialRequest();
            showAddModal = true;
        }

        void OnHomeClick()
        {
            NavigationManager.NavigateTo("/");
        }

        protected override async Task OnInitializedAsync()
        {
            jobs = await JobApiClient.GetJobsAsync();
        }

        protected async Task OnSearch()
        {
            jobs = await JobApiClient.GetJobsAsync(); // Fetch all jobs from the API

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                // Filter jobs based on the search term
                jobs = jobs.Where(job =>
                    job.Name.ToLower().Contains(searchTerm.ToLower()) ||
                    job.Description.ToLower().Contains(searchTerm.ToLower()) ||
                    job.Domain.ToLower().Contains(searchTerm.ToLower())
                ).ToList();
            }
        }
    }
}
