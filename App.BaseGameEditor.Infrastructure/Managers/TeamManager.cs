//using System;
//using System.Collections.Generic;
//using System.Linq;
//using App.BaseGameEditor.Domain.Models;
//using App.BaseGameEditor.Domain.Validators;
//using App.BaseGameEditor.Infrastructure.Factories;
//using App.BaseGameEditor.Infrastructure.Mappers;
//using GpwEditor.Infrastructure.DataContexts;

//namespace App.BaseGameEditor.Infrastructure.Managers
//{
//    public class TeamManager
//    {
//        private readonly BaseGameDataContext _dataContext;
//        private readonly IModelValidator<TeamEntity> _validator;

//        public TeamManager(
//            BaseGameDataContext dataContext,
//            IModelValidator<TeamEntity> validator)
//        {
//            _dataContext = dataContext ?? throw new ArgumentNullException(nameof(dataContext));
//            _validator = validator ?? throw new ArgumentNullException(nameof(validator));
//        }

//        public IEnumerable<TeamEntity> GetTeams()
//        {
//            // TODO: Alternative to Automapper, as need to merge three entities into a single model
//            var myTeamModel = new DataContextToTeamModelMapper(_dataContext, new ModelFactory<TeamEntity>());
//            return new List<TeamEntity>
//            {
//                myTeamModel.Map(0),
//                myTeamModel.Map(1),
//                myTeamModel.Map(2),
//                myTeamModel.Map(3),
//                myTeamModel.Map(4),
//                myTeamModel.Map(5),
//                myTeamModel.Map(6),
//                myTeamModel.Map(7),
//                myTeamModel.Map(8),
//                myTeamModel.Map(9),
//                myTeamModel.Map(10)
//            };

//            //// TODO: Crude but works, as assumes all items are of type TeamEntity
//            //var newList = new List<TeamEntity>();
//            //var teams = _dataContext.Teams.Get();
//            //foreach (var entity in teams)
//            //{
//            //    newList.Add((TeamEntity)entity);
//            //}
//            //var newTeams = teams as IEnumerable<TeamEntity>;
//            //return Mapper.Map<IEnumerable<TeamEntity>, IEnumerable<ITeamModel>>(newList);
//        }

//        public IEnumerable<string> SetTeams(IEnumerable<TeamEntity> models)
//        {
//            if (models == null) throw new ArgumentNullException(nameof(models));

//            var validationMessages = new List<string>();

//            var enumerable = models as IList<TeamEntity> ?? models.ToList();
//            foreach (var item in enumerable)
//            {
//                validationMessages.AddRange(item.Validate());
//            }

//            if (validationMessages.Any())
//            {
//                return validationMessages;
//            }

//            // TODO: Shouldn't this map from model to entity?
//            //_dataContext.Teams = (IEnumerable<TeamEntity>)enumerable;
//            _dataContext.Teams = null;

//            return validationMessages;
//        }
//    }
//}