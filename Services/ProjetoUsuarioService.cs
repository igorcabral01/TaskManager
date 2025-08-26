using TaskManager.Models;

namespace TaskManager.Services
{
    /// <summary>
    /// Serviço para regras de negócio e manipulação de relacionamento Projeto-Usuário.
    /// </summary>
    public class ProjetoUsuarioService
    {
        public ProjetoUsuario AdicionarUsuarioAoProjeto(ProjetoUsuario projetoUsuario)
        {
            projetoUsuario.DataEntrada = DateTime.Now;
            return projetoUsuario;
        }
    }
}
