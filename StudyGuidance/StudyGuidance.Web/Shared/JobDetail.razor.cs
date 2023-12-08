using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using StudyGuidance.Web.Models;

namespace StudyGuidance.Web.Shared
{
    public partial class JobDetail : ComponentBase
    {
        [Parameter]
        public int Id { get; set; }

        private Job Job;


        protected override async Task OnParametersSetAsync()
        {
            Job = await JobApiClient.GetJobByIdAsync(Id);
        }

        private async Task GoBackToOverview()
        {
            await JSRuntime.InvokeVoidAsync("history.back");
        }
    }
}
