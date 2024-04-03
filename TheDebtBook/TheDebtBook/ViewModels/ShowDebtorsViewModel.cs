using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TheDebtBook.Data;
using TheDebtBook.Models;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace TheDebtBook.ViewModels
{
    public partial class ShowDebtorsViewModel : ObservableObject
    {
        private readonly IDatabase _database;

        // Commands for the ToolbarItems
        [RelayCommand]
        async Task NavigateToAddDebtorAsync() => await Shell.Current.GoToAsync("//addDebtor");

        [RelayCommand]
        async Task NavigateToMainPageAsync() => await Shell.Current.GoToAsync("//main");

        // Observable collection to hold debtors
        [ObservableProperty]
        public ObservableCollection<Debtor> debt = new();

        public ShowDebtorsViewModel(IDatabase database)
        {
            _database = database;
            _ = LoadDebtors();
        }

        // Asynchronous method to load debtors from the database
        public async Task LoadDebtors()
        {
            Debt.Clear();
            var debtorList = await _database.GetDebtors();
            foreach (var debtor in debtorList)
            {
                Debt.Add(debtor);
            }
        }


    }
}