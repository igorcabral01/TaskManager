# TaskManager - Documentação e Instruções de Uso

## Descrição
O TaskManager é uma API REST desenvolvida em .NET 8 para gerenciamento de tarefas, projetos, usuários e notificações. O projeto utiliza Entity Framework Core com MySQL, autenticação JWT, validação com FluentValidation, mapeamento com AutoMapper e mensageria com RabbitMQ.

## Principais Funcionalidades
- Cadastro, atualização, remoção e consulta de usuários, tarefas, projetos e notificações
- Autenticação e autorização via JWT
- Integração com RabbitMQ para eventos de projeto
- Validação de dados com FluentValidation
- Hash de senha com BCrypt.Net
- CORS liberado para integração com frontend
- Testes automatizados com xUnit e Moq

## Estrutura do Projeto
- **Controllers/**: Endpoints REST
- **Services/**: Lógica de negócio
- **Domain/**: Modelos e contexto do banco
- **DTOs/**: Objetos de transferência de dados
- **Mappings/**: Perfis do AutoMapper
- **Validations/**: Validações de DTOs
- **Hubs/**: SignalR (notificações)
- **Infrastructure/**: Configurações e integrações
- **Tests/**: Testes automatizados

## Como Executar
1. Instale o .NET 8 SDK e o MySQL Server
2. Configure a string de conexão em `appsettings.json`
3. Execute as migrations para criar o banco:
   ```powershell
   dotnet ef database update
   ```
4. Inicie a API:
   ```powershell
   dotnet run
   ```
5. Acesse a documentação Swagger em `http://localhost:5000/swagger` (ou porta configurada)

## Autenticação
- Para acessar rotas protegidas, faça login em `/api/autenticacao/login` enviando email e senha.
- Use o token JWT retornado no header `Authorization: Bearer {token}` nas requisições protegidas.

## RabbitMQ
- Configure o RabbitMQ no `appsettings.json` se desejar usar eventos.
- O projeto publica eventos de criação de projeto para outras APIs.

## Testes
- Execute os testes com:
   ```powershell
   dotnet test
   ```

## Observações
- CORS está liberado para qualquer origem.
- O projeto segue boas práticas de DI, async/await e arquitetura limpa.

## Contato
Dúvidas ou sugestões: igorcabral01@gmail.com
