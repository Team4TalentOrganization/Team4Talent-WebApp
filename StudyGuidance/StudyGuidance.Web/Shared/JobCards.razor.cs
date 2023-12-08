using Microsoft.AspNetCore.Components;
using StudyGuidance.Web.Models;

namespace StudyGuidance.Web.Shared
{
    public partial class JobCards : ComponentBase
    {
        [Parameter]
        public Job Job { get; set; }
    }
}
