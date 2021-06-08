namespace BlazorServer.Utilities
{
    using System;
    using global::Utilities;

    public class EventDispatcher : IEventDispatcher
    {
        #region IEventDispatcher

        public void Dispatch(Action eventAction)
        {
        }

        #endregion
    }
}