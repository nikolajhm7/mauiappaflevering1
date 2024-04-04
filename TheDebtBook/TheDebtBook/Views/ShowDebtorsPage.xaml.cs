using TheDebtBook.ViewModels;
using TheDebtBook.Models;
using System.Diagnostics;
using TheDebtBook.Data;

namespace TheDebtBook.Views
{
    public partial class ShowDebtorsPage : ContentPage
	{
        ShowDebtorsViewModel _viewModel;
        public ShowDebtorsPage(ShowDebtorsViewModel vm)
        {
            InitializeComponent();
            BindingContext = _viewModel = vm;
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            if (!Navigation.NavigationStack.Contains(this))
            {
                _viewModel.Debt.Clear();
            }
        }

    }
}
