using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Sistema1500.Models
{
    public class Enterprise
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Nome")]
        public string Name { get; set; } //Nome da Empresa

        [Display(Name = "CNPJ")]
        public string CNPJ { get; set; }

        [Display(Name = "Telefone")]
        public string Phone { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }

        public List<BankAccount> BankAccounts { get; set; } //Envia dados para classe BankAccount
    }
}
