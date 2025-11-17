using Analogy.Interfaces;
using Analogy.Interfaces.DataTypes;
using Analogy.Interfaces.WinForms;
using Analogy.Interfaces.WinForms.DataTypes;
using Analogy.LogViewer.Github.Properties;
using System.Drawing;
using System.Windows.Forms;

namespace Analogy.LogViewer.Github.GitHubActions
{
    public class GitFetchAction : IAnalogyCustomActionWinForms
    {
        public Action Action { get; } = () =>
         {
             var f = new GitOperationsForm();
             f.ShowDialog(Application.OpenForms[0]);
         };
        public Guid Id { get; set; } = new Guid("FD8E1ED1-20DA-4783-87EC-9FAC66422CC1");
        public Image LargeImage { get; set; } = Resources.Git_icon_32x32;
        public Image SmallImage { get; set; } = Resources.Git_icon_16x16;

        public string Title { get; set; } = "Git Fetch";
        public AnalogyCustomActionType Type { get; } = AnalogyCustomActionType.BelongsToProvider;

        public AnalogyToolTip? ToolTip { get; set; } =
            new AnalogyToolTipWithImages("Git", "", "", Resources.Git_icon_16x16, Resources.Git_icon_32x32);
        public Image? GetCustomActionSmallImage() => SmallImage;

        public Image? GetCustomActionLargeImage() => LargeImage;

        public Image? GetCustomActionToolTipSmallImage() => SmallImage;

        public Image? GetCustomActionToolTipLargeImage() => LargeImage;
    }
}