using System;
using System.Windows.Input;

namespace CircleDock
{
    public class DelegateCommand<T> : ICommand
    {
        private bool canExecute;

        public Func<T, bool> CanExecuteFunc { get; set; }
        public Action<T> Action { get; set; }

        public DelegateCommand() { }
        public DelegateCommand(Action<T> action) : this(action, e => true) { }
        public DelegateCommand(Action<T> action, Func<T, bool> canExecuteFunc)
        {
            Action = action;
            CanExecuteFunc = canExecuteFunc;
        }

        public bool CanExecute(object parameter) => Action != null && CanExecuteFunc != null && CanExecuteFunc((T)parameter);
        public void Execute(object parameter)
        {
            Action?.Invoke((T)parameter);

            bool canExec = CanExecute(parameter);

            if (canExec != canExecute)
                CanExecuteChanged?.Invoke(null, new EventArgs());

            canExecute = canExec;
        }

        public event EventHandler CanExecuteChanged;
    }
}
