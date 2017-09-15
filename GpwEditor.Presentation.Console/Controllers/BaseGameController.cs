using GpwEditor.Application.Services;
using GpwEditor.Presentation.Console.Models;
using GpwEditor.Presentation.Console.Views.BaseGame;

namespace GpwEditor.Presentation.Console.Controllers
{
    public class BaseGameController
    {
        public void Home(BaseGameService application)
        {
            var model = new BaseGameModel
            {
                Teams = application.GetTeams()
            };

            var view = new TeamView();
            view.Display(model);
        }
    }
}