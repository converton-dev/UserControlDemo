using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;

namespace UserControlDemo.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    [ObservableProperty] public partial ObservableCollection<string> Greetings { get; set; } = [
        "Welcome!",
        "Hello!",
        "Greetings!",
        "Bonjour!",
        "Hola!",
        "Namaste!"
    ];
    
    [ObservableProperty] public partial ObservableCollection<string> Farewells { get; set; } = [
        "Goodbye!",
        "Farewell!",
        "Adios!",
        "I will see you next time!",
        "Have a great day!",
        "Bye!"
    ];
}