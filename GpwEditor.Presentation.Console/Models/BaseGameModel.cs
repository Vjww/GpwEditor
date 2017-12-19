using System.Collections.Generic;
using GpwEditor.Domain.Models.BaseGame;

namespace GpwEditor.Presentation.Console.Models
{
    public class BaseGameModel : IModel
    {
        public IEnumerable<ITeamModel> Teams { get; set; }
    }
}