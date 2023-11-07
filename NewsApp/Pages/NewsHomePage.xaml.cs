using Newtonsoft.Json;
using NewsApp.Models;
using NewsApp.Services;

namespace NewsApp.Pages;

public partial class NewsHomePage : ContentPage
{
	public List<Article> ArticlesList;
    //private List<Article> ArticlelesList;
    public List<Cateory> CategoryList = new List<Cateory>()
    {
        new Cateory(){Name="World", ImageUrl = "world.png"},
        new Cateory(){Name = "Nation" , ImageUrl="nation.png"},
        new Cateory(){Name = "Business" , ImageUrl="business.png"},
        new Cateory(){Name = "Technology" , ImageUrl="technology.png"},
        new Cateory(){Name = "Entertainment", ImageUrl = "entertainment.png"},
        new Cateory(){Name = "Sports" , ImageUrl="sports.png"},
        new Cateory(){Name = "Science", ImageUrl= "science.png"},
        new Cateory(){Name = "Health", ImageUrl="health.png"},
    };



    public NewsHomePage()
	{
		InitializeComponent();
		GetBreakingNews();
        ArticlesList = new List<Article>();
        CvCategories.ItemsSource = CategoryList;
    }

    private void CvCategories_Selection(object sender, SelectionChangedEventArgs e)
    {
        var selectedItem = e.CurrentSelection.FirstOrDefault() as Cateory;
        if (selectedItem != null) return;
        Navigation.PushAsync(new NewsListPage(selectedItem.Name));
        ((CollectionView)sender).SelectedItem = null;
    }






    private async void GetBreakingNews()
    {
        var apiService =new ApiServices();
        var newsResult = await apiService.GetNews("general");
        foreach (var item in newsResult.Articles) 
        {
            ArticlesList.Add(item);
        }
        CvNews.ItemsSource = ArticlesList;
    }
}