using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Sistema1500.Models
{
    public class CostCenter
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Centro de Custo")]
        public string Name { get; set; } //Nome do Centro de Custo

        public List<Expense> Expenses { get; set; } //Envia dados para classe Expenses
    }
}
