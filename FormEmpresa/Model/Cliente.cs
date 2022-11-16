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
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Id_Cidade { get; set; }
        public int CPF { get; set; }
        public DateTime DataNasc { get; set; }
        public double Renda { get; set; }
        public string Foto { get; set; }
        public bool Venda { get; set; }

        public void Incluir()
        {
            try
            {
                Banco.AbrirConexao();

                Banco.Comando = new MySqlCommand("INSERT INTO Cliente (nome, id_cidade, cpf,  dataNasc, renda, foto, venda) VALUES (@nome, @id_cidade, @cpf, @dataNasc, @renda, @foto, @venda)", Banco.Conexao);

                Banco.Comando.Parameters.AddWithValue("@nome", Nome);
                Banco.Comando.Parameters.AddWithValue("@id_cidade", Id_Cidade);
                Banco.Comando.Parameters.AddWithValue("@cpf", CPF);
                Banco.Comando.Parameters.AddWithValue("@dataNasc", DataNasc);
                Banco.Comando.Parameters.AddWithValue("@renda", Renda);
                Banco.Comando.Parameters.AddWithValue("@foto", Foto);
                Banco.Comando.Parameters.AddWithValue("@venda", Venda);

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

                Banco.Comando = new MySqlCommand("UPDATE cidade SET nome = @nome, id_cidade = @id_cidade, cpf = @cpf, dataNasc = @dataNasc, renda = @renda, venda = @venda WHERE id = @id", Banco.Conexao);

                Banco.Comando.Parameters.AddWithValue("@nome", Nome);
                Banco.Comando.Parameters.AddWithValue("@id_cidade", Id_Cidade);
                Banco.Comando.Parameters.AddWithValue("@cpf", CPF);
                Banco.Comando.Parameters.AddWithValue("@dataNasc", DataNasc);
                Banco.Comando.Parameters.AddWithValue("@renda", Renda);
                Banco.Comando.Parameters.AddWithValue("@venda", Venda);                
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

                Banco.Comando = new MySqlCommand("DELETE FROM Cliente WHERE id = @id", Banco.Conexao);

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

                Banco.Comando = new MySqlCommand("SELECT * FROM Cliente WHERE nome LIKE @Nome ORDER BY nome", Banco.Conexao);

                Banco.Comando.Parameters.AddWithValue("@Nome", "%" + Nome + "%");
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
