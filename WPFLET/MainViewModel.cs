namespace WPFLET
{
    using CommunityToolkit.Mvvm.ComponentModel;
    using CommunityToolkit.Mvvm.Input;
    using System.Security.Cryptography.X509Certificates;
    using System.Windows.Input;

    public class MainViewModel : ObservableObject
    {
        public ICommand SerialClick { get; }

        public MainViewModel() 
        {
            SerialClick = new RelayCommand(Serial);
        }
        
        [RelayCommand]
        public void Serial()
        {
               
        }
    }
}