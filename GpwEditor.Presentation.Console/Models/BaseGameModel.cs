using System.Collections.Generic;
using GpwEditor.Domain.Objects.BaseGame;

namespace GpwEditor.Presentation.Console.Models
{
    public class BaseGameModel
    {
        public IEnumerable<ITeamObject> Teams { get; set; }
    }
}