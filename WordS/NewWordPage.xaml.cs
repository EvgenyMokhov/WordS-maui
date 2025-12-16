using Domain.Interfaces;
using Domain.Models.Dtos;

namespace WordS;

public partial class NewWordPage : ContentPage
{
    private readonly IWords Words;
	public NewWordPage(IWords words)
	{
		InitializeComponent();
        BindingContext = new WordDto();
        Words = words;
	}

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        WordDto word = await Words.GetDailyWordAsync();
        BindingContext = word;
    }

    private async void OnNextClicked(object? sender, EventArgs e)
    {
        await Words.SetWordReviewedAsync((BindingContext as WordDto).Id);
        await Shell.Current.GoToAsync("///TestPage");
    }
}