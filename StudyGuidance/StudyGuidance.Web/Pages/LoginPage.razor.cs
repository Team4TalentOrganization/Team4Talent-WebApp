using Microsoft.AspNetCore.Components;

namespace StudyGuidance.Web.Pages
{
    public partial class LoginPage : ComponentBase
    {
        public string email { get; set; }
        public string password { get; set; }
        private bool showError = false;

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        private async void OnLoginFormSubmit()
        {
            if (email == "admin" && password == "admin")
            {
                NavigationManager.NavigateTo("/controlpanel");
            }
            else
            {
                showError = true;
                StateHasChanged();

                await Task.Delay(3000);
                showError = false;
                StateHasChanged();
            }
        }
    }
}