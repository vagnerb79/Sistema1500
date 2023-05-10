using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using System;

namespace Sistema1500.Models
{
    public class Expense
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Tipo")]
        public bool Type { get; set; } //Tipo Recebimento ou Pagamento

        [Display(Name = "Data Realização")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime RegisterDate { get; set; } //Data Registro

        [Display(Name = "Data do Caixa")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime CashDate { get; set; } //Data Caixa

        [Display(Name = "Mês Caixa")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime MonthDate { get; set; } //Mês Caixa

        [Display(Name = "Data Competência")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime CompeteDate { get; set; } //Data Competência

        [Display(Name = "Mês Competência")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime CompeteMonthDate { get; set; } //Mês Competência

        [Display(Name = "Centro de Custo")]
        public int? CostCenterId { get; set; } //A interrogação indica que essa variável pode ser nula

        [Display(Name = "Centro de Custo")]
        public CostCenter? CostCenter { get; set; } //Recebe dados da classe CostCenter

        [Display(Name = "Conta")]
        public int? CapturesId { get; set; } //A interrogação indica que essa variável pode ser nula

        [Display(Name = "Conta")]
        public Captures? Captures { get; set; } //Recebe dados da classe Captures

        [Display(Name = "Pessoa")]
        public int? PersonId { get; set; } //A interrogação indica que essa variável pode ser nula

        [Display(Name = "Pessoa")]
        public Person? Person { get; set; } //Recebe dados da classe Person

        [Display(Name = "Banco")]
        public int? BankAccountId { get; set; } //A interrogação indica que essa variável pode ser nula

        [Display(Name = "Banco")]
        public BankAccount? BankAccount { get; set; } //Recebe dados da classe BankAccount

        [Display(Name = "Despesa")]
        public string TargetBill { get; set; } //Nome do Local da despesa. Ex: Estacionamento, Restaurante

        [Display(Name = "Descrição")]
        public string Description { get; set; } //Campo será relacionado com a Despesa

        [Display(Name = "Valor")]
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = true)]//Valor será digitado
        public float Value { get; set; }

        [Display(Name = "Contabilizado")]
        public bool Validated { get; set; } //Será marcado em check S ou N (se já foi dado baixa)

        [Display(Name = "Planejado")]
        public bool Plan { get; set; } //Será marcado em check S ou N (futuramente será feito uma cópia)

        [Display(Name = "Saldo em Banco")]
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = true)]
        public float BankValueMoment { get; set; }

        [Display(Name = "Saldo da Empresa")]
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = true)]
        public float EnterpriseBankValueMoment { get; set; }

    }
}
