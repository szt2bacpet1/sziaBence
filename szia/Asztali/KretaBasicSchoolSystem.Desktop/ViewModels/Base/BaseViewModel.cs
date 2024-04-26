using CommunityToolkit.Mvvm.ComponentModel;
using System.Threading.Tasks;


namespace Flyhigh.Desktop.ViewModels.Base
{
    public abstract class BaseViewModel : ObservableObject
    {
        public virtual Task InitializeAsync()
        {
            return Task.CompletedTask;
        }

    }
}
