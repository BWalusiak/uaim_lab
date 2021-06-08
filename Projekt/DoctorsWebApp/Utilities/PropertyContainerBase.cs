namespace Utilities
{
    using System;
    using System.ComponentModel;

    public class PropertyContainerBase : INotifyPropertyChanged
    {
        private readonly IEventDispatcher dispatcher;

        protected PropertyContainerBase(IEventDispatcher dispatcher)
        {
            this.dispatcher = dispatcher;
        }

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        protected void RaisePropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler == null)
                return;
            var args = new PropertyChangedEventArgs(propertyName);
            Action action = () => handler(this, args);
            dispatcher.Dispatch(action);
        }
    }
}