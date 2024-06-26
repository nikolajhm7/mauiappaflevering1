﻿using CommunityToolkit.Mvvm.ComponentModel;
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


		public AddDebtorViewModel(IDatabase database)
		{
            _database = database;

            AddDebtorAsyncCommand = new AsyncRelayCommand(AddDebtorAsync);
			NavigateToMainPageAsyncCommand = new AsyncRelayCommand(NavigateToMainPageAsync);
        }
        #region Properties
        [ObservableProperty]
		private string name;

		[ObservableProperty]
		private string debt;
        #endregion Properties

        #region Commands
        public IAsyncRelayCommand AddDebtorAsyncCommand { get; }
        public IAsyncRelayCommand NavigateToMainPageAsyncCommand { get; }
        #endregion Commands

        #region Methods
        private async Task AddDebtorAsync()
		{
            if (!string.IsNullOrEmpty(Name) && decimal.TryParse(Debt, out decimal debtAmount))
			{
				var newDebtor = new Debtor { Name = this.Name, Debt = debtAmount };
				await _database.AddDebtor(newDebtor); 

                var initialdebt = new PreviousDebt 
                { 
                    Name = newDebtor.Name,
                    Amount = debtAmount,
                    DebtorId = newDebtor.DebtorId
                };
                await _database.AddPreviousDebt(initialdebt);

				await Shell.Current.GoToAsync("//main"); // Navigates back to main
				await _database.GetDebtors();
            }
        }

		private async Task NavigateToMainPageAsync() => await Shell.Current.GoToAsync("//main");
        #endregion Methods
    }
}