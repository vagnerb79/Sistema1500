using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Sistema1500.Models;
using System.Xml.Linq;
using System;
using System.Linq;
using System.ComponentModel.DataAnnotations.Schema;

public enum TypeObject
{
    Gestao,
    ETL,
    DASH,
    BBP,
    Aula,
    PREPAULA,
    DEV,
    MANUT
}

public class ActualState
{
    [Key]
    public int Id { get; set; }

    [Display(Name = "Projeto")]
    public int ProjectId { get; set; }

    [Display(Name = "Projeto")]
    public Project Project { get; set; } //Recebe dados de Project

    [Display(Name = "Círculo")]
    public int CircleId { get; set; }

    [Display(Name = "Círculo")]
    public Circle Circle { get; set; }  //Recebe dados de Circle

    [Display(Name = "Consultor Nível")]
    public int TypeConsultorId { get; set; }

    [Display(Name = "Consultor Nível")]
    public TypeConsultor TypeConsultor { get; set; }   //Recebe dados de TypeConsultor

    [Display(Name = "Tipo Objeto")]
    public TypeObject TypeObject { get; set; }

    [Display(Name = "Descrição")]
    public string Description { get; set; }

    [Display(Name = "Planejado")]
    public float TimePlanned { get; set; }

    [Display(Name = "Planejado")]
    [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = true)]
    public float Value { get; set; }

    [Display(Name = "Consultor")]
    public int PersonId { get; set; }

    [Display(Name = "Consultor")]
    [ForeignKey("PersonId")]
    public Person Person { get; set; }

    [Display(Name = "Utilizado")]
    public float RealTime { get; set; }

    [Display(Name = "Finalizado")]
    public bool Delivered { get; set; }

    [Display(Name = "Valor Real")]
    [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = true)]
    public float RealValue { get; set; }

    [Display(Name = "Produtividade")]
    public float Productivity { get; set; }

    [Display(Name = "Entrega")]
    [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yy}")]
    public DateTime Sprint { get; set; }

    [Display(Name = "Valor Final")]
    [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = true)]
    public float FinalValue { get; set; } // Só é claculado se estiver entregue (bool Delivered)

    public List<HoursDay> HoursDay { get; set; } //Envia dados para HoursDay

    public void AttCalculos() // void não retorna nenhum dado
    {
        if (this.HoursDay != null && this.HoursDay.Count > 0)
        {
            this.RealTime = this.HoursDay.Sum(x => x.RealTime); //Soma Horas Reais da classe HoursDay e envia para ActualStates
            this.Delivered = this.HoursDay.FirstOrDefault(x => x.Delivered == true) != null;
        }

        if (this.Project.Type == TypeTime.PrecoFechado) //Verifica TypeTime na classe Project
        {

            float tarifa = this.Project.Value / this.Project.Duration; //Calcula dados da classe Project
            this.Value = this.TimePlanned * tarifa; //Calcula valor dessa classe com dados da classe Project
        }

        else
        {
            this.Value = this.TypeConsultor.Fee * this.TimePlanned; // Recebe valor da classe TypeConsultor
        }

        if (this.Delivered) // Se estiver como entregue ele entra no if
        {
            this.Productivity = this.TimePlanned / this.RealTime; // Calcular Produtividade dessa classe
            if (double.IsInfinity(this.Productivity)) // Retorna valor boleano
                this.Productivity = 0;

            if (this.Project.Type == TypeTime.PrecoFechado)
            {
                float tarifa = this.Project.Value / this.Project.Duration;
                this.FinalValue = this.TimePlanned * tarifa;
            }

            else
            {
                this.FinalValue = this.TypeConsultor.Fee * this.RealTime;
            }
        }

    }
}


