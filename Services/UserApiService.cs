using Newtonsoft.Json;
using SvendeTest60.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;


namespace SvendeTest60.Services
{
    public class UserApiService 
    {
        HttpClient _client;
        public string StatusMessage;



        public async Task<AuthResponseModel> Login(LoginModel loginModel)
        {
            try
            {
                AuthResponseModel user;
                var client = new HttpClient();
                string url = "https://svende.elthoro.dk/svendetest/api/login" ;
                client.BaseAddress = new Uri(url);

                HttpResponseMessage response = await client.PostAsJsonAsync<LoginModel>(url, loginModel);
               if(response.IsSuccessStatusCode)
                {
                    string content = response.Content.ReadAsStringAsync().Result;
                    user = JsonConvert.DeserializeObject<AuthResponseModel>(content);
                    StatusMessage = "Access successful";
                    return user;
                }
                else
                {
                    StatusMessage = "Access unsuccessful";
                    return null;
                }
                

                // var response = await _client.PostAsJsonAsync("https://svende.elthoro.dk/svendetest/api/login", loginModel );
                /* if (!string.IsNullOrEmpty(response.Content.ToString()))
                 {
                     StatusMessage = "Login Successful";

                     return JsonConvert.DeserializeObject<AuthResponseModel>(await response.Content.ReadAsStringAsync());
                 }
                 else
                 {
                     StatusMessage = "Access unsuccessful";
                     return null;
                 }*/
                //response.EnsureSuccessStatusCode();

            }
            catch (Exception ex)
            {
                StatusMessage = "Failed to login successfully.";
                return new AuthResponseModel();
            }
        }

        public async Task SetAuthToken()
        {
            var token = await SecureStorage.GetAsync("Token");
            _client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
        }

        public async Task<CityModel> TestZipcode(string zipCode)
        {
            try
            {
                var response = await _client.GetAsync("/city/searchzip/" + zipCode);
                if (!string.IsNullOrEmpty(response.Content.ToString()))
                {
                    //StatusMessage = "Login Successful";

                    return JsonConvert.DeserializeObject<CityModel>(await response.Content.ReadAsStringAsync());
                }
                else
                {
                    StatusMessage = "Unsuccessful";
                    return null;
                }
                //response.EnsureSuccessStatusCode();

            }
            catch (Exception ex)
            {
                StatusMessage = "Failed at task.";
                return new CityModel();
            }
        }

        /// <summary>
        /// insert city model and return the id of the insert
        /// </summary>
        /// <param name="city">City model</param>
        /// <returns>int id</returns>
        public async Task<int> InsertCity(CityModel city)
        {
            try
            {
                var response = await _client.PostAsJsonAsync("/city", city);
                if (!string.IsNullOrEmpty(response.Content.ToString()))
                {
                    //StatusMessage = "Login Successful";

                    return JsonConvert.DeserializeObject<int>(await response.Content.ReadAsStringAsync());
                }
                else
                {
                    StatusMessage = "Unsuccessful";
                    return 0;
                }
                //response.EnsureSuccessStatusCode();
            }
            catch (Exception ex)
            {
                StatusMessage = "Failed at task.";
                return 0;
            }
        }
    }
}
