using System;

namespace Base.Command
{
    #region Negenerický bezparametrický command
    /// <summary>
    /// EN: Provides basic (on <see cref="ICommand"/> based) implementation of non-paramtric commands.
    /// CZ: Poskytuje základní implementace rozhraní <see cref="ICommand"/> pro vytváření commandů.
    /// </summary>
    internal class Command : BaseCommand<object>
    {
        protected Action _executeDelegate;

        /// <summary>
        /// CZ: Simplified constructor, where canExecute is always true
        /// CZ: Zjednodušený konstruktor, kde canExecute je vždy pravda
        /// </summary>
        /// <param name="execute">Kód, který bude proveden při zavolání commandu (zadaný přes delegáta nebo lambda metodou).</param>
        public Command(Action execute)
            : this(execute, DefaultCanExecute)
        {
        }

        /// <summary>
        /// EN: Basic constructor
        /// CZ: Základní konstruktor
        /// </summary>
        /// <param name="execute">Kód, který bude proveden při zavolání commndu (zadaný přes delegáta nebo lambda metodou).</param>
        /// <param name="canExecute">Kód, který bude proveden při pokusu o ověření spustitelnosti commandu.</param>

        public Command(Action execute, Predicate<object> canExecute)
            : base(canExecute)
        {
            if (execute == null)
            {
                throw new ArgumentNullException("EN: Property Execute is not set / CZ: Vlastnost Execute není nastavena.");
            }

            this._executeDelegate = execute;
        }

        /// <summary>
        /// EN: Execution of command
        /// CZ: Provedení commandu
        /// </summary>
        /// <param name="parameter">Pro tento jednoduchý command bude parametr zcela ignorován.</param>
        override public void Execute(object parameter)
        {
            OnBeforeExecute(EventArgs.Empty);
            this._executeDelegate();
            OnAfterExecute(EventArgs.Empty);
        }

        public override void Destroy()
        {
            base.Destroy();
            this._executeDelegate = () => { return; };
        }
    }
    #endregion

    #region Generický command s jedním parametrem
    internal class Command<TParameter> : BaseCommand<object>
    {
        protected Action<TParameter> _executeDelegate;

        /// <summary>
        /// EN: Simplified constructor, where canExecute is always true
        /// CZ: Zjednodušený konstruktor, kde canExecute je vždy pravda
        /// </summary>
        /// <param name="execute">Kód, který bude proveden při zavolání commndu (zadaný přes delegáta nebo lambda metodou).</param>
        public Command(Action<TParameter> execute)
            : this(execute, DefaultCanExecute)
        {
        }

        /// <summary>
        /// EN: Basic constructor
        /// CZ: Základní konstruktor
        /// </summary>
        /// <param name="execute">Kód, který bude proveden při zavolání commndu (zadaný přes delegáta nebo lambda metodou).</param>
        /// <param name="canExecute">Kód, který bude proveden při pokusu o ověření spustitelnosti commandu.</param>

        public Command(Action<TParameter> execute, Predicate<object> canExecute)
            : base(canExecute)
        {
            if (execute == null)
            {
                throw new ArgumentNullException("EN: Property Execute is not set / CZ: Vlastnost Execute není nastavena.");
            }

            this._executeDelegate = execute;
        }
        /// <summary>
        /// EN: Execution of command
        /// CZ: Provedení commandu
        /// </summary>
        /// <param name="parameter">EN: Parameter will be given to _executeDelegate method. CZ: Parametr bude předán metodě v _executeDelegate</param>
        override public void Execute(object parameter)
        {
            OnBeforeExecute(EventArgs.Empty);
            this._executeDelegate((TParameter)parameter);
            OnAfterExecute(EventArgs.Empty);
        }

        public override void Destroy()
        {
            base.Destroy();
            this._executeDelegate = _ => { return; };
        }
    }
    #endregion

    #region Generický command se dvěma parametrem
    internal class Command<TParameter1, TParameter2> : BaseCommand<object>
    {
        protected Action<TParameter1, TParameter2> _executeDelegate;

        /// <summary>
        /// EN: Simplified constructor, where canExecute is always true
        /// CZ: Zjednodušený konstruktor, kde canExecute je vždy pravda
        /// </summary>
        /// <param name="execute">Kód, který bude proveden při zavolání commndu (zadaný přes delegáta nebo lambda metodou).</param>
        public Command(Action<TParameter1, TParameter2> execute)
            : this(execute, DefaultCanExecute)
        {
        }

        /// <summary>
        /// EN: Basic constructor
        /// CZ: Základní konstruktor
        /// </summary>
        /// <param name="execute">Kód, který bude proveden při zavolání commndu (zadaný přes delegáta nebo lambda metodou).</param>
        /// <param name="canExecute">Kód, který bude proveden při pokusu o ověření spustitelnosti commandu.</param>

        public Command(Action<TParameter1, TParameter2> execute, Predicate<object> canExecute)
            : base(canExecute)
        {
            if (execute == null)
            {
                throw new ArgumentNullException("EN: Property Execute is not set / CZ: Vlastnost Execute není nastavena.");
            }

            this._executeDelegate = execute;
        }
        /// <summary>
        /// EN: Execution of command
        /// CZ: Provedení commandu
        /// </summary>
        /// <param name="parameter">EN: Parameter will be given to _executeDelegate method. CZ: Parametr bude předán metodě v _executeDelegate</param>
        override public void Execute(object parameters)
        {
            OnBeforeExecute(EventArgs.Empty);
            var values = (object[])parameters;
            this._executeDelegate((TParameter1)values[0], (TParameter2)values[1]);
            OnAfterExecute(EventArgs.Empty);
        }

        public override void Destroy()
        {
            base.Destroy();
            this._executeDelegate = (o, p) => { return; };
        }
    }
    #endregion
}
