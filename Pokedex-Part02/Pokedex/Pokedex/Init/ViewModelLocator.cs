using Microsoft.Extensions.DependencyInjection;
using Pokedex.ViewModels;

namespace Pokedex.Init
{
public class ViewModelLocator
{
    public OverviewPageViewModel OverviewPageViewModel
        => Bootstrapper.ServiceProvider.GetService<OverviewPageViewModel>();
}
}
