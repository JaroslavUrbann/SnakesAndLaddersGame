using System;
using System.Windows.Input;

namespace Base.Command
{
    /// <summary>
    /// EN: Provides common (on <see cref="ICommand"/> based) foundation for creating commands.
    /// CZ: Poskytuje základní implementace rozhraní <see cref="ICommand"/> pro vytváření commandů.
    /// </summary>
    /// <typeparam name="T">
    /// EN: Type of the parameter the command expects.
    /// </typeparam>

    internal abstract class BaseCommand<T> : ICommand
    {
        // EN: Delegate of method that determines whether the command can execute in its current state.
        // CZ: Delegát metody, která určuje zda je možné Command v aktuálním stavu provést.
        protected Predicate<T> _canExecuteDelegate;
        // EN: Handler for event raised when canExecuteDelegate content changes.
        // CZ: Handler události vyvolané kdykoli dojde ke změně stavu canExecuteDelegate.
        protected event EventHandler CanExecuteChangedHandler;
        // EN: Handler for event raised before Execute
        // CZ: Handler události vyvolané před pokusem o spuštění commandu
        protected event EventHandler BeforeExecuteHandler;
        // EN: Handler for event raised right after Execute
        // CZ: Handler události vyvolané po spuštění commandu
        protected event EventHandler AfterExecuteHandler;

        /// <summary>
        /// EN: Constructor
        /// CZ: Základní konstruktor
        /// </summary>
        /// <param name="canExecute">EN: Method that determines whether the command can execute in its current state. / CZ: Kód, který bude proveden při pokusu o ověření spustitelnosti commandu.</param>
        public BaseCommand(Predicate<T> canExecute)
        {
            if (canExecute == null)
            {
                throw new ArgumentNullException("EN: Property canExecute is not set. / CZ: Vlastnost canExecute není nastavena.");
            }
            _canExecuteDelegate = canExecute;
        }

        /// <summary>
        /// EN: Simplified constructor
        /// CZ: Zjednodušený konstruktor
        /// </summary>
        public BaseCommand() : this(DefaultCanExecute) { }

        #region Events

        public event EventHandler CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
                this.CanExecuteChangedHandler += value;
            }

            remove
            {
                CommandManager.RequerySuggested -= value;
                this.CanExecuteChangedHandler -= value;
            }
        }

        public event EventHandler BeforeExecute
        {
            add
            {
                this.BeforeExecuteHandler += value;
            }

            remove
            {
                this.BeforeExecuteHandler -= value;
            }
        }

        public event EventHandler AfterExecute
        {
            add
            {
                this.AfterExecuteHandler += value;
            }

            remove
            {
                this.AfterExecuteHandler -= value;
            }
        }

        protected void OnCanExecuteChanged()
        {
            EventHandler handler = this.CanExecuteChangedHandler;
            if (handler != null)
            {
                handler.Invoke(this, EventArgs.Empty);
            }
            CommandManager.InvalidateRequerySuggested();
        }

        protected void OnBeforeExecute(EventArgs e)
        {
            EventHandler handler = this.BeforeExecuteHandler;
            if (handler != null)
            {
                BeforeExecuteHandler(this, e);
            }
        }

        protected void OnAfterExecute(EventArgs e)
        {
            EventHandler handler = this.AfterExecuteHandler;
            if (handler != null)
            {
                AfterExecuteHandler(this, e);
            }
        }
        #endregion

        /// <summary>
        /// EN: Default method for handling CanExecute
        /// CZ: Standardní metoda pro obsluhu CanExecute
        /// </summary>
        /// <param name="parameter">EN: This parameter is never tested. / CZ: Parametr nemá žádný dopad na výsledek metody.</param>
        /// <returns>EN: Always true, so command will be always executed. CZ: Vždy true, command se provede vždy.</returns>
        protected static bool DefaultCanExecute(T parameter)
        {
            return true;
        }

        /// <summary>
        /// EN: Ddetermines whether the command can execute in its current state.
        /// CZ: Uvádí, zda je možné Command za těchto okolností spustit.
        /// </summary>
        virtual public bool CanExecute(object parameter)
        {
            return this._canExecuteDelegate != null && this._canExecuteDelegate((T)parameter);
        }

        /// <summary>
        /// EN: Executes this command
        /// CZ: Spouští tento command
        /// </summary>
        abstract public void Execute(object parameter);

        virtual public void Destroy()
        {
            this._canExecuteDelegate = _ => false;
        }
    }
}
