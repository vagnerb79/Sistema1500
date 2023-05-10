using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Sistema1500.Models
{
    public class Captures
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Conta")]
        public string Name { get; set; } //Nome da Conta

        public List<Expense> Expenses { get; set; } //Envia dados para classe Expenses
    }
}
