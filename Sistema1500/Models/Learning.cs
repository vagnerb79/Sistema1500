using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using System;

namespace Sistema1500.Models
{
    public class Learning
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Data")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yy}")]
        public DateTime Date { get; set; }

        [Display(Name = "Círculo")]
        public int CircleId { get; set; }

        [Display(Name = "Círculo")]
        public Circle Circle { get; set; } //Recebe dados de Circle

        [Display(Name = "Tema")]
        public int ThemeId { get; set; }

        [Display(Name = "Tema")]
        public Theme Theme { get; set; } //Recebe dados de Theme

        [Display(Name = "Aprendizado")]
        public string OportunityLearning { get; set; }

        [Display(Name = "Ação Aprendizado")]
        public string LearningAction { get; set; }

        [Display(Name = "Data")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yy}")]
        public DateTime MeasurementDate { get; set; }

        [Display(Name = "Nota")]
        public float MeasurementForm { get; set; }

        [Display(Name = "Resultado")]
        public string Result { get; set; }

        [Display(Name = "Comentários")]
        public string Comment { get; set; }

        [Display(Name = "Situação")]
        public Status Status { get; set; }

        public List<PersonLearning> PersonLearnings { get; set; } //Envia dados para PersonLearning

        [NotMapped]
        [Display(Name = "Mentor")]
        public int TeacherPersonId { get; set; }

        [NotMapped]
        [Display(Name = "Mentorado")]
        public int StudentPersonId { get; set; }

        [NotMapped]
        public Person TeacherPerson { get; set; }

        [NotMapped]
        public Person StudentPerson { get; set; }

    }
}

public enum Status
{
    Branco,
    Concluido
}
