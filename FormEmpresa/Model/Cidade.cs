using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormEmpresa.Model
{
    public class Cidade
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string UF { get; set; }

       

        public void Incluir()
        {
            try
            {
                Banco.AbrirConexao();

                Banco.Comando = new MySqlCommand("INSERT INTO cidade (nome, uf) VALUES (@nome, @uf)", Banco.Conexao);

                Banco.Comando.Parameters.AddWithValue("@nome", Nome);
                Banco.Comando.Parameters.AddWithValue("@uf", UF);

                Banco.Comando.ExecuteNonQuery();

                Banco.FecharConexao();
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }

        public void Alterar()
        {
            try
            {
                Banco.AbrirConexao();

                Banco.Comando = new MySqlCommand("UPDATE cidade SET nome = @nome, uf = @uf WHERE id = @id", Banco.Conexao);

                Banco.Comando.Parameters.AddWithValue("@nome", Nome);
                Banco.Comando.Parameters.AddWithValue("@uf", UF);
                Banco.Comando.Parameters.AddWithValue("@id", Id);

                Banco.Comando.ExecuteNonQuery();

                Banco.FecharConexao();
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Excluir()
        {
            try
            {
                Banco.AbrirConexao();

                Banco.Comando = new MySqlCommand("DELETE FROM cidade WHERE id = @id", Banco.Conexao);
                
                Banco.Comando.Parameters.AddWithValue("@id", Id);

                Banco.Comando.ExecuteNonQuery();

                Banco.FecharConexao();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public DataTable Consultar()
        {
            try
            {
                Banco.AbrirConexao();

                Banco.Comando = new MySqlCommand("SELECT * FROM cidade WHERE nome LIKE @Nome ORDER BY nome", Banco.Conexao);

                Banco.Comando.Parameters.AddWithValue("@Nome", "%" + Nome + "%");
                Banco.Adaptador = new MySqlDataAdapter(Banco.Comando);
                Banco.datTabela = new DataTable();
                Banco.Adaptador.Fill(Banco.datTabela);          
                Banco.FecharConexao();

                return Banco.datTabela;
            }catch(Exception e)
            {
                MessageBox.Show(e.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
    }
}
