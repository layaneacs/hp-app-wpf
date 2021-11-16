using HP.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HP.Services
{
    public class HPService : IHPService<Character>
    {
        private string BaseUrl = "http://hp-api.herokuapp.com/api/";
        public HPService()
        {
           
        }

        public async Task<List<Character>> GetAll()
        {
            string url = $"{BaseUrl}characters";

            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(url);

            string responseText;
            if (response.IsSuccessStatusCode)
            {
                responseText = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<Character>>(responseText);
            }
            
            return await Task.FromResult(new List<Character>());
        }        
    }
}
