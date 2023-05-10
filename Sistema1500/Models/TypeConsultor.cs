using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Sistema1500.Models
{
    public class TypeConsultor
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Tipo")]
        public string Name { get; set; }

        [Display(Name = "Valor Tarifa")]
        public float Fee { get; set; }

        public List<ActualState> ActualStates { get; set; } //Envia dados para ActualStates
    }
}
