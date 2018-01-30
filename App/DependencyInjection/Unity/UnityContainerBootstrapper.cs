using System.Linq;
using App.BaseGameEditor.Data.Catalogues;
using App.BaseGameEditor.Data.Catalogues.Commentary;
using App.BaseGameEditor.Data.Catalogues.Language;
using App.BaseGameEditor.Data.Factories;
using App.BaseGameEditor.Data.FileResources;
using App.BaseGameEditor.Domain.Entities;
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
        public IUnityContainer Register()
        {
            var container = new UnityContainer();

            // Automatic registration
            container.RegisterTypes(
                AllClasses.FromLoadedAssemblies().Where(
                    type => type.Namespace != null &&
                         //!type.Namespace.StartsWith("App.DependencyInjection") &&
                         //!type.Namespace.StartsWith("App.ObjectMapping") &&
                         //!type.Namespace.StartsWith("App.Outputs") &&
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
            container.RegisterType<FileResource>(new TransientLifetimeManager());
            container.RegisterType<LanguageCatalogueValue>(new TransientLifetimeManager());
            container.RegisterType<TeamEntity>(new TransientLifetimeManager());

            // Manual registrations
            container.RegisterType<IOutput, Output.ConsoleOutput>();
            container.RegisterType<BaseGameEditor.Presentation.Outputs.IOutput, ConsoleOutput>();
            container.RegisterType<IMapperService, AutoMapperObjectMapperService>();
            container.RegisterType<IStreamFactory, MemoryStreamFactory>();
            container.RegisterType<ICatalogueExporter<LanguageCatalogueItem>, LanguageCatalogueExporter>();
            container.RegisterType<ICatalogueImporter<LanguageCatalogueItem>, LanguageCatalogueImporter>();
            container.RegisterType<ICatalogueReader<LanguageCatalogueItem>, LanguageCatalogueReader>();
            container.RegisterType<ICatalogueWriter<LanguageCatalogueItem>, LanguageCatalogueWriter>();
            container.RegisterType<ICatalogueExporter<CommentaryCatalogueItem>, CommentaryCatalogueExporter<ILanguagePhrases>>();
            container.RegisterType<ICatalogueImporter<CommentaryCatalogueItem>, CommentaryCatalogueImporter<ILanguagePhrases>>();
            container.RegisterType<ICatalogueReader<CommentaryCatalogueItem>, CommentaryCatalogueReader>();
            container.RegisterType<ICatalogueWriter<CommentaryCatalogueItem>, CommentaryCatalogueWriter>();

            return container;
        }
    }
}