namespace Model.Models
{
    using Configuration;
    using Utilities;

    public partial class Model : PropertyContainerBase, IModel
    {
        private readonly ServiceConfiguration _configuration;

        public Model(IEventDispatcher dispatcher, ServiceConfiguration configuration) : base(dispatcher)
        {
            _configuration = configuration;
        }
    }
}