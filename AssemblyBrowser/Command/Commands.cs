using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AssemblyBrowser.Command
{
    public class Commands : ICommand
    {
        private readonly Action<object> _action;
        private readonly Predicate<object> _canBeExecuting;

        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        public Commands(Action<object> action) : this(action, null) { }

        public Commands(Action<object> action, Predicate<object> predicate)
        {
            _action = action ?? throw new ArgumentNullException("execute");
            _canBeExecuting = predicate;
        }

        public bool CanExecute(object parameter) => _canBeExecuting == null ? true : _canBeExecuting(parameter);

        public void Execute(object parameter) => _action(parameter);
    }
}
