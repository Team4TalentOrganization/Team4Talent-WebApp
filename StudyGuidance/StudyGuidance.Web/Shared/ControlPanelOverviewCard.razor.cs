using Microsoft.AspNetCore.Components;
using StudyGuidance.Web.Models;

namespace StudyGuidance.Web.Shared
{
	public partial class ControlPanelOverviewCard : ComponentBase
	{
		private List<OverviewPage> overviewPages = new List<OverviewPage>
		{
			new OverviewPage {PageName = "RECRUITER OVERVIEW PAGE", Description = "Hier kan je recruiters toevoegen, aanpassen of verwijderen.", Path = "/recruiteroverview"},
			new OverviewPage {PageName = "JOB OVERVIEW PAGE", Description = "Hier kan je jobs toevoegen, aanpassen of verwijderen.", Path = "/joboverview"},
			new OverviewPage {PageName = "STUDY COURSE OVERVIEW PAGE", Description = "Hier kan je studierichtingen toevoegen, aanpassen of verwijderen.", Path = "/studycourseoverview"},
			new OverviewPage {PageName = "TESTIMONIAL OVERVIEW PAGE", Description = "Hier kan je getuigenissen toevoegen, aanpassen of verwijderen.", Path="/testimonialoverview" },
		};
	}
}