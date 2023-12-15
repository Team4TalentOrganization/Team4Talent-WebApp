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

        private Guid _guid = Guid.NewGuid();
        private string _modalDisplay = "none;";
        private string _modalClass = "";
        private bool _showBackdrop = false;

        public Guid Guid
        {
            get { return _guid; }
            set { _guid = value; }
        }

        public string ModalDisplay
        {
            get { return _modalDisplay; }
            set { _modalDisplay = value; }
        }

        public string ModalClass
        {
            get { return _modalClass; }
            set { _modalClass = value; }
        }

        public bool ShowBackdrop
        {
            get { return _showBackdrop; }
            set { _showBackdrop = value; }
        }

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
