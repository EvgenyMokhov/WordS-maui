namespace WordS
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
        }

        private async void OnMainPageClicked(object? sender, EventArgs e)
        {
            await Current.GoToAsync("///MainPage");
        }

        private async void OnTestsClicked(object? sender, EventArgs e)
        {
            await Current.GoToAsync("///TestsPage");
        }

        private void OnSettingsClicked(object? sender, EventArgs e)
        {
        }
    }
}
