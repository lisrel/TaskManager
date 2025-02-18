using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input; // Add this using directive
using System.Collections.ObjectModel;
using System.ComponentModel;
using static System.Net.Mime.MediaTypeNames;

namespace MauiApp2.ViewModel
{
    public partial class MainViewModel : ObservableObject
    {
        IConnectivity connectivity;
        public MainViewModel(IConnectivity connectivity)
        {
            Items = new ObservableCollection<string>();
            this.connectivity = connectivity;
        }
        [ObservableProperty]
        ObservableCollection<string> items;

        [ObservableProperty]
        string text;

        [RelayCommand]
        async Task Add()
        {
            if(string.IsNullOrWhiteSpace(Text))
            {
                return;
            }
            if(connectivity.NetworkAccess != NetworkAccess.Internet)
            {
                await Shell.Current.DisplayAlert("Internet Reqiured", "Please Check Connection", "OK");
                return;
            }
            items.Add(Text);
            Text = string.Empty;
        }

        [RelayCommand]
        void Delete(string item)
        {
            if(Items.Contains(item))
            {
                Items.Remove(item);
            }   
        }

        [RelayCommand]
        async Task Tap(string s)
        {
            await Shell.Current.GoToAsync($"{nameof(Detail)}?Text={s}");
        }
    }
}
