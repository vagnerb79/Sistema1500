using Microsoft.AspNetCore.Rewrite;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Sistema1500.Models
{
    public class Person : IdentityUser<int>
    {
        [Display(Name = "Nome")]
        public string Name { get; set; }

        [Display(Name = "Tipo")]
        public TypePerson Type { get; set; }

        [Display(Name = "Círculo")]
        public int? CircleId { get; set; }

        [Display(Name = "Círculo")]
        public Circle Circle { get; set; }

        [Display(Name = "CPF")]
        public string Cpf { get; set; }

        [Display(Name = "E-Mail")]
        public string Email { get; set; }

        [Display(Name = "Telefone")]
        public string Phone { get; set; }

        [Display(Name = "Data Nascimento")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yy}")]
        public DateTime BornDate { get; set; }

        [Display(Name = "Nivel Estudo")]
        public NivelStudy NivelStudy { get; set; }

        [Display(Name = "Universidade")]
        public string University { get; set; }

        [Display(Name = "Data da Graduação")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yy}")]
        public DateTime GraduateDate { get; set; }

        [Display(Name = "Data Registro")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yy}")]
        public DateTime RegisterDate { get; set; }

        [Display(Name = "Empresa")]
        public string Enterprise { get; set; }

        [Display(Name = "Recomendação")]
        public bool Recommendation { get; set; }

        [Display(Name = "Estudando?")]
        public bool IsStudy { get; set; }

        public List<PersonLearning> PersonLearnings { get; set; } //Envia dados para PersonLearnings

        public List<PersonFeedback> PersonFeedbacks { get; set; } //Envia dados para PersonFeedbacks

        public List<ActualState> ActualStates { get; set; } //Envia dados para ActualStates

        public List<HoursDay> HoursDays { get; set; } //Envia dados para HoursDays

    }

    public enum TypePerson
    {
        Mentor,
        Mentorado
    }

    public enum NivelStudy
    {
        EnsinoFundamentalIncompleto,
        EnsinoFundamentalCompleto,
        EnsinoMedioIncompleto,
        EnsinoMedioCompleto,
        EnsinoSuperiorIncompleto,
        EnsinoSuperiorCompleto

    }
}