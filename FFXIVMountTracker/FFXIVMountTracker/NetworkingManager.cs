using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using Newtonsoft.Json;
using System.Linq;
using System.Threading.Tasks;

namespace FFXIVMountTracker
{
    class NetworkingManager
    {
        string _url = "https://ffxivcollect.com/api/mounts?name_en_cont=";
        string _singleURL = "https://ffxivcollect.com/api/mounts/";
        HttpClient client = new HttpClient();
        public NetworkingManager()
        { }

        public async Task<List<MountClass>> getMounts(string query)
        {
            string completeURL = _url + query;
            var response = await client.GetAsync(completeURL);

            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                return new List<MountClass>();

            var jsonString = await response.Content.ReadAsStringAsync();
            var dic = JsonConvert.DeserializeObject<Dictionary<string, object>>(jsonString);
            var array = dic.ElementAt(2).Value;
            var listOfMounts = JsonConvert.DeserializeObject<List<MountClass>>(array.ToString());
            return listOfMounts;
        }

        public async Task<MountClass> getMount(int id)
        {
            string completeURL = _singleURL + id;
            var response = await client.GetAsync(completeURL);

            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                return new MountClass();

            var jsonString = await response.Content.ReadAsStringAsync();
            //var dic = JsonConvert.DeserializeObject<Dictionary<string, object>>(jsonString);
            var returnedMount = JsonConvert.DeserializeObject<MountClass>(jsonString);
            return returnedMount;
        }
    }
}
