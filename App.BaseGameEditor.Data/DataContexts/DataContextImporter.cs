//using System;
//using System.Collections.Generic;
//using Common.Editor.Data.Entities;
//using Common.Editor.Data.Repositories;

//namespace Common.Editor.Data.DataContexts
//{
//    // TODO: Redundant?
//    public class DataContextImporter : IDataContextImporter
//    {
//        private readonly IRepositoryImporter<IEntity> _repositoryImporter;

//        public DataContextImporter(IRepositoryImporter<IEntity> repositoryImporter)
//        {
//            _repositoryImporter = repositoryImporter ?? throw new ArgumentNullException(nameof(repositoryImporter));
//        }

//        public void Import(IList<IRepository> repositories)
//        {
//            if (repositories == null) throw new ArgumentNullException(nameof(repositories));

//            foreach (var repository in repositories)
//            {
//                if (repository.RepositoryCapacity <= 0)
//                {
//                    throw new ArgumentOutOfRangeException(nameof(repository.RepositoryCapacity));
//                }
//            }

//            foreach (var repository in repositories)
//            {
//                //_repositoryImporter.Import(repository);
//            }
//        }
//    }
//}