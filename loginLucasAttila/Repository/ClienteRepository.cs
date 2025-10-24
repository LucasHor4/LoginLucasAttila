using loginLucasAttila.Models;
using loginLucasAttila.Models.Constantes;
using loginLucasAttila.Repository.Contract;
using Microsoft.VisualBasic;
using MySql.Data.MySqlClient;
using System.Data;
using System.Runtime.ConstrainedExecution;

namespace loginLucasAttila.Repository
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly string _conexaoMySQL;
        private ClienteRepository(IConfiguration conf)
        {
            _conexaoMySQL = conf.GetConnectionString("ConexaoMySQL");
        }
        public void Ativar(int id)
        {
            string Situacao = SituacaoConstantes.Ativo;
            using (var conexao = new MySqlConnection(_conexaoMySQL))
            {
                conexao.Open();
                MySqlCommand cmd = new MySqlCommand("update Cliente set Situacao=@Situacao WHERE Id=@Id ", conexao);

                cmd.Parameters.Add("@Id", MySqlDbType.VarChar).Value = Id;
                cmd.Parameters.Add("@Situacao", MySqlDbType.VarChar).Value = Situacao;
                cmd.ExecuteNonQuery();
                conexao.Close();
            }
        }

        public void Atualizar(Cliente cliente)
        {
            try
            {
                string Situacao = SituacaoConstantes.Ativo;
                using (var conexao = new MySqlConnection(_conexaoMySQL))
                {
                    conexao.Open();
                    MySqlCommand cmd = new MySqlCommand("update Cliente set Nome=@Nome, Nascimento=@Nascimento, Sexo=@Sexo,  CPF=@CPF, " +
                        " Telefone=@Telefone, Email=@Email, Senha=@Senha, Situacao=@Situacao WHERE Id=@Id ", conexao);

                    cmd.Parameters.Add("@Id", MySqlDbType.VarChar).Value = cliente.Id;
                    cmd.Parameters.Add("@Nome", MySqlDbType.VarChar).Value = cliente.Nome;
                    cmd.Parameters.Add("@Nascimento", MySqlDbType.DateTime).Value = cliente.Nascimento.ToString("yyyy/MM/dd");
                    cmd.Parameters.Add("@Sexo", MySqlDbType.VarChar).Value = cliente.Sexo;
                    cmd.Parameters.Add("@CPF", MySqlDbType.VarChar).Value = cliente.CPF;
                    cmd.Parameters.Add("@Telefone", MySqlDbType.VarChar).Value = cliente.Telefone;
                    cmd.Parameters.Add("@Email", MySqlDbType.VarChar).Value = cliente.Email;
                    cmd.Parameters.Add("@Senha", MySqlDbType.VarChar).Value = cliente.Senha;
                    cmd.Parameters.Add("@Situacao", MySqlDbType.VarChar).Value = Situacao;
                    cmd.ExecuteNonQuery();
                    conexao.Close();
                }

            }
            catch (MySqlException ex)
            {
                throw new Exception("Erro no banco ao atualizar cliente" + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro na aplicação ao atualizar cliente" + ex.Message);
            }
        }

        public Cliente BuscaCpfCliente(string CPF)
        {
            throw new NotImplementedException();
        }

        public Cliente BuscaEmailCliente(string email)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(Cliente cliente)
        {
            string Situacao = SituacaoConstantes.Ativo;
            try
            {
                using (var conexao = new MySqlConnection(_conexaoMySQL))
                {
                    conexao.Open();

                    MySqlCommand cmd = new MySqlCommand("insert into Cliente(Nome, Nascimento, Sexo,  CPF, Telefone, Email, Senha, Situacao) " +
                    " values (@Nome, @Nascimento, @Sexo, @CPF, @Telefone, @Email, @Senha, @Situacao)", conexao); // @: PARAMETRO


                    cmd.Parameters.Add("@Nome", MySqlDbType.VarChar).Value = cliente.Nome;
                    cmd.Parameters.Add("@Nascimento", MySqlDbType.DateTime).Value = cliente.Nascimento.ToString("yyyy/MM/dd");
                    cmd.Parameters.Add("@Sexo", MySqlDbType.VarChar).Value = cliente.Sexo;
                    cmd.Parameters.Add("@CPF", MySqlDbType.VarChar).Value = cliente.CPF;
                    cmd.Parameters.Add("@Telefone", MySqlDbType.VarChar).Value = cliente.Telefone;
                    cmd.Parameters.Add("@Email", MySqlDbType.VarChar).Value = cliente.Email;
                    cmd.Parameters.Add("@Senha", MySqlDbType.VarChar).Value = cliente.Senha;
                    cmd.Parameters.Add("@Situacao", MySqlDbType.VarChar).Value = Situacao;

                    cmd.ExecuteNonQuery();
                    conexao.Close();
                }
            }
            catch (MySqlException ex)
            {
                throw new Exception("Erro no banco em cadastro cliente" + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro na aplicação em cadastro cliente" + ex.Message);
            }

        }

        public void Desativar(int id)
        {
            string Situacao = SituacaoConstantes.Desativo;
            using (var conexao = new MySqlConnection(_conexaoMySQL))
            {
                conexao.Open();
                MySqlCommand cmd = new MySqlCommand("update Cliente set Situacao=@Situacao WHERE Id=@Id ", conexao);

                cmd.Parameters.Add("@Id", MySqlDbType.VarChar).Value = Id;
                cmd.Parameters.Add("@Situacao", MySqlDbType.VarChar).Value = Situacao;
                cmd.ExecuteNonQuery();
                conexao.Close();
            }
        }

        public void Excluir(int id)
        {
            throw new NotImplementedException();
        }

        public Cliente Login(string Email, string Senha)
        {
            using (var conexao = new MySqlConnection(_conexaoMySQL))
            {
                conexao.Open();

                MySqlCommand cmd = new MySqlCommand("select * from cliente where Email = @Email and Senha = @Senha", conexao);
                //MySqlCommand cmd = new MySqlCommand("CALL proc_Login( _email, _senha)", conexao);

                cmd.Parameters.Add("@Email", MySqlDbType.VarChar).Value = Email;
                cmd.Parameters.Add("@Senha", MySqlDbType.VarChar).Value = Senha;

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                MySqlDataReader dr;

                Cliente cliente = new Cliente();
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                while (dr.Read())
                {
                    cliente.Id = Convert.ToInt32(dr["Id"]);
                    cliente.Nome = Convert.ToString(dr["Nome"]);
                    cliente.Nascimento = Convert.ToDateTime(dr["Nascimento"]);

                    cliente.Sexo = Convert.ToString(dr["Sexo"]);
                    cliente.CPF = Convert.ToString(dr["CPF"]);
                    cliente.Telefone = Convert.ToString(dr["Telefone"]);
                    cliente.Situacao = Convert.ToString(dr["Situacao"]);

                    cliente.Email = Convert.ToString(dr["Email"]);
                    cliente.Senha = Convert.ToString(dr["Senha"]);
                }
                return cliente;
            }
        }

        public Cliente ObterCliente(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Cliente> ObterTodosClientes()
        {
            List<Cliente> cliList = new List<Cliente>();
            using (var conexao = new MySqlConnection(_conexaoMySQL))
            {
                conexao.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM CLIENTE", conexao);

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);

                DataTable dt = new DataTable();

                da.Fill(dt);

                conexao.Close();

                foreach (DataRow dr in dt.Rows)
                {
                    cliList.Add(
                        new Cliente
                        {
                            Id = Convert.ToInt32(dr["Id"]),
                            Nome = (string)(dr["Nome"]),
                            Nascimento = Convert.ToDateTime(dr["Nascimento"]),
                            Sexo = Convert.ToString(dr["Sexo"]),
                            CPF = Convert.ToString(dr["CPF"]),
                            Telefone = Convert.ToString(dr["Telefone"]),
                            Email = Convert.ToString(dr["Email"]),
                            Senha = Convert.ToString(dr["Senha"]),
                            Situacao = Convert.ToString(dr["Situacao"])
                        });
                }
                return cliList;
            }
        }
    }
}
