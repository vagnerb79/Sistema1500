using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using System;

namespace Sistema1500.Models
{
    public class Feedback
    {
        [Key]

        public int Id { get; set; }

        [Display(Name = "Data")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yy}")]
        public DateTime Date { get; set; }

        [Display(Name = "Círculo")]
        public int CircleId { get; set; }

        [Display(Name = "Círculo")]
        public Circle Circle { get; set; } //Recebe dados de Project

        [Display(Name = "Tema")]
        public int ThemeId { get; set; }

        [Display(Name = "Tema")]
        public Theme Theme { get; set; } //Recebe dados de Project

        [Display(Name = "Aprendizado")]
        public string OportunityLearning { get; set; }

        [Display(Name = "Nota")]
        public float Note { get; set; }

        [Display(Name = "Comentário")]
        public string Commnent { get; set; }

        public List<PersonFeedback> PersonFeedbacks { get; set; } //Envia dados para PersonFeedback

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
