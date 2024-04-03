using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TheDebtBook.Models
{
	public class Debtor
	{
		[PrimaryKey, AutoIncrement]
		public int DebtorId { get; set; }

		public string? Name { get; set; }

		public decimal Debt { get; set; }

        [Ignore]
        public ICollection<PreviousDebt> PreviousDebts { get; set; } = new List<PreviousDebt>();

        //public Debtor(string name, decimal debt)
        //{
        //	Name = name;
        //	Debt = debt;
        //	PreviousDebts = new List<decimal>();
        //}
    }
}

