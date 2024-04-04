using TheDebtBook.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TheDebtBook.Data
{
	public interface IDatabase
	{
		Task<int> AddDebtor(Debtor debtor);
		Task<List<Debtor>> GetDebtors();
		Task<int> AddDebt(Debtor item, decimal amount);
		Task<Debtor> GetDebt(int id);
		//Task<Debtor> GetDebt(Debtor debtor);
		//Task<List<Debtor>> GetDebts();
		Task ClearDebts();
		Task<int> UpdateDebt(Debtor debtor);
		Task<List<PreviousDebt>> GetPreviousDebtsForDebtor(Debtor debtor);
		Task<int> AddPreviousDebt(PreviousDebt previousDebt);
		Task<decimal> CalculateTotalDebtForDebtor(int debtorId);


    }
}