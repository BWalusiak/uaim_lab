namespace Controller
{
    using Model;
    using Utilities;

    public static class ControllerFactory
    {
        private static IController _controller;

        public static IController GetController(IEventDispatcher dispatch)
        {
            if (_controller != null)
                return _controller;
            
            var newModel = new Model(dispatch) as IModel;

            IController newController = new Controller(dispatch, newModel);

            _controller = newController;

            return _controller;
        }
    }
}