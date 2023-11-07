using Newtonsoft.Json;
using NewsApp.Models;
 


namespace NewsApp.Services
{  



	public class ApiServices
	{
		public async Task<Root> GetNews(string categoryName)
		{
			var httpClient = new HttpClient();
			var response = await httpClient.GetStringAsync($"https://gnews.io/api/v4/top-headlines?category={categoryName.ToLower()}&apikey=a0f69a37feb6ab395c35f77adb0fb207");


			return JsonConvert.DeserializeObject<Root>(response);
		}
	}

}





