using SvendeTest60.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SvendeTest60.ViewModels
{
    public class LoadingViewModel : BaseViewModel
    {
        public LoadingViewModel()
        {
            CheckUserLoginDetails();
        }

        private async void CheckUserLoginDetails()
        {

            // retrieve token from internal storage

            var token = await SecureStorage.GetAsync("Token");


            if (string.IsNullOrEmpty(token))
            {
                await GoToLoginPage();
            }
            else
            {
                /*var jsonToken = new JwtSecurityTokenHandler().ReadToken(token) as JwtSecurityToken;
                
                if(jsonToken.ValidTo < DateTime.UtcNow)
                {
                    SecureStorage.Remove("Token");
                    await GoToLoginPage();
                } else 
                { */
                await GoToMainPage();
                //}
            }

            //evaluate token and decide if valid



            /*string userDetailsStr = Preferences.Get(nameof(App.UserDetails), "");

            if (string.IsNullOrWhiteSpace(userDetailsStr))
            {
                await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
                // navigate to Login Page
            }
            else
            {
                var userInfo = JsonConvert.DeserializeObject<UserBasicInfo>(userDetailsStr);
                App.UserDetails = userInfo;
                //await AppConstant.AddFlyoutMenusDetails();
            }*/
        }

        private async Task GoToLoginPage()
        {

            await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
        }

        private async Task GoToMainPage()
        {
            await Shell.Current.GoToAsync($"//{nameof(HomePage)}");
        }
    }
}
