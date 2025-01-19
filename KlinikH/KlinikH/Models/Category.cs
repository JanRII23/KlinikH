using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KlinikH.Models
{
    public class Category
    {
        //NOTE: this defines a primary key for the DB
        [Key]
        public int CategoryId { get; set; }

        //NOTE: important to define the property type on the DB
        [Column(TypeName = "nvarchar(50)")]
        public required string Title {  get; set; }

        [Column(TypeName = "nvarchar(5)")]
        public required string Icon { get; set; } = "";

        [Column(TypeName = "nvarchar(10)")]
        public required string Type { get; set; } = "Expense";

        //NOTE: assigning this to value in the DB column provides a default property
    }
}
