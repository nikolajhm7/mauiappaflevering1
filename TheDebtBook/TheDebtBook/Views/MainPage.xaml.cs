using TheDebtBook.ViewModels;
using TheDebtBook.Models;
using CommunityToolkit.Maui.Views;

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

        private async void OnItemSelectedAsync(object sender, SelectionChangedEventArgs e)
        {
			Debtor debtor = e.CurrentSelection.FirstOrDefault() as Debtor;
			if (debtor != null)
			{
				var pageParams = new Dictionary<string, object>
				{
					{ "SelectedDebtor", debtor }
				};

				await Shell.Current.GoToAsync("//showDebtors", pageParams);
			}
        }
    }
}
