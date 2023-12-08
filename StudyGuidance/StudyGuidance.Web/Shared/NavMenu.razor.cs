using Microsoft.AspNetCore.Components;

namespace StudyGuidance.Web.Shared
{
    public partial class NavMenu : ComponentBase
    {
        private bool collapseNavMenu = true;

        private string? NavMenuCssClass => collapseNavMenu ? "collapse" : null;

        private string navStyle = "width: 100%; background-color: transparent;";

        private string destinationUrl = String.Empty;

        private void ToggleNavMenu()
        {
            collapseNavMenu = !collapseNavMenu;
            navStyle = collapseNavMenu ? "width: 100%; background-color: transparent" : "height: 100vh; background-color: white;";
        }

        public Guid Guid = Guid.NewGuid();
        public string ModalDisplay = "none;";
        public string ModalClass = "";
        public bool ShowBackdrop = false;

        public void Open(string destinationUrl)
        {
            if (NavigationManager.Uri.Contains("/quiz"))
            {
                this.destinationUrl = destinationUrl;
                ModalDisplay = "block;";
                ModalClass = "Show";
                ShowBackdrop = true;
                StateHasChanged();
            }
            else
            {
                this.destinationUrl = destinationUrl;
                UriHelper.NavigateTo(this.destinationUrl);
            }
        }

        public void Close()
        {
            ModalDisplay = "none";
            ModalClass = "";
            ShowBackdrop = false;
            StateHasChanged();
        }

        public void CloseAndRouteTo()
        {
            ModalDisplay = "none";
            ModalClass = "";
            ShowBackdrop = false;
            StateHasChanged();
            UriHelper.NavigateTo(this.destinationUrl);
        }
    }
}
