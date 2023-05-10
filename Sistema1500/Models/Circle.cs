using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Sistema1500.Models
{
    public class Circle
    {

        [Key]
        public int Id { get; set; }

        [Display(Name = "Nome")]
        public string Name { get; set; }

        public List<Person> Persons { get; set; } //Envia dados para Persons

        public List<Learning> Learnings { get; set; } //Envia dados para Learnings

        public List<Feedback> Feedbacks { get; set; } //Envia dados para Feedbacks

        public List<ActualState> ActualStates { get; set; } //Envia dados para ActualStates
    }

}