using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Xml.Linq;

namespace Sistema1500.Models
{
    public class BankAccount
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Banco")]
        public string Name { get; set; } //Nome do Banco

        [Display(Name = "Empresa")]
        public int EnterpriseId { get; set; }

        [Display(Name = "Empresa")]
        public Enterprise Enterprise { get; set; } //Recebe dados da classe Enterprise

        [Display(Name = "Saldo Atual")]
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = true)]
        public float Balance { get; set; } //Saldo Atual da Empresa

        [Display(Name = "Saldo Inicial")]
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = true)]
        public float InitialBalance { get; set; } //Saldo Inicial da Empresa

        public List<Expense> Expenses { get; set; } //Envia dados para classe Expenses

        public void calculoBanco()
        {
            this.Balance =
                this.InitialBalance +
                this.Expenses.Where(a => a.Type).Sum(a => a.Value) -
                this.Expenses.Where(a => !a.Type).Sum(a => a.Value);
        }

    }
}