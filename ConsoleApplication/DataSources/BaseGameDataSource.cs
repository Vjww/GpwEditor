using System;
using System.IO;
using ConsoleApplication.Infrastructure;
using ConsoleApplication.Services;

namespace ConsoleApplication.DataSources
{
    public class BaseGameDataSource : IDataSource<BaseGameConnectionStrings>
    {
        public IStreamService<MemoryStream> GameExecutable { get; }
        public IStreamService<MemoryStream> EnglishLanguageResource { get; }
        public IStreamService<MemoryStream> FrenchLanguageResource { get; }
        public IStreamService<MemoryStream> GermanLanguageResource { get; }
        public IStreamService<MemoryStream> EnglishCommentaryResource { get; }
        public IStreamService<MemoryStream> FrenchCommentaryResource { get; }
        public IStreamService<MemoryStream> GermanCommentaryResource { get; }

        public BaseGameDataSource(
            IStreamService<MemoryStream> gameExecutable,
            IStreamService<MemoryStream> englishLanguageResource,
            IStreamService<MemoryStream> frenchLanguageResource,
            IStreamService<MemoryStream> germanLanguageResource,
            IStreamService<MemoryStream> englishCommentaryResource,
            IStreamService<MemoryStream> frenchCommentaryResource,
            IStreamService<MemoryStream> germanCommentaryResource)
        {
            if (gameExecutable == null) throw new ArgumentNullException(nameof(gameExecutable));
            if (englishLanguageResource == null) throw new ArgumentNullException(nameof(englishLanguageResource));
            if (frenchLanguageResource == null) throw new ArgumentNullException(nameof(frenchLanguageResource));
            if (germanLanguageResource == null) throw new ArgumentNullException(nameof(germanLanguageResource));
            if (englishCommentaryResource == null) throw new ArgumentNullException(nameof(englishCommentaryResource));
            if (frenchCommentaryResource == null) throw new ArgumentNullException(nameof(frenchCommentaryResource));
            if (germanCommentaryResource == null) throw new ArgumentNullException(nameof(germanCommentaryResource));

            GameExecutable = gameExecutable;
            EnglishLanguageResource = englishLanguageResource;
            FrenchLanguageResource = frenchLanguageResource;
            GermanLanguageResource = germanLanguageResource;
            EnglishCommentaryResource = englishCommentaryResource;
            FrenchCommentaryResource = frenchCommentaryResource;
            GermanCommentaryResource = germanCommentaryResource;
        }

        public void Load(BaseGameConnectionStrings connectionStrings)
        {
            if (connectionStrings == null) throw new ArgumentNullException(nameof(connectionStrings));

            GameExecutable.LoadFromFile(connectionStrings.GameExecutable);
            EnglishLanguageResource.LoadFromFile(connectionStrings.EnglishLanguageResource);
            FrenchLanguageResource.LoadFromFile(connectionStrings.FrenchLanguageResource);
            GermanLanguageResource.LoadFromFile(connectionStrings.GermanLanguageResource);
            EnglishCommentaryResource.LoadFromFile(connectionStrings.EnglishCommentaryResource);
            FrenchCommentaryResource.LoadFromFile(connectionStrings.FrenchCommentaryResource);
            GermanCommentaryResource.LoadFromFile(connectionStrings.GermanCommentaryResource);
        }

        public void Save(BaseGameConnectionStrings connectionStrings)
        {
            if (connectionStrings == null) throw new ArgumentNullException(nameof(connectionStrings));

            GameExecutable.SaveToFile(connectionStrings.GameExecutable);
            EnglishLanguageResource.SaveToFile(connectionStrings.EnglishLanguageResource);
            FrenchLanguageResource.SaveToFile(connectionStrings.FrenchLanguageResource);
            GermanLanguageResource.SaveToFile(connectionStrings.GermanLanguageResource);
            EnglishCommentaryResource.SaveToFile(connectionStrings.EnglishCommentaryResource);
            FrenchCommentaryResource.SaveToFile(connectionStrings.FrenchCommentaryResource);
            GermanCommentaryResource.SaveToFile(connectionStrings.GermanCommentaryResource);
        }
    }
}