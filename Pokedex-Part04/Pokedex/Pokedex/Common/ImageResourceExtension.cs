using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Pokedex.Common
{
    [ContentProperty(nameof(Source))]
    public class ImageResourceExtension : IMarkupExtension
    {
        public string Source { get; set; }

        public object ProvideValue(IServiceProvider serviceProvider)
        {
            if (Source == null)
                return null;

            return ImageSource.FromResource($"Pokedex.Assets.{Source}");
        }
    }
}
