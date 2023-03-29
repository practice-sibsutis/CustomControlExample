
using ReactiveUI;
using System.Reactive;

namespace CustomButtonControl.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private string textArea;

        public MainWindowViewModel()
        {
            TextArea = "Empty";
            ButtonCommand = ReactiveCommand.Create<string>(str => TextArea = str);
        }
        public string TextArea
        {
            get => textArea;
            set => this.RaiseAndSetIfChanged(ref textArea, value);
        }
        public ReactiveCommand<string, Unit> ButtonCommand { get; }
    }
}