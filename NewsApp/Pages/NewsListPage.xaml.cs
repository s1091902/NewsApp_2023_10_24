using NewsApp.Models;
using NewsApp.Services;

namespace NewsApp.Pages;

public partial class NewsListPage : ContentPage
{
	public List<Article> ArticlesList;
	public NewsListPage(string categoryName)
	{
		InitializeComponent();
		Title = categoryName;
		GetNews(categoryName);
		ArticlesList = new List<Article>();
	}

    public async void GetNews(string name)
    {
		var apiService = new ApiServices();
		var newResult =await apiService.GetNews(name);	
		foreach(var article in newResult.Articles)
		{
			ArticlesList.Add(article);

		}
		CvNews.ItemsSource = ArticlesList;
    }
}