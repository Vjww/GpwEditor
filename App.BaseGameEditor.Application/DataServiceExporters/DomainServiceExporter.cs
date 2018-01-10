using System;

namespace App.BaseGameEditor.Application.DataServiceExporters
{
    public class DomainServiceExporter
    {
        private readonly TeamDomainServiceExporter _teamDomainServiceExporter;

        public DomainServiceExporter(TeamDomainServiceExporter teamDomainServiceExporter)
        {
            _teamDomainServiceExporter = teamDomainServiceExporter ?? throw new ArgumentNullException(nameof(teamDomainServiceExporter));
        }

        public void Export()
        {
            _teamDomainServiceExporter.Export();
        }
    }
}