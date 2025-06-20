using Newtonsoft.Json;
using SpiralCoreProject.Models;

namespace SpiralCoreProject.Utils
{
    internal static class ApiFetcher
    {
        private static HttpClient? _ApiClient;
        public const string ApiDomain = "https://localhost:5001";
        public static void Setup()
        {
            _ApiClient = new HttpClient();
        }

        public static async Task<IEnumerable<Category>?> FetchMCUs()
        {
            try
            {
                var fetchData = await _ApiClient!.GetAsync($"{ApiDomain}/MCUs");
                fetchData.EnsureSuccessStatusCode();

                var data = await fetchData.Content.ReadAsStringAsync();
                var categories = JsonConvert.DeserializeObject<IEnumerable<Category>>(data);
                return categories;

            }
            catch (HttpRequestException)
            {
                throw;
            }
        }

        public static async Task<CaracteristicsModel?> FetchCaracteristicsByID(string category,int id)
        {
            try
            {
                var fetchData = await _ApiClient!.GetAsync($"{ApiDomain}/MCUs/{category}/{id}");
                fetchData.EnsureSuccessStatusCode();

                var data = await fetchData.Content.ReadAsStringAsync();
                var dataObj = JsonConvert.DeserializeObject<CaracteristicsModel>(data);
                return dataObj;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static async Task<IEnumerable<IGenericModel>?>FetchGenericByCategory(string category)
        {
            try
            {
                var fetchData = await _ApiClient!.GetAsync($"{ApiDomain}/MCUs/{category}?limit=1000");
                fetchData.EnsureSuccessStatusCode();

                var data = await fetchData.Content.ReadAsStringAsync();
                var dataList = JsonConvert.DeserializeObject<IEnumerable<GenericModel>>(data);
                return dataList;
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
