using System.CodeDom;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using Common.Editor.Data.Catalogues;
using Common.Editor.Data.Entities;
using Common.Editor.Data.FileResources;
using GpwEditor.Domain.Models.BaseGame;
using GpwEditor.Domain.Validators;
using GpwEditor.Domain.Validators.BaseGame;
using GpwEditor.Infrastructure.Catalogues.Commentary;
using GpwEditor.Infrastructure.Catalogues.Language;
using GpwEditor.Infrastructure.Entities.BaseGame;
using GpwEditor.Infrastructure.EntityExporters.BaseGame;
using GpwEditor.Infrastructure.EntityImporters.BaseGame;
using GpwEditor.Presentation.Console.DependencyInjection.Output;
using Unity;
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
                         )),
                WithMappings.FromMatchingInterface,
                WithName.Default,
                WithLifetime.ContainerControlled);

            // TODO: Need to find a way to switch on entity, currently hardcoded
            _container.RegisterType<IEntityExporter<IEntity>, CarNumberEntityExporter>();
            _container.RegisterType<IEntityImporter<IEntity>, CarNumberEntityImporter>();
            _container.RegisterType<IEntityExporter<IEntity>, ChassisHandlingEntityExporter>();
            _container.RegisterType<IEntityImporter<IEntity>, ChassisHandlingEntityImporter>();
            _container.RegisterType<IEntityExporter<IEntity>, TeamEntityExporter>();
            _container.RegisterType<IEntityImporter<IEntity>, TeamEntityImporter>();

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
                WithLifetime.Transient);
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
                WithLifetime.Transient);
            _container.RegisterType<IEnumerable<ICommentaryCatalogue>, ICommentaryCatalogue[]>();

            // Register remaining CommentaryCatalogue types
            _container.RegisterType<ICatalogueExporter<CommentaryCatalogueItem>, CommentaryCatalogueExporter>();
            _container.RegisterType<ICatalogueImporter<CommentaryCatalogueItem>, CommentaryCatalogueImporter>();
            _container.RegisterType<ICatalogueReader<CommentaryCatalogueItem>, CommentaryCatalogueReader>();
            _container.RegisterType<ICatalogueWriter<CommentaryCatalogueItem>, CommentaryCatalogueWriter>();
        }
    }
}