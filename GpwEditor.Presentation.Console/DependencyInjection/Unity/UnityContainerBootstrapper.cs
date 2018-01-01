using System.Collections.Generic;
using System.IO;
using System.Linq;
using Common.Editor.Data.Catalogues;
using Common.Editor.Data.Entities;
using Common.Editor.Data.FileResources;
using GpwEditor.Domain.Models.BaseGame;
using GpwEditor.Domain.Validators;
using GpwEditor.Domain.Validators.BaseGame;
using GpwEditor.Infrastructure.Catalogues.Commentary;
using GpwEditor.Infrastructure.Catalogues.Language;
using GpwEditor.Infrastructure.EntityExporters.BaseGame;
using GpwEditor.Infrastructure.EntityImporters.BaseGame;
using GpwEditor.Infrastructure.Repositories.BaseGame;
using GpwEditor.Presentation.Console.DependencyInjection.Output;
using Unity;
using Unity.Lifetime;
using Unity.RegistrationByConvention;

namespace GpwEditor.Presentation.Console.DependencyInjection.Unity
{
    public class UnityContainerBootstrapper : IUnityContainerBootstrapper
    {
        private readonly IUnityContainer _container;

        public UnityContainerBootstrapper(IUnityContainer container)
        {
            _container = container;
        }

        public IUnityContainer Register()
        {
            _container.RegisterTypes(
                AllClasses.FromLoadedAssemblies().Where(
                    x => x.Namespace != null &&
                         !x.Namespace.StartsWith("GpwEditor.Presentation.Console.DependencyInjection") &&
                         (
                             x.Namespace.StartsWith("GpwEditor.Presentation.Console") ||
                             x.Namespace.StartsWith("GpwEditor.Application") ||
                             x.Namespace.StartsWith("GpwEditor.Domain") ||
                             x.Namespace.StartsWith("GpwEditor.Infrastructure") ||
                             x.Namespace.StartsWith("Common.Editor.Data")
                         )),                        // Get all types in namespaces that are to be registered
                WithMappings.FromMatchingInterface, // Where the types implement interfaces of the same name (Class : IClass)
                WithName.Default,                   // Type mappings will be unnamed in the container
                WithLifetime.ContainerControlled);  // Container lifetime

            // Registers types that inherit IBaseGameRepository and register array of types for BaseGameRepositoryFactory
            // https://stackoverflow.com/a/27624752
            _container.RegisterTypes(
                AllClasses.FromLoadedAssemblies().Where(type => typeof(IBaseGameRepository).IsAssignableFrom(type)),
                WithMappings.FromAllInterfaces,
                WithName.TypeName,
                WithLifetime.ContainerControlled); // TODO: Verify change from transient to container
            _container.RegisterType<IEnumerable<IBaseGameRepository>, IBaseGameRepository[]>();

            _container.RegisterType<IEntityExporter, CarNumberEntityExporter>();
            _container.RegisterType<IEntityExporter, ChassisHandlingEntityExporter>();
            _container.RegisterType<IEntityExporter, TeamEntityExporter>();

            _container.RegisterType<IEntityImporter, CarNumberEntityImporter>();
            _container.RegisterType<IEntityImporter, ChassisHandlingEntityImporter>();
            _container.RegisterType<IEntityImporter, TeamEntityImporter>();

            // TODO: Need to find a way to switch on language, currently hardcoded
            _container.RegisterType<ILanguagePhrases, EnglishLanguagePhrases>();
            _container.RegisterType<ILanguagePhrases, FrenchLanguagePhrases>();
            _container.RegisterType<ILanguagePhrases, GermanLanguagePhrases>();

            // TODO: Need to find a way to switch on model, currently hardcoded
            _container.RegisterType<IValidator<ITeamModel>, TeamValidator>();

            // TODO: I guess this is where we decide on what stream to use
            _container.RegisterType<IFileResource, FileResource<MemoryStream>>();

            // TODO: I guess this is where we decide on what output to use
            _container.RegisterType<IOutput, ConsoleOutput>();

            RegisterLanguageCatalogueTypes();
            RegisterCommentaryCatalogueTypes();

            return _container;
        }

        private void RegisterLanguageCatalogueTypes()
        {
            // Registers types that inherit ILanguageCatalogue and register array of types for LanguageCatalogueFactory
            // https://stackoverflow.com/a/27624752
            _container.RegisterTypes(
                AllClasses.FromLoadedAssemblies().Where(type => typeof(ILanguageCatalogue).IsAssignableFrom(type)),
                WithMappings.FromAllInterfaces,
                WithName.TypeName,
                WithLifetime.ContainerControlled); // TODO: Verify change from transient to container
            _container.RegisterType<IEnumerable<ILanguageCatalogue>, ILanguageCatalogue[]>();

            // Register remaining LanguageCatalogue types
            _container.RegisterType<ICatalogueExporter<LanguageCatalogueItem>, LanguageCatalogueExporter>();
            _container.RegisterType<ICatalogueImporter<LanguageCatalogueItem>, LanguageCatalogueImporter>();
            _container.RegisterType<ICatalogueReader<LanguageCatalogueItem>, LanguageCatalogueReader>();
            _container.RegisterType<ICatalogueWriter<LanguageCatalogueItem>, LanguageCatalogueWriter>();
        }

        private void RegisterCommentaryCatalogueTypes()
        {
            // Registers types that inherit ICommentaryCatalogue and register array of types for CommentaryCatalogueFactory
            // https://stackoverflow.com/a/27624752
            _container.RegisterTypes(
                AllClasses.FromLoadedAssemblies().Where(type => typeof(ICommentaryCatalogue).IsAssignableFrom(type)),
                WithMappings.FromAllInterfaces,
                WithName.TypeName,
                WithLifetime.ContainerControlled); // TODO: Verify change from transient to container
            _container.RegisterType<IEnumerable<ICommentaryCatalogue>, ICommentaryCatalogue[]>();

            // Register remaining CommentaryCatalogue types
            _container.RegisterType<ICatalogueExporter<CommentaryCatalogueItem>, CommentaryCatalogueExporter>();
            _container.RegisterType<ICatalogueImporter<CommentaryCatalogueItem>, CommentaryCatalogueImporter>();
            _container.RegisterType<ICatalogueReader<CommentaryCatalogueItem>, CommentaryCatalogueReader>();
            _container.RegisterType<ICatalogueWriter<CommentaryCatalogueItem>, CommentaryCatalogueWriter>();
        }
    }
}