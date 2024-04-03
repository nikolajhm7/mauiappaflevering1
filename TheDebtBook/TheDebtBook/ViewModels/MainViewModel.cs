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
using System.Diagnostics;

namespace TheDebtBook.ViewModels
{
	public partial class MainViewModel : ObservableObject
	{
		private readonly IDatabase _database;

        // Constructor
        public MainViewModel(IDatabase database)
		{
            _database = database;
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
            Debug.WriteLine("AddDebtor button pressed");
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
        // Vi har ikke brug for den her metode, da vi har en event subscribtion i MainPage.xaml.cs,
		// som trigger når mainpage er i syne, hvilket den er fra start

  //      private async Task Initialize()
		//{
  //          System.Diagnostics.Debug.WriteLine("Initialize start");
		//	var debtors = await _database.GetDebtors();
		//	foreach (var debtor in debtors)
		//	{
		//		Debts.Add(debtor);
		//	}
  //          System.Diagnostics.Debug.WriteLine("Initialize end");
  //      }

		public async Task RefreshDebts()
		{
			Debts.Clear();
			var debtors = await _database.GetDebtors();
			foreach (var debtor in debtors)
			{
				Debts.Add(debtor);
			}
		}


        #endregion Methods
    }
}