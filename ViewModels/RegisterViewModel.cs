
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SvendeTest60.Models;
using SvendeTest60.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace SvendeTest60.ViewModels
{
    public partial class RegisterViewModel : BaseViewModel
    {
        [ObservableProperty]
        private string firstname;

        [ObservableProperty]
        private string lastname;

        [ObservableProperty]
        private string email;

        [ObservableProperty]
        private string password;

        [ObservableProperty]
        private string password_repeat;

        [ObservableProperty]
        private string address;

        [ObservableProperty]
        private string zipcode;

        [ObservableProperty]
        private string city;

        [ObservableProperty]
        private string birthdate;

        [ObservableProperty]
        private string picture;

        [ObservableProperty]
        ImageSource image;


        private UserApiService userApiService;


        [RelayCommand]
        async Task GetPicture()
        {
            var result = await FilePicker.PickAsync(new PickOptions
            {
                PickerTitle = "Pick Image please",
                FileTypes = FilePickerFileType.Images

            });
            if (result == null)
                return;
            var stream = await result.OpenReadAsync();
            //ImageSource.FromStream(() => stream);
        }

        [RelayCommand]
        async Task Register()
        {
            if (string.IsNullOrWhiteSpace(Firstname) || string.IsNullOrWhiteSpace(Lastname) || string.IsNullOrWhiteSpace(Password)
                || string.IsNullOrWhiteSpace(Password_repeat)
                )
            {
                await DisplayMessage("Manglende info");
            }
            else
            {
                CityModel cityModel;
                int zipId = 0;
                cityModel = await userApiService.TestZipcode(Zipcode);
                if (cityModel == null)
                {
                    cityModel = new CityModel();
                    cityModel.Name = City;
                    cityModel.zipcode = Zipcode;
                    zipId = await userApiService.InsertCity(cityModel);
                }
                else
                {
                    zipId = cityModel.Id;
                }

                UserModel userModel = new UserModel();
                userModel.FirstName = Firstname;
                userModel.LastName = Lastname;
                userModel.Email = Email;
                userModel.Password = Password;
                userModel.PasswordConfirmed = Password_repeat;
                userModel.Adress = Address;
                if (zipId != 0)
                {
                    userModel.Zipcode_id = zipId;
                }
                else
                {

                }
                // user is always set to normal user when register from the app
                userModel.Role_id = 1;
                // must format the date
                userModel.BirthDate = Birthdate;
                //must find upload
                // userModel.PicturePath = Picture;






            }

        }

        async Task DisplayMessage(string message)
        {
            await Shell.Current.DisplayAlert("Message to user", message, "OK");

        }
    }
}
