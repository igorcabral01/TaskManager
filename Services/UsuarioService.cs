using TaskManager.Models;

namespace TaskManager.Services
{
    /// <summary>
    /// Serviço para regras de negócio e manipulação de usuários.
    /// </summary>
    public class UsuarioService : Interfaces.IUsuarioService
    {
        // Exemplo de método para criar usuário
        public Usuario CriarUsuario(Usuario usuario)
        {
            // Aqui você pode adicionar regras de negócio, hash de senha, etc.
            usuario.Ativo = true;
            usuario.UltimoLogin = null;
            return usuario;
        }

        // Exemplo de método para atualizar usuário
        public Usuario AtualizarUsuario(Usuario usuario)
        {
            usuario.DataAtualizacao = DateTime.Now;
            return usuario;
        }
    }
}
