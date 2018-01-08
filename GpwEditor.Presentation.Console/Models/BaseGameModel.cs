using System.Collections.Generic;
using App.BaseGameEditor.Domain.Models;

namespace GpwEditor.Presentation.Console.Models
{
    public class BaseGameModel : IModel
    {
        public IEnumerable<ITeamModel> Teams { get; set; }
    }
}