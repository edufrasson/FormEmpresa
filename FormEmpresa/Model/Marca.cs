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
    public class Marca
    {
        public int Id { get; set; }
        public string Descricao { get; set; }

        public void Incluir()
        {
            try
            {
                Banco.AbrirConexao();

                Banco.Comando = new MySqlCommand("INSERT INTO Marca (descricao) VALUES (@desc)", Banco.Conexao);

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

                Banco.Comando = new MySqlCommand("UPDATE Marca SET descricao = @desc WHERE id = @id", Banco.Conexao);

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

                Banco.Comando = new MySqlCommand("DELETE FROM Marca WHERE id = @id", Banco.Conexao);

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

                Banco.Comando = new MySqlCommand("SELECT * FROM Marca WHERE descricao LIKE @Desc ORDER BY descricao", Banco.Conexao);

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
