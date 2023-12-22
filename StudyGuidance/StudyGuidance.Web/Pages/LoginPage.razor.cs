using Microsoft.AspNetCore.Components;

namespace StudyGuidance.Web.Pages
{
    public partial class LoginPage : ComponentBase
    {
        public string Email { get; set; }
        public string Password { get; set; }
        private bool _showError = false;

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        private async void OnLoginFormSubmit()
        {
            if (Email == "admin" && Password == "admin")
            {
                NavigationManager.NavigateTo("/controlpanel");
            }
            else
            {
                _showError = true;
                StateHasChanged();

                await Task.Delay(3000);
                _showError = false;
                StateHasChanged();
            }
        }
    }
}