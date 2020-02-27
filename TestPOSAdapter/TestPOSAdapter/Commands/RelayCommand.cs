using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestPOSAdapter.Commands
{
    class RelayCommand : RelayCommandGeneric<object>
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the RelayCommand class.
        /// </summary>
        /// <param name="_execute">Whether to execute command.</param>
        public RelayCommand(Action<object> _execute)
            : base(_execute, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RelayCommand" /> class.
        /// </summary>
        /// <param name="_execute">Action to execute</param>
        /// <param name="_canExecute">Whether action can execute</param>
        RelayCommand(Action<object> _execute, Predicate<object> _canExecute)
            : base(_execute, _canExecute)
        {
        }

        #endregion
    }
}
