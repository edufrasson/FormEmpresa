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
    public class Categoria
    {
        public int Id { get; set; }
        public string Descricao { get; set; }

        public void Incluir()
        {
            try
            {
                Banco.AbrirConexao();

                Banco.Comando = new MySqlCommand("INSERT INTO Categoria (descricao_categoria) VALUES (@desc)", Banco.Conexao);

                Banco.Comando.Parameters.AddWithValue("@desc", Descricao);

                Banco.Comando.ExecuteNonQuery();

                Banco.FecharConexao();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public void Alterar()
        {
            try
            {
                Banco.AbrirConexao();

                Banco.Comando = new MySqlCommand("UPDATE Categoria SET descricao_categoria = @desc WHERE id = @id", Banco.Conexao);

                Banco.Comando.Parameters.AddWithValue("@desc", Descricao);
                Banco.Comando.Parameters.AddWithValue("@id", Id);

                Banco.Comando.ExecuteNonQuery();

                Banco.FecharConexao();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Excluir()
        {
            try
            {
                Banco.AbrirConexao();

                Banco.Comando = new MySqlCommand("DELETE FROM Categoria WHERE id = @id", Banco.Conexao);

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

                Banco.Comando = new MySqlCommand("SELECT * FROM Categoria WHERE descricao_categoria LIKE @Desc ORDER BY descricao_categoria", Banco.Conexao);

                Banco.Comando.Parameters.AddWithValue("@Desc", "%" + Descricao + "%");
                Banco.Adaptador = new MySqlDataAdapter(Banco.Comando);
                Banco.datTabela = new DataTable();
                Banco.Adaptador.Fill(Banco.datTabela);
                Banco.FecharConexao();

                return Banco.datTabela;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
    }
}
