using loginLucasAttila.Models;

namespace loginLucasAttila.Repository.Contract
{
    public interface IClienteRepository
    {
        //login Cliente

        Cliente Login(string Email , string Senha);

        //CRUD

        void Cadastrar(Cliente cliente);
        void Atualizar(Cliente cliente);
        
        void Ativar(int id);
        void Desativar(int id);
        void Excluir(int id);

        Cliente ObterCliente(int  id);
        Cliente BuscaCpfCliente(string CPF);
        Cliente BuscaEmailCliente(string email);

        IEnumerable<Cliente> ObterTodosClientes();

    }
}
