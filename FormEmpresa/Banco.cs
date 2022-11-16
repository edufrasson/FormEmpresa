using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormEmpresa
{
    public class Banco
    {

        public static MySqlConnection Conexao;
        public static MySqlCommand Comando;
        public static MySqlDataAdapter Adaptador;
        public static DataTable datTabela;

        public static void AbrirConexao()
        {
            try
            {

                Conexao = new MySqlConnection("server=localhost;port=3307;uid=root;pwd=etecjau");
                Conexao.Open();

            }catch(Exception e)
            {
                MessageBox.Show(e.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void FecharConexao()
        {
            try
            {                
                Conexao.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void CriarBanco()
        {
            try
            {
                AbrirConexao();
                Comando = new MySqlCommand("CREATE DATABASE IF NOT EXISTS db_empresa; USE db_empresa", Conexao);
                Comando.ExecuteNonQuery();

                Comando = new MySqlCommand("CREATE TABLE IF NOT EXISTS Cidade(" +
                                            "id int auto_increment, " +  
                                            "nome_cidade varchar(100), " +
                                            "uf char(2), " + "primary key(id)); ", Conexao);

                Comando.ExecuteNonQuery();

                Comando = new MySqlCommand("CREATE TABLE IF NOT EXISTS Marca(" +
                                           "id int auto_increment, " +
                                           "descricao varchar(100), "
                                            + "primary key(id)); ", Conexao);

                Comando.ExecuteNonQuery();

                Comando = new MySqlCommand("CREATE TABLE IF NOT EXISTS Categoria(" +
                                           "id int auto_increment, " +
                                           "descricao varchar(100), "
                                            + "primary key(id)); ", Conexao);

                Comando.ExecuteNonQuery();

                Comando = new MySqlCommand("CREATE TABLE IF NOT EXISTS Cliente(" +
                                           "id int auto_increment, " +
                                           "nome varchar(100), " +
                                           "id_cidade int, " +
                                           "dataNasc date," +
                                           "renda decimal(10, 2)," +
                                           "cpf varchar(14)," +
                                           "foto varchar(100)," +
                                           "venda boolean,"
                                            + "primary key(id)); ", Conexao);

                Comando.ExecuteNonQuery();
                FecharConexao();
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
