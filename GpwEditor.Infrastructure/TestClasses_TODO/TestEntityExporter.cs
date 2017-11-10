using System;
using Common.Editor.Infrastructure.Entities;

namespace GpwEditor.Infrastructure.TestClasses
{
    public class TestEntityExporter : IEntityExporter
    {
        private readonly TestDataContext _context;

        public TestEntityExporter(TestDataContext context)
        {
            _context = context;
        }

        public void Export(IEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}