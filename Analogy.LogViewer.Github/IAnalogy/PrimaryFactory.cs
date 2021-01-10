using Analogy.Interfaces;
using Analogy.LogViewer.Github.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace Analogy.LogViewer.Github.IAnalogy
{
    public class PrimaryFactory : Template.PrimaryFactory
    {
        internal static Guid Id = new Guid("8064229A-2605-42FA-9E72-75444E4AB13F");
        public override Guid FactoryId { get; set; } = Id;
        public override string Title { get; set; } = "GitHub2";
        public override IEnumerable<IAnalogyChangeLog> ChangeLog { get; set; } = new List<AnalogyChangeLog>
        {
            new AnalogyChangeLog("Initial version",AnalogChangeLogType.None, "Lior Banai",new DateTime(2020, 04, 14))
        };
        public override IEnumerable<string> Contributors { get; set; } = new List<string> { "Lior Banai" };
        public override string About { get; set; } = "Github Info";
        public override Image? SmallImage { get; set; } = Resources.Git_icon_16x16;
        public override Image? LargeImage { get; set; } = Resources.Git_icon_32x32;

    }
}
