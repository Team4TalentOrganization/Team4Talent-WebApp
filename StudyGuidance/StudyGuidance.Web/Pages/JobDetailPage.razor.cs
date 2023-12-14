using Microsoft.AspNetCore.Components;

namespace StudyGuidance.Web.Pages
{
	public partial class JobDetailPage : ComponentBase
	{
		[Parameter]
		public int Id { get; set; }
	}
}
