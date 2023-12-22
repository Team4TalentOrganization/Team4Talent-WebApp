using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Options;
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

        public Job Job { get; set; }

        public List<string> Locations { get; set; }

        public string LocationValue = "All";

        public List<StudyCourse> FilteredStudyCourse
        {
            get
            {
				if (string.IsNullOrWhiteSpace(LocationValue) || LocationValue.Equals("All", StringComparison.OrdinalIgnoreCase))
				{
                    return Job.AssociatedStudyCourses;
				}
				else
				{
					return Job.AssociatedStudyCourses
				            .Where(course => course.Location.Equals(LocationValue, StringComparison.OrdinalIgnoreCase))
				            .ToList();
				}
			}
        }

        public async Task InitializeAsync(int id)
        {
            Id = id;
            await OnParametersSetAsync();
        }

        protected override async Task OnParametersSetAsync()
        {
            Job = await JobApiClient.GetJobByIdAsync(Id);
            Locations = await JobApiClient.GetLocationsAsync();
            Locations.Add("All");
        }

        public async Task GoBackToOverview()
        {
            await JSRuntime.InvokeVoidAsync("history.back");
        }
    }
}
