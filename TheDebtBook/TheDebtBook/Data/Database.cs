using SQLite;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using TheDebtBook.Models;
using Microsoft.Maui.Storage;

namespace TheDebtBook.Data
{
	public class Database : IDatabase
	{
		private readonly SQLiteAsyncConnection _connection;

		public Database(string dbPath = null)
		{
			var dataDir = FileSystem.AppDataDirectory;
			var databasePath = dbPath ?? Path.Combine(dataDir, "TheDebtBook.db");
			_connection = new SQLiteAsyncConnection(databasePath);

			_ = Initialise();
		}

		private async Task Initialise()
		{
			await _connection.CreateTableAsync<Debtor>();
		}

		public async Task<int> AddDebtor(Debtor debtor)
		{
			return await _connection.InsertAsync(debtor);
		}

		public async Task<List<Debtor>> GetDebtors()
		{
			return await _connection.Table<Debtor>().ToListAsync();
		}

		public async Task<int> AddDebt(Debtor item)
		{
			return await _connection.InsertAsync(item);
		}

		public async Task<Debtor> GetDebt(int id)
		{
			return await _connection.Table<Debtor>().Where(d => d.DebtorId == id).FirstOrDefaultAsync();
		}

		public async Task<List<Debtor>> GetDebts()
		{
			return await _connection.Table<Debtor>().ToListAsync();
		}

        public async Task ClearDebts()
        {
            await _connection.DeleteAllAsync<Debtor>();
        }

		public async Task<int> UpdateDebt(Debtor debtor)
		{
			return await _connection.UpdateAsync(debtor);
		}
    }
}