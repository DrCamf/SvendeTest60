using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SvendeTest60.Services
{
    public class BaseService
    {
        HttpClient _httpClient;

        public BaseService()
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
    }
}
