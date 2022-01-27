using Pokedex.Init;
using Pokedex.Interfaces;
using Pokedex.Models;
using Pokedex.Resources;
using Rg.Plugins.Popup.Pages;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Pokedex.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PokemonDetailDialogPage : PopupPage
    {
        public PokemonDetailDialogPage(PokemonDetail pokemonDetail)
        {
            InitializeComponent();

            PokemonDetailId.Text
                = $"#{pokemonDetail.Id:D3}";
            PokemonDetailName.Text
                = pokemonDetail.Name;
            PokemonDetailWeight.Text
                = $"{pokemonDetail.Weight / 10.0} {AppResources.PokemonDetailWeightUnitLabel}";
            PokemonDetailHeight.Text
                = $"{pokemonDetail.Height * 10.0} {AppResources.PokemonDetailHeightUnitLabel}";
            PokemonDetailSprite.Source
                = pokemonDetail.Sprite.Image.Artwork.ImagePath;
            BindableLayout.SetItemsSource(PokemonDetailTypes, pokemonDetail.Types);
        }

        private async void CloseImageOnTapped(object sender, EventArgs e)
        {
            var view = sender as View;
            if (view == null)
                return;

            // press effect
            var scale = view.Scale;
            await view.ScaleTo(scale * 0.8, 100);
            await view.ScaleTo(scale, 100);

            await Bootstrapper.ServiceProvider.GetService<IDialogService>().CloseDialogAsync();
        }
    }
}