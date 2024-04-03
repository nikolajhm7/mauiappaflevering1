using Microsoft.Extensions.DependencyInjection;
using TheDebtBook.ViewModels;

namespace TheDebtBook.Views
{
	public partial class AddDebtorPage : ContentPage
	{
		public AddDebtorPage(AddDebtorViewModel vm)
		{
			InitializeComponent();
			BindingContext = vm;
		}
	}
}
