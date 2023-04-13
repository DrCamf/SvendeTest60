using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SvendeTest60.Models;
using SvendeTest60.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SvendeTest60.ViewModels
{
    public partial class MessageViewModel : BaseViewModel
    {
        [ObservableProperty]
        private string subject;

        [ObservableProperty]
        private string body;

        [ObservableProperty]
        private string sentid;

        IList<UserModel> users = App.UserBasicInfo;

        public IList<UserModel> Users
        {
            get
            {
                return users;
            }
            set
            {
                users = value;
            }
        }


        private MessageApiService messageApiService;
        public UserModel userBasicInfo;


        public MessageViewModel()
        {
            this.messageApiService = new MessageApiService();

        }

        [RelayCommand]
        async Task MessageSend()
        {

            if (string.IsNullOrWhiteSpace(subject) || string.IsNullOrWhiteSpace(body))
            {
                await DisplayMessage("Manglende info");
            }
            else
            {

                // call api to attempt a login
                var messageModel = new MessageModel(subject, body);

                DateTime timeUtc = DateTime.UtcNow;
                TimeZoneInfo cstZone = TimeZoneInfo.FindSystemTimeZoneById("Romance Standard Time");
                DateTime cstTime = TimeZoneInfo.ConvertTimeFromUtc(timeUtc, cstZone);

                messageModel.Sent_at = cstTime.ToString("yyyy/MM/dd HH:mm:ss");



                var model = await messageApiService.SendMessage(messageModel);
                int messageId = model.Id;

                if (messageId > 0)
                {
                    UserModel userModel;
                    userModel = await messageApiService.FindUser(App.UserInfo.Email);


                    await DisplayMessage(App.UserInfo.Id.ToString());

                    var userMessageModel = new UserMessageModel();
                    userMessageModel.Message_id = messageId;
                    int sentidToInt = int.Parse(sentid);
                    if (sentidToInt == 0)
                    {
                        sentidToInt = 1;
                    }
                    else
                    {
                        sentidToInt--;
                    }
                    userMessageModel.Receive_id = sentidToInt;
                    userMessageModel.Sendt_id = userModel.Id;

                    var usermessage = await messageApiService.SendUserMessage(userMessageModel);

                    body = "";
                    subject = "";
                }


                // await DisplayMessage("Sendt");




                //await Shell.Current.GoToAsync($"//{nameof(HomePage)}");
            }

        }
        async Task FillNames()
        {

            users = await messageApiService.GetUser();


        }

        async Task DisplayMessage(string message)
        {
            await Shell.Current.DisplayAlert("Message to user", message, "OK");

        }
    }
}
