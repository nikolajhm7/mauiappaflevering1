using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TheDebtBook.Data;
using TheDebtBook.Models;
using TheDebtBook.Views;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Microsoft.Maui.Controls;
using Microsoft.Extensions.DependencyInjection;
using CommunityToolkit.Maui.Views;

namespace TheDebtBook.ViewModels
{
	public partial class MainViewModel : ObservableObject
	{
		private readonly IDatabase _database;

        // Constructor
        public MainViewModel(IDatabase database)
		{
            _database = database;
			_ = Initialize();
        }
        #region Properties

        // Observable collection to hold debts
        [ObservableProperty]
		ObservableCollection<Debtor> debts = new();

		#endregion Properties


		#region Commands
		[RelayCommand]
        private async Task AddDebtor()
		{
			await Shell.Current.GoToAsync("//addDebtor");
		}

		[RelayCommand]
		private async Task ShowDebtors()
		{
			await Shell.Current.GoToAsync("//showDebtors");
		}

		[RelayCommand]
		private async Task ClearDebtors()
		{
			await _database.ClearDebts();
			await RefreshDebts();
		}

        #endregion Commands

        #region Methods
        // Initialization method to load debts from the database
        private async Task Initialize()
		{
            System.Diagnostics.Debug.WriteLine("Initialize start");
			var debtors = await _database.GetDebtors();
			foreach (var debtor in debtors)
			{
				Debts.Add(debtor);
			}
            System.Diagnostics.Debug.WriteLine("Initialize end");
        }

		public async Task RefreshDebts()
		{
			Debts.Clear();
			var debtors = await _database.GetDebts();
			foreach (var debtor in debtors)
			{
				Debts.Add(debtor);
			}
		}


        #endregion Methods
    }
}