using System;
using System.Collections.Generic;
using Analogy.Interfaces;
using Analogy.Interfaces.Factories;
using Analogy.LogViewer.Github.GitHubActions;

namespace Analogy.LogViewer.Github.IAnalogy
{
    public class GitHistoryCustomActionsFactory: IAnalogyCustomActionsFactory
    {
        public Guid FactoryId { get; } = GitHistoryFactory.Id;
        public string Title { get; } = "Git Operations";
        public IEnumerable<IAnalogyCustomAction> Actions { get; }=new List<IAnalogyCustomAction>{new GitFetchAction()};
    }
}
