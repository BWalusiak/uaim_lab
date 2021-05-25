namespace Controller
{
    using System.ComponentModel;
    using System.Threading.Tasks;
    using System.Windows.Input;
    using Model;

    public interface IController : INotifyPropertyChanged
    {
        IModel Model { get; }
        
        Task SearchMatchesAsync();

        Task SearchMatchesByNumberAsync();
        
    }
}