using TaskManager.Models;

namespace TaskManager.Services
{
    /// <summary>
    /// Serviço para regras de negócio e manipulação de projetos.
    /// </summary>
    public class ProjetoService : Interfaces.IProjetoService
    {
        public Projeto CriarProjeto(Projeto projeto)
        {
            projeto.Ativo = true;
            projeto.DataInicio = projeto.DataInicio ?? DateTime.Now;
            return projeto;
        }

        public Projeto AtualizarProjeto(Projeto projeto)
        {
            projeto.DataAtualizacao = DateTime.Now;
            return projeto;
        }
    }
}
