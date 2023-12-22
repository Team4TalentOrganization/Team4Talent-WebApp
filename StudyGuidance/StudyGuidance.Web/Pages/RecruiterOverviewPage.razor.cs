using Microsoft.AspNetCore.Components;

namespace StudyGuidance.Web.Pages
{
    public partial class RecruiterOverviewPage : ComponentBase
    {
        void OnHomeClick()
        {
            NavigationManager.NavigateTo("/");
        }
    }
}
