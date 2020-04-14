using Analogy.Interfaces;
using Analogy.Interfaces.Factories;
using System;
using System.Collections.Generic;

namespace Analogy.LogViewer.Github.IAnalogy
{
    public class GitHubFactory : IAnalogyFactory
    {
        internal static Guid Id = new Guid("8064229A-2605-42FA-9E72-75444E4AB13F");
        public Guid FactoryId => Id;

        public string Title => "Github";
        public IEnumerable<IAnalogyChangeLog> ChangeLog { get; } = new List<AnalogyChangeLog>
        {
            new AnalogyChangeLog("Initial version",AnalogChangeLogType.None, "Lior Banai",new DateTime(2020, 04, 14))
        };
        public IEnumerable<string> Contributors { get; } = new List<string> { "Lior Banai" };
        public string About { get; } = "Github Info";
    }
}
