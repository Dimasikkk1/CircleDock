using System;
using System.Windows;

namespace CircleDock.Commands
{
    class CloseMainWindowCommand : DelegateCommand<EventArgs>
    {
        public CloseMainWindowCommand() : base(_ => Application.Current.Shutdown()) { }
    }
}
