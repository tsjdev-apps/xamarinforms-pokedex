using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Pokedex.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TypeChipControl : Frame
    {
        public static BindableProperty TextProperty =
           BindableProperty.Create(nameof(Text), typeof(string),
               typeof(TypeChipControl), string.Empty,
               propertyChanged: (bindable, oldVal, newVal) =>
           {
               var view = (TypeChipControl)bindable;
               view.ChipLabel.Text = (string)newVal;
               view.SetBackgroundColor((string)newVal);
           });

        public string Text
        {
            get => (string)GetValue(TextProperty);
            set => SetValue(TextProperty, value);
        }

        public TypeChipControl()
        {
            InitializeComponent();
        }

        private void SetBackgroundColor(string type)
        {
            switch (type)
            {
                case "normal":
                    BackgroundColor = Color.FromHex("#A8A87D");
                    break;
                case "fire":
                    BackgroundColor = Color.FromHex("#E38444");
                    break;
                case "water":
                    BackgroundColor = Color.FromHex("#708EE9");
                    break;
                case "grass":
                    BackgroundColor = Color.FromHex("#88C760");
                    break;
                case "electric":
                    BackgroundColor = Color.FromHex("#F2D154");
                    break;
                case "ice":
                    BackgroundColor = Color.FromHex("#A4D7D7");
                    break;
                case "fighting":
                    BackgroundColor = Color.FromHex("#B33831");
                    break;
                case "poison":
                    BackgroundColor = Color.FromHex("#96439C");
                    break;
                case "ground":
                    BackgroundColor = Color.FromHex("#DBC175");
                    break;
                case "flying":
                    BackgroundColor = Color.FromHex("#A590EA");
                    break;
                case "psychic":
                    BackgroundColor = Color.FromHex("#E85F88");
                    break;
                case "bug":
                    BackgroundColor = Color.FromHex("#ABB842");
                    break;
                case "rock":
                    BackgroundColor = Color.FromHex("#B5A14B");
                    break;
                case "ghost":
                    BackgroundColor = Color.FromHex("#6D5894");
                    break;
                case "dark":
                    BackgroundColor = Color.FromHex("#6D594A");
                    break;
                case "dragon":
                    BackgroundColor = Color.FromHex("#6A36EF");
                    break;
                case "steel":
                    BackgroundColor = Color.FromHex("#B8B8CE");
                    break;
                case "fairy":
                    BackgroundColor = Color.FromHex("#E8B7BD");
                    break;
                case "shadow":
                    BackgroundColor = Color.FromHex("#6D5894");
                    break;
                default:
                    BackgroundColor = Color.FromHex("#76A497");
                    break;
            }
        }
    }
}