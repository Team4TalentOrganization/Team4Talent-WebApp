using Microsoft.AspNetCore.Components;

namespace StudyGuidance.Web.Shared
{
    public partial class PlayerCards : ComponentBase
    {
        private List<PlayerModel> players = new List<PlayerModel>
    {
        new PlayerModel { Name = "Debbie", Description="Ik heb geen technische achtergrond en ik ben onzeker over welke baan het beste bij me past.", ImagePath = "/images/woman.png", ShowFront = true, ImageStyle = "width: 100%; height: 100%;", HrStyle= "height: 3px; border: none; background-color: white; opacity: revert;", HrStyleBack="height: 0; visibility: hidden; margin: 0;", CardBodyStyle="", DivStyle="" },
        new PlayerModel { Name = "Gustaph", Description="Ik weet wat voor werk ik wil doen en zoek hiervoor een bijpassende studierichting.", ImagePath = "/images/man.png", ShowFront = true, ImageStyle = "width: 100%; height: 100%;", HrStyle= "height: 3px; border: none; background-color: white; opacity: revert;", HrStyleBack="height: 0; visibility: hidden; margin: 0;", CardBodyStyle="", DivStyle="" },
        new PlayerModel { Name = "Ayoub", Description="Ik heb een technische achtergrond maar weet niet welke job bij mij past.", ImagePath = "/images/man2.png", ShowFront = true, ImageStyle = "width: 100%; height: 100%;", HrStyle= "height: 3px; border: none; background-color: white; opacity: revert;", HrStyleBack="height: 0; visibility: hidden; margin: 0;", CardBodyStyle="", DivStyle="" },
    };

        public void FlipCard(PlayerModel player)
        {
            player.ShowFront = !player.ShowFront;
            player.ImageStyle = player.ShowFront
                ? "width: 100%; height: 100%; opacity: 1; transform: translateY(0); transition: opacity 1s ease-in-out, transform 0.5s ease-in-out;"
                : "width: 100%; height: 100%; opacity: 0; transform: translateY(-100%); transition: opacity 1s ease-in-out, transform 0.5s ease-in-out;";
            player.HrStyle = player.ShowFront ? "height: 3px; border: none; background-color: white; opacity: revert;" : "height: 0; visibility: hidden; margin: 0; ";
            player.HrStyleBack = !player.ShowFront ? "height: 3px; border: none; background-color: white; opacity: revert;" : "height: 0; visibility: hidden; margin: 0;";
            player.CardBodyStyle = !player.ShowFront ? "height: 345px;" : "";
            player.DivStyle = player.ShowFront
                ? "width: 100%; height: 100%; opacity: 1; transform: translateY(0); transition: opacity 1s ease-in-out, transform 0.5s ease-in-out;"
                : "width: 100%; height: 100%; opacity: 1; transform: translateY(-100%); transition: opacity 1s ease-in-out, transform 0.5s ease-in-out;";
        }


        public class PlayerModel
        {
            public string Name { get; set; }
            public string ImagePath { get; set; }
            public bool ShowFront { get; set; }
            public string ImageStyle { get; set; }
            public string HrStyle { get; set; }
            public string HrStyleBack { get; set; }
            public string CardBodyStyle { get; set; }
            public string Description { get; set; }
            public string DivStyle { get; set; }
        }
    }
}
