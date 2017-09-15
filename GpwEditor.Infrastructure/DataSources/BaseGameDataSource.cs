using System;
using System.IO;
using GpwEditor.Infrastructure.ConnectionStrings;
using GpwEditor.Infrastructure.Services;

namespace GpwEditor.Infrastructure.DataSources
{
    public class BaseGameDataSource : IDataSource<BaseGameConnectionStrings>
    {
        public StreamService<MemoryStream> GameExecutable { get; }
        public LanguageResourceService EnglishLanguageResource { get; }
        public LanguageResourceService FrenchLanguageResource { get; }
        public LanguageResourceService GermanLanguageResource { get; }
        public CommentaryResourceService EnglishCommentaryResource { get; }
        public CommentaryResourceService FrenchCommentaryResource { get; }
        public CommentaryResourceService GermanCommentaryResource { get; }

        public BaseGameDataSource(
            StreamService<MemoryStream> gameExecutable,
            LanguageResourceService englishLanguageResource,
            LanguageResourceService frenchLanguageResource,
            LanguageResourceService germanLanguageResource,
            CommentaryResourceService englishCommentaryResource,
            CommentaryResourceService frenchCommentaryResource,
            CommentaryResourceService germanCommentaryResource)
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