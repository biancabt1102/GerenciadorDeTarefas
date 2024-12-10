using GerenciadorDeTarefas.Enum;

namespace GerenciadorDeTarefas.Models
{
    public class Task
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Status Status { get; set; }
        public DateTime DateCreation { get; set; }
    }
}
