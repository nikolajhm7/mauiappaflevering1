using TheDebtBook.ViewModels;

namespace TheDebtBook.Views
{
	public partial class MainPage : ContentPage
	{
		private readonly MainViewModel _viewModel;
		public MainPage(MainViewModel vm)
		{
			InitializeComponent();
			BindingContext = _viewModel = vm;

			this.Appearing += MainPage_Appearing;
		}

		private async void MainPage_Appearing(object sender, EventArgs e)
		{
			await _viewModel.RefreshDebts();
		}
    }
}
