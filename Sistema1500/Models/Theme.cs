using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Sistema1500.Models
{
    public class Theme
    {

        [Key]
        public int Id { get; set; }

        [Display(Name = "Tema")]
        public string Name { get; set; }

        [Display(Name = "Descrição")]
        public string Description { get; set; }

        public List<Learning> Learnings { get; set; } //Envia dados para Learnings

        public List<Feedback> Feedbacks { get; set; } //Envia dados para Feedbacks

    }

}

