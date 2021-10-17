using System;
using System.Collections.Generic;
using MySqlConnector;
using Microsoft.AspNetCore.Http;
namespace projetoTc.Models
{
    public class UsuarioRepository
    {
        /*ENDEREÇO DE CONEXÃO*/
        private const string enderecoConexao = "Database=projetotc; Datasource=localhost; Username=root;Pwd=root";


        /**************************************USUÁRIOS**************************************************/

        /*CADASTRAR USUÁRIOS*/
        public void Insert(Usuario user)
        {

            MySqlConnection conexao = new MySqlConnection(enderecoConexao);

            conexao.Open();

            string sqlInsert = "INSERT INTO usuarios (nome,emailu, login, data_nascimento, senha, conta) VALUES (@nome, @emailu, @login, @data_nascimento, @senha, @conta)";

            MySqlCommand comando = new MySqlCommand(sqlInsert, conexao);

            comando.Parameters.AddWithValue("@nome", user.nome);
            comando.Parameters.AddWithValue("@emailu", user.emailu);
            comando.Parameters.AddWithValue("@login", user.login);
            comando.Parameters.AddWithValue("@data_nascimento", user.data_nascimento);
            comando.Parameters.AddWithValue("@senha", user.senha);
            comando.Parameters.AddWithValue("@conta", user.conta);

            comando.ExecuteNonQuery();

            conexao.Close();

        }

        /*LISTAR USUÁRIOS*/
        public List<Usuario> Listar_Usuarios()
        {

            MySqlConnection conexao = new MySqlConnection(enderecoConexao);

            conexao.Open();

            string sqlList = "SELECT * FROM usuarios ORDER BY nome";

            MySqlCommand comando = new MySqlCommand(sqlList, conexao);

            MySqlDataReader dados = comando.ExecuteReader();

            List<Usuario> lista = new List<Usuario>();

            while (dados.Read())
            {

                Usuario usuario = new Usuario();

                usuario.id = dados.GetInt32("id_usuarios");

                if (!dados.IsDBNull(dados.GetOrdinal("nome")))
                    usuario.nome = dados.GetString("nome");

                if (!dados.IsDBNull(dados.GetOrdinal("emailu")))
                    usuario.emailu = dados.GetString("emailu");

                if (!dados.IsDBNull(dados.GetOrdinal("data_nascimento")))
                    usuario.data_nascimento = dados.GetString("data_nascimento");

                if (!dados.IsDBNull(dados.GetOrdinal("senha")))
                    usuario.senha = dados.GetString("senha");

                if (!dados.IsDBNull(dados.GetOrdinal("login")))
                    usuario.login = dados.GetString("login");

                if (!dados.IsDBNull(dados.GetOrdinal("conta")))
                    usuario.conta = dados.GetString("conta");

                lista.Add(usuario);

            }

            conexao.Close();
            return lista;
        }

        /*ALTERAR USUÁRIOS*/
        public void Alterar(Usuario user)
        {

            MySqlConnection conexao = new MySqlConnection(enderecoConexao);

            conexao.Open();

            string sqlUpdate = "UPDATE usuarios set nome = @nome, emailu = @emailu, data_nascimento = @data_nascimento, login = @login, senha = @senha WHERE id_usuarios = @id";

            MySqlCommand comando = new MySqlCommand(sqlUpdate, conexao);

            comando.Parameters.AddWithValue("@id", user.id);
            comando.Parameters.AddWithValue("@nome", user.nome);
            comando.Parameters.AddWithValue("@emailu", user.emailu);
            comando.Parameters.AddWithValue("@data_nascimento", user.data_nascimento);
            comando.Parameters.AddWithValue("@login", user.login);
            comando.Parameters.AddWithValue("@senha", user.senha);

            comando.ExecuteNonQuery();

            conexao.Close();
        }

        /*EXCLUIR USUÁRIOS*/
        public void Excluir(int id)
        {

            MySqlConnection conexao = new MySqlConnection(enderecoConexao);

            conexao.Open();

            string sqlDelete = "DELETE FROM usuarios WHERE id_usuarios = @id";

            MySqlCommand comando = new MySqlCommand(sqlDelete, conexao);

            comando.Parameters.AddWithValue("@id", id);

            comando.ExecuteNonQuery();

            conexao.Close();
        }

        /*RETORNO DE USUÁRIO*/
        public Usuario RetornoUsuario(int id)
        {

            int id_user = id;

            MySqlConnection conexao = new MySqlConnection(enderecoConexao);

            conexao.Open();

            string sqlConsulta = "SELECT * FROM usuarios WHERE id_usuarios = @id";

            MySqlCommand comando = new MySqlCommand(sqlConsulta, conexao);

            comando.Parameters.AddWithValue("@id", id_user);

            MySqlDataReader dados = comando.ExecuteReader();

            dados.Read();

            Usuario usuario = new Usuario();

            usuario.id = dados.GetInt32("id_usuarios");

            if (!dados.IsDBNull(dados.GetOrdinal("nome")))
                usuario.nome = dados.GetString("nome");

            if (!dados.IsDBNull(dados.GetOrdinal("emailu")))
                usuario.emailu = dados.GetString("emailu");

            if (!dados.IsDBNull(dados.GetOrdinal("data_nascimento")))
                usuario.data_nascimento = dados.GetString("data_nascimento");

            if (!dados.IsDBNull(dados.GetOrdinal("login")))
                usuario.login = dados.GetString("login");

            if (!dados.IsDBNull(dados.GetOrdinal("senha")))
                usuario.senha = dados.GetString("senha");

            conexao.Close();
            return usuario;

        }


        /**************************************PACOTES***********************************************/

        /*CADASTRO DE PACOTES*/
        public void Insert_Pacotes(Pacotes pacote)
        {

            MySqlConnection conexao = new MySqlConnection(enderecoConexao);

            conexao.Open();

            string sqlInsert = "INSERT INTO pacotes (assunto, noticia, vereador, referencia, data, id_usuarios) VALUES (@assunto, @noticia, @vereador, @referencia, @data, @usuario)";

            MySqlCommand comando = new MySqlCommand(sqlInsert, conexao);

            comando.Parameters.AddWithValue("@assunto", pacote.assunto);
            comando.Parameters.AddWithValue("@noticia", pacote.noticia);
            comando.Parameters.AddWithValue("@vereador", pacote.vereador);
            comando.Parameters.AddWithValue("@referencia", pacote.referencia);
            comando.Parameters.AddWithValue("@data", pacote.data);
            comando.Parameters.AddWithValue("@usuario", pacote.usuario);

            comando.ExecuteNonQuery();

            conexao.Close();

        }

        /*LISTAGEM DE PACOTES*/
        public List<Pacotes> Listar_Pacotes()
        {

            MySqlConnection conexao = new MySqlConnection(enderecoConexao);

            conexao.Open();

            string sqlList = "SELECT * FROM pacotes ORDER BY assunto";

            MySqlCommand comando = new MySqlCommand(sqlList, conexao);

            MySqlDataReader dados = comando.ExecuteReader();

            List<Pacotes> lista = new List<Pacotes>();

            while (dados.Read())
            {

                Pacotes pacote = new Pacotes();

                pacote.id = dados.GetInt32("id_pacotes");

                if (!dados.IsDBNull(dados.GetOrdinal("assunto")))
                    pacote.assunto = dados.GetString("assunto");

                if (!dados.IsDBNull(dados.GetOrdinal("noticia")))
                    pacote.noticia = dados.GetString("noticia");

                if (!dados.IsDBNull(dados.GetOrdinal("vereador")))
                    pacote.vereador = dados.GetString("vereador");

                if (!dados.IsDBNull(dados.GetOrdinal("referencia")))
                    pacote.referencia = dados.GetString("referencia");

                if (!dados.IsDBNull(dados.GetOrdinal("data")))
                    pacote.data = dados.GetString("data");

                if (!dados.IsDBNull(dados.GetOrdinal("id_usuarios")))
                    pacote.usuario = dados.GetInt32("id_usuarios");

                lista.Add(pacote);

            }

            conexao.Close();
            return lista;
        }

        /*ALTERAÇÃO DE PACOTES*/
        public void Alterar_P(Pacotes p)
        {

            MySqlConnection conexao = new MySqlConnection(enderecoConexao);

            conexao.Open();

            string sqlUpdate = "UPDATE pacotes set assunto = @assunto, noticia = @noticia, vereador = @vereador, referencia = @referencia, data = @data WHERE id_pacotes = @id";

            MySqlCommand comando = new MySqlCommand(sqlUpdate, conexao);

            comando.Parameters.AddWithValue("@id", p.id);
            comando.Parameters.AddWithValue("@assunto", p.assunto);
            comando.Parameters.AddWithValue("@noticia", p.noticia);
            comando.Parameters.AddWithValue("@vereador", p.vereador);
            comando.Parameters.AddWithValue("@referencia", p.referencia);
            comando.Parameters.AddWithValue("@data", p.data);

            comando.ExecuteNonQuery();

            conexao.Close();
        }

        /*EXCLUSÃO DE PACOTES*/
        public void Excluir_P(int id)
        {

            MySqlConnection conexao = new MySqlConnection(enderecoConexao);

            conexao.Open();

            string sqlDelete = "DELETE FROM pacotes WHERE id_pacotes = @id";

            MySqlCommand comando = new MySqlCommand(sqlDelete, conexao);

            comando.Parameters.AddWithValue("@id", id);

            comando.ExecuteNonQuery();

            conexao.Close();
        }

        /*RETORNO DE PACOTES*/
        public Pacotes RetornoPacote(int id)
        {

            int id_pacote = id;

            MySqlConnection conexao = new MySqlConnection(enderecoConexao);

            conexao.Open();

            string sqlConsulta = "SELECT * FROM pacotes WHERE id_pacotes = @id";

            MySqlCommand comando = new MySqlCommand(sqlConsulta, conexao);

            comando.Parameters.AddWithValue("@id", id_pacote);

            MySqlDataReader dados = comando.ExecuteReader();

            dados.Read();

            Pacotes pacote = new Pacotes();

            pacote.id = dados.GetInt32("id_pacotes");

            if (!dados.IsDBNull(dados.GetOrdinal("assunto")))
                pacote.assunto = dados.GetString("assunto");

            if (!dados.IsDBNull(dados.GetOrdinal("noticia")))
                pacote.noticia = dados.GetString("noticia");

            if (!dados.IsDBNull(dados.GetOrdinal("vereador")))
                pacote.vereador = dados.GetString("vereador");

            if (!dados.IsDBNull(dados.GetOrdinal("referencia")))
                pacote.referencia = dados.GetString("referencia");

            if (!dados.IsDBNull(dados.GetOrdinal("data")))
                pacote.data = dados.GetString("data");

            conexao.Close();
            return pacote;
        }

        /**********************************************ATENDIMENTO*********************************************/

        /*REGISTRO DE ATENDIMENTO*/
        public void Insert_Atendimento(Atendimento a)
        {

            MySqlConnection conexao = new MySqlConnection(enderecoConexao);

            conexao.Open();

            string sqlInsert = "INSERT INTO atendimento (nome, email, duvida) VALUES (@nome, @email, @duvida)";

            MySqlCommand comando = new MySqlCommand(sqlInsert, conexao);

            comando.Parameters.AddWithValue("@nome", a.nome);
            comando.Parameters.AddWithValue("@email", a.email);
            comando.Parameters.AddWithValue("@duvida", a.duvida);

            comando.ExecuteNonQuery();

            conexao.Close();
          
        }


        /********************************************LOGIN************************************************************/

        public Usuario Login(Usuario user)
        {

            MySqlConnection conexao = new MySqlConnection(enderecoConexao);

            conexao.Open();

            string sqlLogin = "SELECT * FROM usuarios WHERE login = @login AND senha = @senha";

            MySqlCommand comando = new MySqlCommand(sqlLogin, conexao);

            comando.Parameters.AddWithValue("@login", user.login);
            comando.Parameters.AddWithValue("@senha", user.senha);

            MySqlDataReader dados = comando.ExecuteReader();

            Usuario us = null;

            if (dados.Read())
            {

                us = new Usuario();
                us.id = dados.GetInt32("id_usuarios");

                if (!dados.IsDBNull(dados.GetOrdinal("login")))
                    us.login = dados.GetString("login");

                if (!dados.IsDBNull(dados.GetOrdinal("senha")))
                    us.senha = dados.GetString("senha");

                if (!dados.IsDBNull(dados.GetOrdinal("conta")))
                    us.conta = dados.GetString("conta");

                if (!dados.IsDBNull(dados.GetOrdinal("nome")))
                    us.nome = dados.GetString("nome");
            }

            conexao.Close();
            return us;

        }




    }
}