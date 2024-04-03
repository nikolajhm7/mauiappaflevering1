using TheDebtBook.ViewModels;
using TheDebtBook.Models;
using System.Diagnostics;

namespace TheDebtBook.Views
{
	public partial class ShowDebtorsPage : ContentPage
	{
		private readonly ShowDebtorsViewModel _viewModel;
		public ShowDebtorsPage(ShowDebtorsViewModel vm)
		{
			InitializeComponent();
			BindingContext = _viewModel = vm;
		}

        protected override void OnAppearing()
        {
            base.OnAppearing();
			_viewModel.SetSelectedDebtor(Navigation?.NavigationStack?.LastOrDefault()?.BindingContext as Debtor);
        }
    }
}
