using FormEmpresa.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace FormEmpresa.View
{
    public partial class FrmMarca : Form
    {
        Marca marca;
        public FrmMarca()
        {
            InitializeComponent();
        }

        void limpaControles()
        {
            txtId.Clear();
            txtDescricao.Clear();
           
            txtPesquisa.Clear();
        }

        void carregarGrid(string pesquisa)
        {
            marca = new Marca()
            {
                Descricao = pesquisa
            };

            dgvMarca.DataSource = marca.Consultar();
        }

        private void btnIncluir_Click(object sender, EventArgs e)
        {
            if (txtDescricao.Text == String.Empty)
                return;

            marca = new Marca()
            {
                Descricao = txtDescricao.Text                
            };

            marca.Incluir();

            limpaControles();
            carregarGrid("");
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (txtId.Text == String.Empty)
                return;

            marca = new Marca()
            {
                Id = int.Parse(txtId.Text),
                Descricao = txtDescricao.Text,
                
            };
            marca.Alterar();

            limpaControles();
            carregarGrid("");
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            limpaControles();
            carregarGrid("");
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (txtId.Text == "")
                return;

            if (MessageBox.Show("Deseja excluir a marca?", "Excluir",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                marca = new Marca()
                {
                    Id = int.Parse(txtId.Text)
                };

                marca.Excluir();

                limpaControles();
                carregarGrid("");
            }
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            carregarGrid(txtPesquisa.Text);
        }

        private void dgvMarca_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvMarca.RowCount > 0)
            {
                txtId.Text = dgvMarca.CurrentRow.Cells["id"].Value.ToString();
                txtDescricao.Text = dgvMarca.CurrentRow.Cells["descricao_marca"].Value.ToString();               
            }
        }

        private void dgvMarca_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtDescricao_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtId_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
