using CommunityToolkit.Mvvm.Input;
using SvendeTest60.Services;
using SvendeTest60.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SvendeTest60.ViewModels
{

    public partial class HomeViewModel : BaseViewModel
    {
        private MessageApiService messageApiService;
        public HomeViewModel()
        {
            this.messageApiService = new MessageApiService();
        }


        [RelayCommand]
        async Task MessageOpen()
        {
           
            await Shell.Current.GoToAsync($"//{nameof(MessagePage)}");
        }

        [RelayCommand]
        async Task LogOut()
        {
            await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
        }

        [RelayCommand]
        async Task GoRegister()
        {
            await Shell.Current.GoToAsync($"//{nameof(RegisterPage)}");
        }
    }
}
