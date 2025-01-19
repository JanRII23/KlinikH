using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KlinikH.Models
{
    public class Transaction
    {
        [Key]
        public int TransactionId { get; set; }

        //NOTE: categoryId is a foreign key of categeory Model. There are other potential implementations to design a foreign key
        public int CategoryId { get; set; }
        public required Category Category { get; set; }

        public int Amount { get; set; }

        [Column(TypeName = "nvarchar(75)")]
        public string? Note { get; set; }

        public DateTime Date {  get; set; } = DateTime.Now;
    }
}
