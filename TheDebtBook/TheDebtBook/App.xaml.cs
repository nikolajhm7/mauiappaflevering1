using TheDebtBook.Views;
using TheDebtBook.ViewModels;
using TheDebtBook.Data;

namespace TheDebtBook
{
    public partial class App : Application
    {
        public App()
        {
	        InitializeComponent();

            MainPage = new AppShell();
        }

	}
}
