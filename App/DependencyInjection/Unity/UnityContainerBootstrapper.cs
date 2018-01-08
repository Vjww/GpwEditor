using System.Collections.Generic;
using System.Linq;
using App.BaseGameEditor.Application.Output;
using Common.Editor.Data.Catalogues;
using Common.Editor.Data.FileResources;
using App.BaseGameEditor.Data.Catalogues.Commentary;
using App.BaseGameEditor.Data.Catalogues.Language;
using App.BaseGameEditor.Data.Repositories.BaseGame;
using Unity;
using Unity.Lifetime;
using Unity.RegistrationByConvention;

namespace App.DependencyInjection.Unity
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
            // Automatic registration
            _container.RegisterTypes(
                AllClasses.FromLoadedAssemblies().Where(
                    x => x.Namespace != null &&
                         !x.Namespace.StartsWith("App.AutoMapper") &&
                         !x.Namespace.StartsWith("App.DependencyInjection") &&
                         !x.Namespace.StartsWith("App.Output") &&
                         (
                             x.Namespace.StartsWith("App") ||
                             x.Namespace.StartsWith("App.BaseGameEditor.Presentation") ||
                             x.Namespace.StartsWith("App.BaseGameEditor.Application") ||
                             x.Namespace.StartsWith("App.BaseGameEditor.Domain") ||
                             x.Namespace.StartsWith("App.BaseGameEditor.Infrastructure") ||
                             x.Namespace.StartsWith("GpwEditor.Infrastructure") ||
                             x.Namespace.StartsWith("Common.Editor.Data")
                         )),                        // Get all types in namespaces that are to be registered
                WithMappings.FromMatchingInterface, // Where the types implement interfaces of the same name (Class : IClass)
                WithName.Default,                   // And mappings will be left unnamed when registering in the container
                WithLifetime.ContainerControlled);  // And mappings will have container controlled lifetimes

            // Change automatic registrations to have transient lifetimes
            _container.RegisterType<IFileResource, FileResource>(new TransientLifetimeManager());
            _container.RegisterType<ILanguageCatalogueValue, LanguageCatalogueValue>(new TransientLifetimeManager());

            // Manual registrations
            _container.RegisterType<IOutput, ConsoleOutput>();
            RegisterLanguageCatalogueTypes();
            RegisterCommentaryCatalogueTypes();
            RegisterBaseGameRepositoryTypes();

            // TODO: Need to find a way to switch on language, currently hardcoded
            _container.RegisterType<ILanguagePhrases, EnglishLanguagePhrases>();
            _container.RegisterType<ILanguagePhrases, FrenchLanguagePhrases>();
            _container.RegisterType<ILanguagePhrases, GermanLanguagePhrases>();

            return _container;
        }

        private void RegisterBaseGameRepositoryTypes()
        {
            // Registers types that inherit IBaseGameRepository as an array of types for BaseGameRepositoryFactory to consume
            // https://stackoverflow.com/a/27624752
            _container.RegisterTypes(
                AllClasses.FromLoadedAssemblies().Where(type => typeof(IBaseGameRepository).IsAssignableFrom(type)),
                WithMappings.FromAllInterfaces,
                WithName.TypeName,
                WithLifetime.ContainerControlled);
            _container.RegisterType<IEnumerable<IBaseGameRepository>, IBaseGameRepository[]>();
        }

        private void RegisterLanguageCatalogueTypes()
        {
            // Registers types that inherit ILanguageCatalogue as an array of types for LanguageCatalogueFactory to consume
            // https://stackoverflow.com/a/27624752
            _container.RegisterTypes(
                AllClasses.FromLoadedAssemblies().Where(type => typeof(ILanguageCatalogue).IsAssignableFrom(type)),
                WithMappings.FromAllInterfaces,
                WithName.TypeName,
                WithLifetime.ContainerControlled);
            _container.RegisterType<IEnumerable<ILanguageCatalogue>, ILanguageCatalogue[]>();

            // Register remaining LanguageCatalogue related types
            _container.RegisterType<ICatalogueExporter<LanguageCatalogueItem>, LanguageCatalogueExporter>();
            _container.RegisterType<ICatalogueImporter<LanguageCatalogueItem>, LanguageCatalogueImporter>();
            _container.RegisterType<ICatalogueReader<LanguageCatalogueItem>, LanguageCatalogueReader>();
            _container.RegisterType<ICatalogueWriter<LanguageCatalogueItem>, LanguageCatalogueWriter>();
        }

        private void RegisterCommentaryCatalogueTypes()
        {
            // Registers types that inherit ICommentaryCatalogue as an array of types for CommentaryCatalogueFactory to consume
            // https://stackoverflow.com/a/27624752
            _container.RegisterTypes(
                AllClasses.FromLoadedAssemblies().Where(type => typeof(ICommentaryCatalogue).IsAssignableFrom(type)),
                WithMappings.FromAllInterfaces,
                WithName.TypeName,
                WithLifetime.ContainerControlled);
            _container.RegisterType<IEnumerable<ICommentaryCatalogue>, ICommentaryCatalogue[]>();

            // Register remaining CommentaryCatalogue related types
            _container.RegisterType<ICatalogueExporter<CommentaryCatalogueItem>, CommentaryCatalogueExporter>();
            _container.RegisterType<ICatalogueImporter<CommentaryCatalogueItem>, CommentaryCatalogueImporter>();
            _container.RegisterType<ICatalogueReader<CommentaryCatalogueItem>, CommentaryCatalogueReader>();
            _container.RegisterType<ICatalogueWriter<CommentaryCatalogueItem>, CommentaryCatalogueWriter>();
        }
    }
}