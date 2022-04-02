using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MvvmFramework
{
    public class WPFFramework : INotifyPropertyChanged, INotifyDataErrorInfo
    {
        private Dictionary<string, List<string>> errors = new Dictionary<string, List<string>>();

        public event PropertyChangedEventHandler PropertyChanged;
        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;


        public IEnumerable GetErrors(string propertyName)
        {
            if (string.IsNullOrEmpty(propertyName))
            {
                return errors.Values;
            }

            if (!errors.ContainsKey(propertyName))
            {
                return Enumerable.Empty<List<string>>();
            }

            return errors[propertyName];

        }

        public bool HasErrors => errors.Count > 0;

        public void AddError(string error, [CallerMemberName] string propertyName = "")
        {
            RemoveErrors(propertyName);
            AddErrors(new List<string> { error }, propertyName);
        }

       

        private void AddErrors(List<string> list, [CallerMemberName] string propertyName = "")
        {
            errors[propertyName] = list;
            OnErrorsChanged(propertyName);
        }
        
        protected void RemoveErrors([CallerMemberName] string propertyName = "")
        {
            errors.Remove(propertyName);
            OnErrorsChanged(propertyName);
        }

        private void OnErrorsChanged(string propertyName)
        {
            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
        }


        protected void SetValue<T>(ref T property, T value, [CallerMemberName] string propertyName = "")
        {
            if (object.Equals(property, value))
            {
                return;
            }

            property = value;
            OnPropertyChanged(propertyName);
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
