using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using StudyGuidance.Web.ApiClient;
using StudyGuidance.Web.Models;
using System;

namespace StudyGuidance.Web.Shared
{
    public partial class JobDetail : ComponentBase
    {
        [Inject]
        public IJSRuntime JSRuntime { get; set; }
        [Inject]
        public IJobApiClient JobApiClient { get; set; }
        [Parameter]
        public int Id { get; set; }

        public Job Job;

        public async Task InitializeAsync(int id)
        {
            Id = id;
            await OnParametersSetAsync();
        }

        protected override async Task OnParametersSetAsync()
        {
            Job = await JobApiClient.GetJobByIdAsync(Id);
        }

        public async Task GoBackToOverview()
        {
            await JSRuntime.InvokeVoidAsync("history.back");
        }
    }
}
