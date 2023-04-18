using Newtonsoft.Json;
using SvendeTest60.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace SvendeTest60.Services
{
    public class MessageApiService
    {
        HttpClient _httpClient;
        public string StatusMessage;
        List<UserModel> _users;
        public MessageApiService()
        {
            var baseAddress = GetBaseAdress();
            _httpClient = new() { BaseAddress = new Uri(baseAddress) };
        }

        private string GetBaseAdress()
        {
#if DEBUG
            return DeviceInfo.Platform == DevicePlatform.Android ? "https://svende.elthoro.dk" : "https://svende.elthoro.dk";
#elif RELEASE
                // published address here
                return "https://svende.elthoro.dk";
#endif
        }

        public async Task<List<UserModel>> GetUser()
        {
            _users = new List<UserModel>();
            UserModel userBasicInfo = null;
            try
            {
                //var response = await _httpClient.GetFromJsonAsync<UserBasicInfo>("/svendetest/api/users" );
                //HttpResponseMessage response = await _httpClient.GetAsync("/svendetest/api/users");

                // HttpResponseMessage response = await _httpClient.GetAsync("/svendetest/api/users");
                var content = await _httpClient.GetAsync("/svendetest/api/users");
                _users = JsonConvert.DeserializeObject<List<UserModel>>(await content.Content.ReadAsStringAsync());

                return _users;
                /*if (response.IsSuccessStatusCode)
                {
                    var content = await response.GetStringAsync;
                    //serBasicInfo = JsonSerializer.Deserialize<UserBasicInfo>(content);
                }*/

                /*if (!string.IsNullOrEmpty(response.FullName))
                {
                    StatusMessage = "Login Successful";

                    return JsonConvert.DeserializeObject<UserBasicInfo>(await response.  .FullName.ToString());
                }*/
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                throw;
            }

        }

        public async Task<UserModel> FindUser(string email)
        {
            UserModel userInfo;
            try
            {
                var client = new HttpClient();
                string url = "/svendetest/api/users/search/" + email;
                client.BaseAddress = new Uri(url);

                HttpResponseMessage response = await client.GetAsync(url);
                if(response.IsSuccessStatusCode)
                {
                    string content = response.Content.ReadAsStringAsync().Result;
                    userInfo = JsonConvert.DeserializeObject<UserModel>(content);
                    return userInfo;
                } else
                {
                    return null;
                }
               


              
               
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                throw;
            }
        }


        public async Task<MessageModel> SendMessage(MessageModel messageModel)
        {

            try
            {
                var response = await _httpClient.PostAsJsonAsync("/svendetest/api/message", messageModel);
                if (!string.IsNullOrEmpty(response.Content.ToString()))
                {
                    //StatusMessage = "Login Successful";

                    return JsonConvert.DeserializeObject<MessageModel>(await response.Content.ReadAsStringAsync());
                }
                else
                {
                    //StatusMessage = "Access unsuccessful";
                    return null;
                }
            }
            catch (Exception ex)
            {
                return new MessageModel("", "");
            }


        }

        public async Task<UserMessageModel> SendUserMessage(UserMessageModel userMessageModel)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("/svendetest/api/usermessage", userMessageModel);
                if (!string.IsNullOrEmpty(response.Content.ToString()))
                {
                    //StatusMessage = "Login Successful";

                    return JsonConvert.DeserializeObject<UserMessageModel>(await response.Content.ReadAsStringAsync());
                }
                else
                {
                    //StatusMessage = "Access unsuccessful";
                    return null;
                }
            }
            catch (Exception ex)
            {
                return new UserMessageModel();
            }
        }
    }
}
