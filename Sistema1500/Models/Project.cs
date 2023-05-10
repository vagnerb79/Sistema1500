using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using System;

namespace Sistema1500.Models
{
    public class Project
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Projeto")]
        public string Name { get; set; }

        [Display(Name = "Contrato")]
        public TypeTime Type { get; set; } //Enumerator

        [Display(Name = "Tarifa")]
        public TypeFee Fee { get; set; } //Enumerator

        [Display(Name = "Descrição")]
        public string Description { get; set; }

        [Display(Name = "Empresa")]
        public string Enterprise { get; set; }

        [Display(Name = "Contratadas")]
        public float Duration { get; set; }

        [Display(Name = "Valor")]
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = true)]
        public float Value { get; set; }

        [Display(Name = "Início")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yy}")]
        public DateTime StartDate { get; set; }

        [Display(Name = "Entrega")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yy}")]
        public DateTime EndDate { get; set; }

        [Display(Name = "Registro")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yy}")]
        public DateTime InsertDate { get; set; }

        [Display(Name = "Situação")]
        public bool Status { get; set; }

        public List<ActualState> ActualStates { get; set; }  //Envia dados para ActualStates

        public List<HoursDay> HoursDays { get; set; }  //Envia dados para HoursDay

    }

    public enum TypeTime
    {
        Horas, // Será Calculado = Tarifa * Horas Utilizadas
        PrecoFechado // Será Calculado de acordo com a Tarifa TypeFee
    }

    public enum TypeFee
    {
        Tarifa1, // Será definido com switch case na classe ActualState
        Tarifa2,
        Tarifa3
    }
}