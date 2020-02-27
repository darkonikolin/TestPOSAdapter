using System;
using System.Windows.Input;
using TestPOSAdapter.Action;
using TestPOSAdapter.Commands;
using TestPOSAdapter.Logger;
using TestPOSAdapter.Model;

namespace TestPOSAdapter.ViewModel
{
    class POSAdapterViewModel : ViewModelBase
    {
        #region Fields
        /// <summary>
        /// Data processing object.
        /// </summary>
        DataProcessing dataProcessing;

        /// <summary>
        /// Property of MessageUIXML textbox
        /// </summary>
        private string messageUIXML;
        public string MessageUIXML
        {
            get
            {
                return this.messageUIXML;
            }
            set
            {
                this.messageUIXML = value;
                OnPropertyChanged("MessageUIXML");
            }
        }

        /// <summary>
        /// Property of MessageUIJSON textbox
        /// </summary>
        private string messageUIJSON;
        public string MessageUIJSON
        {
            get
            {
                return this.messageUIJSON;
            }
            set
            {
                this.messageUIJSON = value;
                OnPropertyChanged("MessageUIJSON");
            }
        }

        /// <summary>
        /// Property of MessageUIFilterJSON textbox
        /// </summary>
        private string messageUIFilterJSON;
        public string MessageUIFilterJSON
        {
            get
            {
                return this.messageUIFilterJSON;
            }
            set
            {
                this.messageUIFilterJSON = value;
                OnPropertyChanged("MessageUIFilterJSON");
            }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of POSAdapterViewModel class.
        /// </summary>
        public POSAdapterViewModel()
        {
            LoggerUI.UIEventHandler += SetCurrentMessageUI;
        }

        #endregion

        #region Commands

        /// <summary>
        /// Action command.
        /// </summary>
        private RelayCommand actionCommand;

        /// <summary>
        /// Gets action command.
        /// </summary>
        public ICommand ActionCommand
        {
            get
            {
                return this.actionCommand ?? (this.actionCommand = new RelayCommand(param => ActionCommandExecute()));
            }
        }

        /// <summary>
        /// Method for executing action operation.
        /// </summary>
        private void ActionCommandExecute()
        {
            dataProcessing = new DataProcessing();
            dataProcessing.Process(@"C:\zadatak\zadatak.xml");
        }

        /// <summary>
        /// Close command.
        /// </summary>
        private RelayCommand closeCommand;

        /// <summary>
        /// Gets close command.
        /// </summary>
        public ICommand CloseCommand
        {
            get
            {
                return this.closeCommand ?? (this.closeCommand = new RelayCommand(param => CloseCommandExecute()));
            }
        }

        /// <summary>
        /// Method for executing close operation.
        /// </summary>
        private void CloseCommandExecute()
        {
            Environment.Exit(0);
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Method for setting UI message depending on the UI model view type.
        /// </summary>
        /// <param name="message">Message to be shown on UI</param>
        /// <param name="modelView">Type of model view</param>
        private void SetCurrentMessageUI(string message, UIModelView modelView)
        {
            if (modelView == UIModelView.XML)
            {
                MessageUIXML = message;
            }
            else if (modelView == UIModelView.JSON)
            {
                MessageUIJSON = message;
            }
            else if (modelView == UIModelView.Filter)
            {
                MessageUIFilterJSON = message;
            }
        }

        #endregion
    }
}
