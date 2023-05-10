using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using System;

namespace Sistema1500.Models
{
    public class HoursDay
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Atividade")]
        public int ActualStateId { get; set; } //Referenciando diretamente ActualStates

        [Display(Name = "Atividade")]
        public ActualState ActualStates { get; set; } //Acessando os dados de ActualStates

        [Display(Name = "Data Realizada")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yy}")]
        public DateTime Date { get; set; }

        [Display(Name = "Horas")]
        public float RealTime { get; set; }

        [Display(Name = "Entregue")]
        public bool Delivered { get; set; }

    }
}

