using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TheDebtBook.Data;
using TheDebtBook.Models;
using System.Threading.Tasks;
using System.Diagnostics;

namespace TheDebtBook.ViewModels
{
	public partial class AddDebtorViewModel : ObservableObject
	{
		private readonly IDatabase _database;

		[ObservableProperty]
		private string name;

		[ObservableProperty]
		private string debt;

		public AddDebtorViewModel(IDatabase database)
		{
            _database = database;

            AddDebtorAsyncCommand = new AsyncRelayCommand(AddDebtorAsync);
			NavigateToMainPageAsyncCommand = new AsyncRelayCommand(NavigateToMainPageAsync);
        }
        public IAsyncRelayCommand AddDebtorAsyncCommand { get; }
        public IAsyncRelayCommand NavigateToMainPageAsyncCommand { get; }

        private async Task AddDebtorAsync()
		{
            if (!string.IsNullOrEmpty(Name) && decimal.TryParse(Debt, out decimal debtAmount))
			{
				var newDebtor = new Debtor { Name = this.Name, Debt = debtAmount };
				await _database.AddDebtor(newDebtor); 
				System.Diagnostics.Debug.WriteLine("Added debtor to Database B)");
				await Shell.Current.GoToAsync("//main"); // Navigates back to main
				await _database.GetDebts();
            }
        }

		private async Task NavigateToMainPageAsync() => await Shell.Current.GoToAsync("//main");

	}
}