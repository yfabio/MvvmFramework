using System;
using System.Windows.Input;

namespace MvvmFramework
{
    public class Command : Request
    {
        private Action CommandAction;

        public Command(Action commandAction, bool canExecute = true)
        {
            CommandAction = commandAction;
            this.canExecute = canExecute;
        }

        public override void Execute(object parameter)
        {
            CommandAction?.Invoke();
        }
    }
}
