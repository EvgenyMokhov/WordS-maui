using Domain.Interfaces;
using Domain.Models.Dtos;

namespace WordS;

public partial class TestsPage : ContentPage
{
    private readonly ITests Tests;
    public List<TestDto> Data { get; set; } = new();
    public TestsPage(ITests tests)
	{
		InitializeComponent();
        Tests = tests;
	}

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        Data = await Tests.GetTestsAsync();
        BindingContext = this;
    }
}