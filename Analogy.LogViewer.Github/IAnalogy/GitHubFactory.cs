using Analogy.Interfaces;
using Analogy.Interfaces.Factories;
using System;
using System.Collections.Generic;

namespace Analogy.LogViewer.Github.IAnalogy
{
    public class GitHubFactory : IAnalogyFactory
    {
        internal static Guid Id = new Guid("8064229A-2605-42FA-9E72-75444E4AB13F");
        public Guid FactoryId { get; set; } = Id;

        public string Title { get; set; } = "Github";
        public IEnumerable<IAnalogyChangeLog> ChangeLog { get; set; } = new List<AnalogyChangeLog>
        {
            new AnalogyChangeLog("Initial version",AnalogChangeLogType.None, "Lior Banai",new DateTime(2020, 04, 14))
        };
        public IEnumerable<string> Contributors { get; set; } = new List<string> { "Lior Banai" };
        public string About { get; set; } = "Github Info";
    }
}
