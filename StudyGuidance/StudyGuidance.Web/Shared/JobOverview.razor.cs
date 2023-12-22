using BlazorBootstrap;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.JSInterop;
using StudyGuidance.Web.ApiClient;
using StudyGuidance.Web.Models;
using System;

namespace StudyGuidance.Web.Shared
{
    public partial class JobOverview : ComponentBase
    {
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        [Inject]
        public IJobApiClient JobApiClient { get; set; }
        [Inject]
        public IQuizApiClient QuizApiClient { get; set; }
        [Parameter]
        public string Name { get; set; }
        public Collapse collapse1 = default!;
        private Boolean showFilterMenu;
        public async Task ShowContentAsync() => await collapse1.ShowAsync();
        public async Task HideContentAsync() => await collapse1.HideAsync();
        public async Task ToggleContentAsync() => await collapse1.ToggleAsync();
        private bool multiselectionTextChoice;
        private string value { get; set; } = "Nothing selected";
        public IEnumerable<string> options { get; set; } = new HashSet<string>();
        public string _immediateText = "";
        public List<Job> jobs = new List<Job>();
        public List<Option> subDomains = new List<Option>();
        public bool showNoJobsMessage;
        public List<Job> FilteredJobs
        {
            get
            {
                if (string.IsNullOrWhiteSpace(_immediateText))
                {
                    return options.Any()
                        ? jobs.Where(job => options.Contains(job.SubDomain.ToUpper())).ToList()
                        : jobs.ToList();
                }
                else
                {
                    return options.Any()
                        ? jobs.Where(job => options.Contains(job.SubDomain.ToUpper()) && job.Name.ToLower().Contains(_immediateText.ToLower())).ToList()
                        : jobs.Where(job => job.Name.ToLower().Contains(_immediateText.ToLower())).ToList();
                }
            }
        }

        protected override void OnParametersSet()
        {
            if (this.Name == "Gustaph")
            {
                this.showFilterMenu = true;
            }
            else
            {
                this.showFilterMenu = false;
            }

            base.OnParametersSet();
        }

        public void GoToJobDetailPage(MouseEventArgs e, int id)
        {
            NavigationManager.NavigateTo($"/jobs/detail/{id}");
        }

        public string GetMultiSelectionText(List<string> selectedValues)
        {
            if (selectedValues.Count == 1)
            {
                return $"{selectedValues.Count} subdomein is geselecteerd";
            }
            else
            {
                return $"{selectedValues.Count} subdomeinen zijn geselecteerd";
            }

        }

        public async Task InvokeOnInitializedAsync()
        {
            await OnInitializedAsync();
        }

        protected override async Task OnInitializedAsync()
        {

            // Get the current URI
            var uri = new Uri(NavigationManager.Uri);

            // Parse query parameters
            var queryParams = System.Web.HttpUtility.ParseQueryString(uri.Query);
            var answersParam = queryParams.Get("answers");
            var workInTeamParam = queryParams.Get("workInTeam");
            var workOnSiteParam = queryParams.Get("workOnSite");
            List<string> answers = new List<string>();
            answers = answersParam?.Split(',').ToList();
            bool workInTeam;
            workInTeam = bool.TryParse(workInTeamParam, out var workInTeamValue) ? workInTeamValue : false;
            bool workOnSite;
            workOnSite = bool.TryParse(workOnSiteParam, out var workOnSiteValue) ? workOnSiteValue : false;

            if (this.Name == "Gustaph")
            {
                jobs = await JobApiClient.GetJobsAsync();
                subDomains = await QuizApiClient.GetAllSubDomains();
            }
            else
            {
                //jobs = await JobApiClient.GetJobsByFilterAsync(filterDomains, false, false);
                jobs = await JobApiClient.GetJobsByFilterAsync(answers, workInTeam, workOnSite);
                subDomains = await QuizApiClient.GetAllSubDomains();
                if (jobs == null || !jobs.Any() || jobs.Count == 0)
                {
                    showNoJobsMessage = true;
                }
                else
                {
                    showNoJobsMessage = false;
                }
            }
        }
    }
}
