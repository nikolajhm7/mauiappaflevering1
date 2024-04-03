using TheDebtBook.ViewModels;

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
	}
}
