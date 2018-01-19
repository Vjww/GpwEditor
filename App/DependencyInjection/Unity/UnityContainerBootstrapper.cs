using System.Linq;
using App.BaseGameEditor.Data.Catalogues;
using App.BaseGameEditor.Data.Catalogues.Commentary;
using App.BaseGameEditor.Data.Catalogues.Language;
using App.BaseGameEditor.Data.Factories;
using App.BaseGameEditor.Data.FileResources;
using App.BaseGameEditor.Domain.Repositories;
using App.BaseGameEditor.Infrastructure.Repositories;
using App.BaseGameEditor.Infrastructure.Services;
using App.BaseGameEditor.Presentation.Outputs;
using App.Services;
using Unity;
using Unity.Lifetime;
using Unity.RegistrationByConvention;

namespace App.DependencyInjection.Unity
{
    public class UnityContainerBootstrapper
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
                    type => type.Namespace != null &&
                         !type.Namespace.StartsWith("App.AutoMapper") &&
                         !type.Namespace.StartsWith("App.DependencyInjection") &&
                         !type.Namespace.StartsWith("App.Outputs") &&
                         (
                             type.Namespace.StartsWith("App") ||
                             type.Namespace.StartsWith("App.BaseGameEditor.Presentation") ||
                             type.Namespace.StartsWith("App.BaseGameEditor.Application") ||
                             type.Namespace.StartsWith("App.BaseGameEditor.Domain") ||
                             type.Namespace.StartsWith("App.BaseGameEditor.Infrastructure") ||
                             type.Namespace.StartsWith("App.BaseGameEditor.Data")
                         )),                        // Get all types in namespaces that are to be registered
                WithMappings.FromMatchingInterface, // Where the types implement interfaces of the same name (Class : IClass)
                WithName.Default,                   // And mappings will be left unnamed when registering in the container
                WithLifetime.ContainerControlled);  // And mappings will have container controlled lifetimes

            // Change automatic registrations to have transient lifetimes
            _container.RegisterType<FileResource>(new TransientLifetimeManager());
            _container.RegisterType<LanguageCatalogueValue>(new TransientLifetimeManager());

            // Manual registrations
            _container.RegisterType<BaseGameEditor.Presentation.Outputs.IOutput, ConsoleOutput>();
            _container.RegisterType<IMapperService, AutoMapperObjectMapperService>();
            _container.RegisterType<IStreamFactory, MemoryStreamFactory>();
            _container.RegisterType<ICatalogueExporter<LanguageCatalogueItem>, LanguageCatalogueExporter>();
            _container.RegisterType<ICatalogueImporter<LanguageCatalogueItem>, LanguageCatalogueImporter>();
            _container.RegisterType<ICatalogueReader<LanguageCatalogueItem>, LanguageCatalogueReader>();
            _container.RegisterType<ICatalogueWriter<LanguageCatalogueItem>, LanguageCatalogueWriter>();
            _container.RegisterType<ICatalogueExporter<CommentaryCatalogueItem>, CommentaryCatalogueExporter<ILanguagePhrases>>();
            _container.RegisterType<ICatalogueImporter<CommentaryCatalogueItem>, CommentaryCatalogueImporter<ILanguagePhrases>>();
            _container.RegisterType<ICatalogueReader<CommentaryCatalogueItem>, CommentaryCatalogueReader>();
            _container.RegisterType<ICatalogueWriter<CommentaryCatalogueItem>, CommentaryCatalogueWriter>();

            // TODO: Added for integration test to succeed
            _container.RegisterType<ITeamRepository, TeamRepository>(); // TODO: Maybe a clash domain/data layer

            return _container;
        }
    }
}