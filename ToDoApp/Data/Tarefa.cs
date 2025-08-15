using System.ComponentModel.DataAnnotations;

namespace ToDoApp.Data
{
    public class Tarefa
    {
        [Display(Name = "Identificação")]
        public Guid? Id { get; set; }

        [Display(Name = "Tarefa")]
        [Required(ErrorMessage = "O nome da tarefa é obrigatório.")]
        [MinLength(5)]
        public string NoTarefa { get; set; }

        [Display(Name = "Descrição")]
        [Required(ErrorMessage = "A descrição da tarefa é obrigatória.")]
        [MinLength(5)]
        public string NoDescricao { get; set; }

        [Display(Name = "Data do Evento")]
        [Required(ErrorMessage = "Informe a data do evento.")]
        public DateTime DtEvento { get; set; }

        [Display(Name = "Previsão Conclusão")]
        public DateTime? DtPrevisaoFinalizacao { get; set; }

        [Display(Name = "Concluída")]
        public bool StConcluida { get; set; }

        [Display(Name = "Dias para Previsão")]
        public int? DiasParaPrevisao
        {
            get
            {
                if (DtPrevisaoFinalizacao.HasValue)
                {
                    return (DtPrevisaoFinalizacao.Value.Date - DateTime.Now.Date).Days;
                }
                return null;
            }
        }
    }
}
