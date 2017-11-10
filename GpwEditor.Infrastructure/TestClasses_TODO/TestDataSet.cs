using System.Collections.Generic;
using Common.Editor.Infrastructure.DataSets;
using Common.Editor.Infrastructure.Entities;

namespace GpwEditor.Infrastructure.TestClasses
{
    public class TestDataSet : DataSetBase
    {
        public TestDataSet(List<IEntity> list, int capacity) : base(list, capacity)
        {
        }
    }
}