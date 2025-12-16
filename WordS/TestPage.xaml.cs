using Domain.Interfaces;
using Domain.Models.Dtos;

namespace WordS;

public partial class TestPage : ContentPage
{
    private readonly ITests Tests;
	public TestPage(ITests tests)
	{
		InitializeComponent();
        BindingContext = new TestDto();
        Tests = tests;
	}

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        TestDto test = await Tests.GenerateTestAsync();
        BindingContext = test;
    }

    private async void OnSendClicked(object? sender, EventArgs e)
    {
        TestDto test = BindingContext as TestDto;
        await Tests.CheckResultAsync(test.Id, test.TestWords);
        await Shell.Current.GoToAsync("///MainPage");
    }
}