﻿using Analogy.Interfaces;
using Analogy.Interfaces.DataTypes;
using System.Drawing;
using System.Windows.Forms;

namespace Analogy.LogViewer.Github.GitHubActions
{
    public class GitFetchAction : IAnalogyCustomAction
    {
        public Action Action { get; } = () =>
         {
             var f = new GitOperationsForm();
             f.ShowDialog(Application.OpenForms[0]);
         };
        public Guid Id { get; set; } = new Guid("FD8E1ED1-20DA-4783-87EC-9FAC66422CC1");
        public Image LargeImage { get; set; }
        public Image SmallImage { get; set; }

        public string Title { get; set; } = "Git Fetch";
        public AnalogyCustomActionType Type { get; } = AnalogyCustomActionType.BelongsToProvider;
        public AnalogyToolTip? ToolTip { get; set; }
    }
}