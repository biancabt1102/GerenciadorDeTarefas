using System.ComponentModel;

namespace GerenciadorDeTarefas.Enum
{
    public enum Status
    {
        [Description("A fazer")]
        Pending = 1,
        [Description("Em andamento")]
        Processing = 2,
        [Description("Concluido")]
        Finished = 3
    }
}
