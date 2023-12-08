using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace StudyGuidance.Web.Shared
{
    public partial class HomepageHeroe : ComponentBase
    {
        private MudCarousel<string> _carousel;
        private bool _arrows = false;
        private bool _bullets = true;
        private bool _enableSwipeGesture = true;
        private bool _autocycle = true;
        private IList<string> _source = new List<string>()
        {
            "/images/person1.jpg",
            "/images/person2.jpg",
            "/images/person3.jpg",
        };

        private IList<string> _text = new List<string>()
    {
        "Via Talent-IT Group heb ik mijn droomjob gevonden!",
        "De juiste studierichting? Talent-IT Group heeft me super goed geholpen",
        "De juiste studierichting vinden om je droomjob te doen? Talent-IT Group!",
    };

        public int selectedIndex = 0;
    }
}
