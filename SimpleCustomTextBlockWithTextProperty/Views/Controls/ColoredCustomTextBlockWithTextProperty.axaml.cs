using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;

namespace SimpleCustomTextBlockWithTextProperty.Views.Controls
{
    public class ColoredCustomTextBlockWithTextProperty : TemplatedControl
    {
        public static readonly StyledProperty<string> CustomTextProperty =
            AvaloniaProperty.Register<ColoredCustomTextBlockWithTextProperty, string>("CustomText");

        public string CustomText
        {
            get => GetValue(CustomTextProperty);
            set => SetValue(CustomTextProperty, value);
        }
    }
}
