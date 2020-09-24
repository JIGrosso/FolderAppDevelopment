using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FolderApp.Views.Components
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class IconTextButton : ContentView
    {
        public static readonly BindableProperty BoldTextProperty = BindableProperty.Create(nameof(BoldText), typeof(bool), typeof(IconTextButton));

        public bool BoldText
        {
            get { return (bool)GetValue(BoldTextProperty); }
            set { SetValue(BoldTextProperty, value); }
        }

        public static readonly BindableProperty ValueProperty = BindableProperty.Create(nameof(Value), typeof(object), typeof(IconTextButton), null);

        public object Value
        {
            get { return GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }


        public static readonly BindableProperty IconProperty = BindableProperty.Create(nameof(Icon), typeof(string), typeof(IconTextButton), string.Empty);

        public string Icon
        {
            get { return (string)GetValue(IconProperty); }
            set { SetValue(IconProperty, value); }
        }

        public static readonly BindableProperty CommandProperty = BindableProperty.Create(nameof(Command), typeof(ICommand), typeof(IconTextButton), null);

        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }

        public static readonly BindableProperty TextProperty = BindableProperty.Create(nameof(Text), typeof(string), typeof(IconTextButton), string.Empty);

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }        

        protected override void OnPropertyChanged(string propertyName)
        {
            base.OnPropertyChanged(propertyName);

            if (propertyName == CommandProperty.PropertyName)
            {
                TapGestureRecognizer.Command = Command;
            }
            if (propertyName == TextProperty.PropertyName)
            {
                Label.Text = Text;
            }
            if (propertyName == IconProperty.PropertyName)
            {
                IconLabel.Text = Icon;
                if (!string.IsNullOrEmpty(Icon)) IconLabel.IsVisible = true;
                else IconLabel.IsVisible = false;
            }
            if (propertyName == ValueProperty.PropertyName)
            {
                TapGestureRecognizer.CommandParameter = Value;
            }
            if (propertyName == BoldTextProperty.PropertyName)
            {
                if (BoldText) Label.FontAttributes = FontAttributes.Bold;
                else Label.FontAttributes = FontAttributes.None;
            }
        }

        public IconTextButton()
        {
            InitializeComponent();
        }
    }
}