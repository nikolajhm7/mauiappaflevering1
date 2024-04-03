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
			System.Diagnostics.Debug.WriteLine("OnItemSelected is run");
            if (e.CurrentSelection.FirstOrDefault() is Debtor selectedDebtor)
            {
                System.Diagnostics.Debug.WriteLine("Ifstatement branch in OnItemSelected");
				// Navigate to the details page, passing the selected debtor
				//await Shell.Current.GoToAsync($"//showDebtors?name={selectedDebtor.Name}");
				await Shell.Current.GoToAsync($"//showDebtors?name={selectedDebtor.Name}");
            }
            System.Diagnostics.Debug.WriteLine("Ifstatement passed in OnItemSelected");
        }
    }
}
