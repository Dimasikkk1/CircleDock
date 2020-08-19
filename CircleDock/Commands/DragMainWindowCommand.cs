using System.Windows;
using System.Windows.Input;

namespace CircleDock.Commands
{
    class DragMainWindowCommand : DelegateCommand<MouseButtonEventArgs>
    {
        public DragMainWindowCommand() : base(e =>
        {
            if (e.ChangedButton != MouseButton.Left)
                return;

            ((App)Application.Current).MainWindow.DragMove();
        })
        { }
    }
}
