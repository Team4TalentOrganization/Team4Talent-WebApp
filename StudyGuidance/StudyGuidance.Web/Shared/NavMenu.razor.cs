using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;

namespace StudyGuidance.Web.Shared
{
    public partial class NavMenu : ComponentBase
    {

        [Inject]
        [Parameter]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        [Parameter]
        public IJSRuntime JSRuntime { get; set; }

        public bool collapseNavMenu = true;

        public string? NavMenuCssClass => collapseNavMenu ? "collapse" : null;

        public string navStyle = "width: 100%; background-color: transparent;";

        public string destinationUrl = String.Empty;

        public void ToggleNavMenu()
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
                NavigationManager.NavigateTo(this.destinationUrl);
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
            NavigationManager.NavigateTo(this.destinationUrl);
        }
    }
}
