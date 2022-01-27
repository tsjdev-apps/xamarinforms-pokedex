using Pokedex.Init;
using Pokedex.Interfaces;
using Pokedex.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Pokedex.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PokemonOverviewControl : ContentView
    {
        public static readonly BindableProperty PokemonDetailProperty
            = BindableProperty.Create(nameof(PokemonDetail), typeof(PokemonDetail), typeof(PokemonOverviewControl));

        public PokemonDetail PokemonDetail
        {
            get => (PokemonDetail)GetValue(PokemonDetailProperty);
            set => SetValue(PokemonDetailProperty, value);
        }

        public PokemonOverviewControl()
        {
            InitializeComponent();
        }

        private async void OnTapped(object sender, System.EventArgs e)
        {
            var view = sender as View;
            if (view == null)
                return;

            // press effect
            var scale = view.Scale;
            await view.ScaleTo(scale * 0.95, 100);
            await view.ScaleTo(scale, 100);

            await Bootstrapper.ServiceProvider
                .GetService<IDialogService>().OpenPokemonDetailsDialogAsync(PokemonDetail);
        }
    }
}