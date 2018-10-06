using System;
using System.ComponentModel;
using System.Windows;

namespace Base.ViewModel
{
    /// <summary>
    /// EN: Provides a basic (on <see cref="INotifyPropertyChanged"/> based) foundation for building ViewModels
    /// CZ: Poskytuje základní implementaci rozhraní <see cref="INotifyPropertyChanged"/> pro vytváření ViewModelů.
    /// </summary>
    internal abstract class BaseViewModel : INotifyPropertyChanged
    {
        public BaseViewModel()
        {

        }

        /// <summary>
        /// EN: Initiates change of property dependencies. <see cref="INotifyPropertyChanged"/>
        /// CZ: Vyvovává změnu všech prvků svázaných s property
        /// </summary>
        public void ChangeProperty(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// EN: Allows calling of method as from main UI thread
        /// CZ: Umožňuje volat metody jakoby z hlavního vlákna aplikace
        /// </summary>
        public static void UiInvoke(Action a)
        {
            Application.Current.Dispatcher.Invoke(a);
        }
    }
}

