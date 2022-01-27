using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Pokedex.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoadingControl : ContentView
    {
        public LoadingControl()
        {
            InitializeComponent();
        }
    }
}