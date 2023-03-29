using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Interactivity;
using Avalonia.VisualTree;
using System.Linq;

namespace CustomEditableTextBlock.Views.Controls
{
    public class CustomEditableTextBlock : TemplatedControl
    {
        public static readonly StyledProperty<string> CustomTextProperty =
            AvaloniaProperty.Register<CustomEditableTextBlock, string>("CustomText");

        public string CustomText
        {
            get => GetValue(CustomTextProperty);
            set => SetValue(CustomTextProperty, value);
        }

        static CustomEditableTextBlock()
        {
            DoubleTappedEvent.AddClassHandler<CustomEditableTextBlock>(
                (sender, args) => sender.OnDoubleTapped(args));
        }

        protected virtual void OnDoubleTapped(RoutedEventArgs routedEventArgs)
        {
            var descendants = this.GetVisualDescendants();
            var border = descendants.OfType<Border>()
                                    .FirstOrDefault(
                                        control =>
                                        string.IsNullOrEmpty(control.Name) == false &&
                                        control.Name.Equals("textBoxBorder"));
                

            var textBox = descendants.OfType<TextBox>()
                                     .FirstOrDefault(
                                         control =>
                                         string.IsNullOrEmpty(control.Name) == false &&
                                         control.Name.Equals("customTextBox"));

            if (border != null && textBox != null)
            {
                border.IsVisible = true;
                textBox.LostFocus += OnLostFocus;
                textBox.Focus();
            }

            
        }

        protected virtual void OnLostFocus(object? sender, RoutedEventArgs routedEventArgs)
        {
            if(sender is TextBox textBox)
            {
                var border = textBox.GetVisualAncestors()
                    .OfType<Border>()
                    .FirstOrDefault(
                    border =>
                    string.IsNullOrEmpty(border.Name) == false &&
                border.Name.Equals("textBoxBorder"));

                if(border != null)
                {
                    border.IsVisible = false;
                }

                textBox.LostFocus -= OnLostFocus;
            }
        }
    }
}
