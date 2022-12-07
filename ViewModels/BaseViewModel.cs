using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Input;

namespace PassGen.ViewModels
{
    public interface IDelegateCommand : ICommand { void RaiseCanExecuteChanged(); }
    
    public class DelegateCommand : IDelegateCommand
    {
        Action<object> execute;
        Func<object, bool> canExecute;
        public event EventHandler CanExecuteChanged;

        public DelegateCommand(Action<object> execute, Func<object, bool> canExecute)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }
        public DelegateCommand(Action<object> execute)
        {
            this.execute = execute;
            this.canExecute = this.AlwaysCanExecute;
        }
        public void Execute(object param) { execute(param); }
        public bool CanExecute(object param) { return canExecute(param); }
        public void RaiseCanExecuteChanged()
        {
            if (CanExecuteChanged != null) CanExecuteChanged(this, EventArgs.Empty);
        }
        private bool AlwaysCanExecute(object param) { return true; }
    }

    public class Range<T>
    {
        public Range(T min, T max)
        {
            __Min = min;
            __Max = max;
        }
        public bool InRange(T val)
        {
            if (Comparer<T>.Default.Compare(val, __Min) <= 0) return false;
            if (Comparer<T>.Default.Compare(val, __Max) >= 0) return false;
            return true;
        }
        public bool IsOutLowerRange(T val)
        {
            if (Comparer<T>.Default.Compare(val, __Min) <= 0) return false;
            return true;
        }
        public bool IsOutUpperRange(T val)
        {
            if (Comparer<T>.Default.Compare(val, __Max) >= 0) return false;
            return true;
        }
        private T __Min;
        private T __Max;
    }

    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
