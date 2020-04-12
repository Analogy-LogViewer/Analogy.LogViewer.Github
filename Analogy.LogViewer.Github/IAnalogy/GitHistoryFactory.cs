using System;
using System.Collections.Generic;
using Analogy.Interfaces;
using Analogy.Interfaces.Factories;

namespace Analogy.LogViewer.Github.IAnalogy
{
    public class GitHistoryFactory : IAnalogyFactory
    {
        internal static Guid Id = new Guid("B842CC0F-AD83-48FB-8394-3189F9A75024");
        public Guid FactoryId => Id;

        public string Title => "Git History";
        public IEnumerable<IAnalogyChangeLog> ChangeLog { get; } = new List<AnalogyChangeLog>
        {
            new AnalogyChangeLog("Initial version",AnalogChangeLogType.None, "Lior Banai",new DateTime(2020, 04, 02))
        };
        public IEnumerable<string> Contributors { get; } = new List<string> { "Lior Banai" };
        public string About { get; } = "Analogy Git History";
    }
}
