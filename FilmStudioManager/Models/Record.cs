using BookcrossingApp.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookcrossingApp.Models
{
    public class Record : INodeModel
    {

        public string UniqueIdentifier { get; set; }

        public DateTime BorrowDate { get; set; }
        public DateTime? ReturnDate { get; set; }

        public Record()
        {
            UniqueIdentifier = IdGenerator.GenerateUniqueId();
        }

        public Record(DateTime borrowDate, DateTime? returnDate)
        {
            UniqueIdentifier = IdGenerator.GenerateUniqueId();

            BorrowDate = borrowDate;
            ReturnDate = returnDate;
        }

        public override bool Equals(object obj)
        {
            return obj is Record record &&
                   UniqueIdentifier == record.UniqueIdentifier &&
                   BorrowDate == record.BorrowDate &&
                   ReturnDate == record.ReturnDate;
        }

        public override int GetHashCode()
        {
            int hashCode = -88652140;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(UniqueIdentifier);
            hashCode = hashCode * -1521134295 + BorrowDate.GetHashCode();
            hashCode = hashCode * -1521134295 + ReturnDate.GetHashCode();
            return hashCode;
        }
    }
}