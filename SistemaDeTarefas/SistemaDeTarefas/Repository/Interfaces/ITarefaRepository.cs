using SistemaDeTarefas.Models;

namespace SistemaDeTarefas.Repository.Interfaces
{
    public interface ITarefaRepository
    {
        Task<List<TarefaModel>> BuscarTodosTarefas();
        Task<TarefaModel> BuscarPorId(int id);
        Task<TarefaModel> Adicionar(TarefaModel Tarefa);
        Task<TarefaModel> Atualizar(TarefaModel Tarefa, int id);
        Task<bool> Apagar(int id);
    }
}
