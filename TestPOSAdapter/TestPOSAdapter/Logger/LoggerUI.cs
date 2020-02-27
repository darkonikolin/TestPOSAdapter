using TestPOSAdapter.Model;

namespace TestPOSAdapter.Logger
{
    public class LoggerUI
    {
        public delegate void MyEventHandler(string message, UIModelView modelView);
        public static MyEventHandler UIEventHandler { get; set; }

        /// <summary>
        /// Method for UI preview message
        /// </summary>
        /// <param name="message">String to be preview on UI.</param>
        /// <param name="modelView">Type of UI control to be shown.</param>
        public void LogMessage(string message, UIModelView modelView)
        {
            UIEventHandler(message, modelView);
        }
    }
}
