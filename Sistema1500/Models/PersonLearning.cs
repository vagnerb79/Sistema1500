using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace Sistema1500.Models
{
    public class PersonLearning
    {

        [Key]
        public int Id { get; set; }

        [Display(Name = "Tipo")]
        public TypePerson TypePerson { get; set; } //Enumerator criado em Person

        [Display(Name = "Pessoa")]
        public int PersonId { get; set; }

        [Display(Name = "Pessoa")]
        [ForeignKey("PersonId")]
        public Person Person { get; set; }  //Recebe dados de Person

        [Display(Name = "Aprendizado")]
        public int LearningId { get; set; }

        [Display(Name = "Feedback")]
        public Learning Learning { get; set; }  //Recebe dados de Learning
    }

}