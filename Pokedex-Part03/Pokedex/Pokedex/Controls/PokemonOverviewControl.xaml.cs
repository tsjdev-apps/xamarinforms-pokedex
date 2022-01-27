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
    }
}