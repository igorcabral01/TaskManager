using Microsoft.EntityFrameworkCore;

namespace TaskManager.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Projeto> Projetos { get; set; }
        public DbSet<Tarefa> Tarefas { get; set; }
        public DbSet<ProjetoUsuario> ProjetosUsuarios { get; set; }
        public DbSet<Notificacao> Notificacoes { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tarefa>()
                .HasOne(t => t.AtribuidaPara)
                .WithMany(u => u.TarefasAtribuidas)
                .HasForeignKey(t => t.AtribuidaParaId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Tarefa>()
                .HasOne(t => t.CriadaPor)
                .WithMany(u => u.TarefasCriadas)
                .HasForeignKey(t => t.CriadaPorId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
