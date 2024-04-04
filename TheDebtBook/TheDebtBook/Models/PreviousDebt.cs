using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheDebtBook.Models
{
    public class PreviousDebt
    {
        [PrimaryKey, AutoIncrement]
        public int PreviousDebtId { get; set; }
        public string Name { get; set; }
        public int DebtorId { get; set; } // Foreign key til Debtor model
        public decimal Amount { get; set; }
    }
}
