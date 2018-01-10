using System;

namespace App.BaseGameEditor.Application.DataServiceImporters
{
    public class DomainServiceImporter
    {
        private readonly TeamDomainServiceImporter _teamDomainServiceImporter;

        public DomainServiceImporter(TeamDomainServiceImporter teamDomainServiceImporter)
        {
            _teamDomainServiceImporter = teamDomainServiceImporter ?? throw new ArgumentNullException(nameof(teamDomainServiceImporter));
        }

        public void Import()
        {
            _teamDomainServiceImporter.Import();
        }
    }
}