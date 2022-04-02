using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MvvmFramework
{
    public abstract class AsyncCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private bool isExecuting;

        public bool IsExecuting
        {
            get { return isExecuting; }
            set 
            {
                if (isExecuting != value) 
                {
                    isExecuting = value;
                    OnCanExecuteChanged();
                }
            } 
        }

        private void OnCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, new EventArgs());
        }

        public  bool CanExecute(object parameter)
        {
            return isExecuting;
        }

        public async void Execute(object parameter)
        {
            await ExecuteAsync(parameter);
        }

        public abstract Task ExecuteAsync(object parameter);
        
    }
}
