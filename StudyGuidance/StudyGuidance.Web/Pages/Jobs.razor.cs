using Microsoft.AspNetCore.Components;

namespace StudyGuidance.Web.Pages
{
    public partial class Jobs : ComponentBase
    {
        [Parameter]
        public string Name { get; set; }
    }
}
