using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using MonkeyFinder.Model;
using MonkeyFinder.Services;
using Xamarin.Forms;

[assembly:Dependency(typeof(WebDataService))]
namespace MonkeyFinder.Services
{
    public class WebDataService : IDataService
    {
        public async Task<IEnumerable<Monkey>> GetMonkeysASync()
        {
            var json = await Client.GetStringAsync("https://montemagno.com/monkeys.json");
            var all = Monkey.FromJson(json);
            return all;
        }

        HttpClient httpClient;
        HttpClient Client => httpClient ?? (httpClient = new HttpClient());
    }
}
