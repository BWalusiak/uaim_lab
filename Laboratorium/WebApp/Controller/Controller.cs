namespace Controller
{
    using System.Threading.Tasks;
    using Model;
    using Utilities;

    public class Controller : PropertyContainerBase, IController
    {
        public IModel Model { get; }

        public Controller(IEventDispatcher dispatcher, IModel model) : base(dispatcher)
        {
            Model = model;
        }

        public async Task SearchMatchesAsync()
        {
            await Task.Run(SearchMatches);
        }

        public async Task SearchMatchesByNumberAsync()
        {
            await Task.Run(SearchMatchesByNumber);
        }
        
        private void SearchMatches()
        {
            Model.LoadMatches();
        }

        private void SearchMatchesByNumber()
        {
            Model.LoadMatchesByNumber();
        }
    }
}