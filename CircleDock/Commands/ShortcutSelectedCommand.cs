using CircleDock.Extensions;
using CircleDock.Models;
using System.Windows.Controls;

namespace CircleDock.Commands
{
    class ShortcutSelectedCommand : DelegateCommand<SelectionChangedEventArgs>
    {
        public ShortcutSelectedCommand() : base((e) =>
        {
            ((Shortcut)e.AddedItems[0]).Execute();
        })
        { }
    }
}
