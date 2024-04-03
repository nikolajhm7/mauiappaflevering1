using TheDebtBook.ViewModels;
using TheDebtBook.Models;
using System.Diagnostics;
using TheDebtBook.Data;

namespace TheDebtBook.Views
{
	public partial class ShowDebtorsPage : ContentPage
	{
        //private readonly ShowDebtorsViewModel _viewModel;
        //public ShowDebtorsPage(ShowDebtorsViewModel vm, int selectedDebtorId, IDatabase database)
        //{
        //	InitializeComponent();
        //	BindingContext = _viewModel = vm;

        //          _ = LoadSelectedDebtor(selectedDebtorId, database);
        //      }

        //      private async Task LoadSelectedDebtor(int selectedDebtorId, IDatabase database)
        //      {
        //          // Fetch the selected debtor from the database based on the ID
        //          var selectedDebtor = await database.GetDebt(selectedDebtorId);
        //          await _viewModel.SetSelectedDebtor(selectedDebtor);
        //      }

        //     protected override void OnAppearing()
        //     {
        //         base.OnAppearing();
        //_viewModel.SetSelectedDebtor(Navigation?.NavigationStack?.LastOrDefault()?.BindingContext as Debtor);
        //     }

        private readonly ShowDebtorsViewModel _viewModel;
        public ShowDebtorsPage(ShowDebtorsViewModel vm)
        {
            InitializeComponent();
            BindingContext = _viewModel = vm;
        }

    }
}
