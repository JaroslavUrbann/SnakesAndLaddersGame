using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Command
{
    internal class AsyncCommand : BaseCommand<object>
    {
        public bool IsExecuting { get; protected set; }

        protected Action _executeDelegate;

        public bool isExecuting { get; protected set; }

        /// <summary>
        /// CZ: Simplified constructor, where canExecute is always true
        /// CZ: Zjednodušený konstruktor, kde canExecute je vždy pravda
        /// </summary>
        /// <param name="execute">Kód, který bude proveden při zavolání commandu (zadaný přes delegáta nebo lambda metodou).</param>
        public AsyncCommand(Action execute)
            : this(execute, DefaultCanExecute)
        {
        }

        /// <summary>
        /// EN: Basic constructor
        /// CZ: Základní konstruktor
        /// </summary>
        /// <param name="execute">Kód, který bude proveden při zavolání commndu (zadaný přes delegáta nebo lambda metodou).</param>
        /// <param name="canExecute">Kód, který bude proveden při pokusu o ověření spustitelnosti commandu.</param>
        public AsyncCommand(Action execute, Predicate<object> canExecute)
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
        public override void Execute(object parameter)
        {
            try
            {
                this.isExecuting = true;
                OnBeforeExecute(EventArgs.Empty);

                Task task = Task.Factory.StartNew(() =>
                {
                    this._executeDelegate();
                });
                task.ContinueWith(t =>
                {
                    OnAfterExecute(EventArgs.Empty);
                }, TaskScheduler.FromCurrentSynchronizationContext());
            }
            catch (Exception ex)
            {
                this.OnAfterExecute(new RunWorkerCompletedEventArgs(null, ex, true));
            }
        }
    }
}
