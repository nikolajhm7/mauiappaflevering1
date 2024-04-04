using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TheDebtBook.Data;
using TheDebtBook.Models;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Diagnostics;

namespace TheDebtBook.ViewModels
{
    [QueryProperty(nameof(Debtor), "SelectedDebtor")]
    public partial class ShowDebtorsViewModel : ObservableObject
    {
        private readonly IDatabase _database;

        #region DebtorProperties
        Debtor _debtor;
        public Debtor Debtor
        {
            get { return _debtor; }
            set
            {
                _debtor = value;
                if (_debtor != null)
                {
                    Name = _debtor.Name;
                    CurrentDebt = _debtor.Debt;

                    LoadPreviousDebts(_debtor);
                }
            }
        }
        string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }
        decimal _currentDebt;
        public decimal CurrentDebt
        {
            get { return _currentDebt; }
            set
            {
                _currentDebt = value;
                OnPropertyChanged();
            }
        }

        //ObservableCollection<PreviousDebt> _previousDebts = new();
        //public ObservableCollection<PreviousDebt> PreviousDebts
        //{
        //    get { return _previousDebts; }
        //    set
        //    {
        //        _previousDebts = value;
        //        OnPropertyChanged();
        //    }
        //}
        private decimal _amountToAdd;
        public decimal AmountToAdd
        {
            get { return _amountToAdd; }
            set
            {
                _amountToAdd = value;
                OnPropertyChanged();
            }
        }

        #endregion DebtorProperties
        // Commands for the ToolbarItems
        [RelayCommand]
        async Task NavigateToAddDebtorAsync() => await Shell.Current.GoToAsync("//addDebtor");

        [RelayCommand]
        async Task NavigateToMainPageAsync() => await Shell.Current.GoToAsync("//main");

        [RelayCommand]
        async Task AddDebt() => await AddDebtAsync();

        // Observable collection to hold debtors
        [ObservableProperty]
        public ObservableCollection<Debtor> debt = new();
        [ObservableProperty]
        public ObservableCollection<PreviousDebt> previousDebts = new();

        public ShowDebtorsViewModel(IDatabase database)
        {
            _database = database;
            //_ = LoadDebtors();
        }

        //// Asynchronous method to load debtors from the database
        //public async Task LoadDebtors()
        //{
        //    Debt.Clear();
        //    var debtorList = await _database.GetDebtors();
        //    foreach (var debtor in debtorList)
        //    {
        //        Debt.Add(debtor);
        //    }
        //}

        async Task LoadPreviousDebts(Debtor debtor)
        {
            if (debtor != null)
            {
                PreviousDebts.Clear();
                var previousDebts = await _database.GetPreviousDebtsForDebtor(debtor);
                foreach (var debt in previousDebts)
                {
                    if (!string.IsNullOrEmpty(debt.Name))
                    {
                        PreviousDebts.Add(debt);
                    }
                }
            }
        }
        
        async Task AddDebtAsync()
        {
            await _database.AddPreviousDebt(new PreviousDebt 
            {
                Name = Debtor.Name,
                DebtorId = Debtor.DebtorId,
                Amount = AmountToAdd
            });

            await _database.AddDebt(Debtor, AmountToAdd);

            //await LoadDebtors();
            await LoadPreviousDebts(Debtor);

            CurrentDebt = Debtor.Debt;
        }

        //public async Task SetSelectedDebtor(int debtorId)
        //{
        //    var debtor = await _database.GetDebt(debtorId);

        //    SelectedDebtor = debtor;

        //    SelectedDebtor.PreviousDebts = await _database.GetPreviousDebtsForDebtor(debtor);

        //    foreach (var previousDebt in SelectedDebtor.PreviousDebts)
        //    {
        //        previousDebt.AssociatedDebtor = await _database.GetDebt(debtor.DebtorId);
        //    }
        //}

    }
}