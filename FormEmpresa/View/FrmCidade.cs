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
    public partial class FrmCidade : Form
    {
        Cidade cidade;
        public FrmCidade()
        {
            InitializeComponent();
            carregarGrid("");
        }

        void limpaControles()
        {
            txtId.Clear();
            txtNome.Clear();
            txtUf.Clear();
            txtPesquisa.Clear();
        }

        void carregarGrid(string pesquisa)
        {
            cidade = new Cidade()
            {
                Nome = pesquisa
            };

            dgvCidades.DataSource = cidade.Consultar();
        }

        

        private void btnIncluir_Click(object sender, EventArgs e)
        {
            if(txtNome.Text == String.Empty)
                return;

            cidade = new Cidade
            { 
                Nome = txtNome.Text,
                UF = txtUf.Text
            };

            cidade.Incluir();

            limpaControles();
            carregarGrid("");
        }

        private void dgvCidades_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dgvCidades.RowCount > 0)
            {
                txtId.Text = dgvCidades.CurrentRow.Cells["id"].Value.ToString();
                txtNome.Text = dgvCidades.CurrentRow.Cells["nome"].Value.ToString();
                txtUf.Text = dgvCidades.CurrentRow.Cells["uf"].Value.ToString();
            }
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if(txtId.Text == String.Empty)
                return ;

            cidade = new Cidade()
            {
                Id = int.Parse(txtId.Text),
                Nome = txtNome.Text,
                UF = txtUf.Text
            };
            cidade.Alterar();

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

            if(MessageBox.Show("Deseja excluir a cidade?", "Excluir",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                cidade = new Cidade()
                {
                    Id = int.Parse(txtId.Text)
                };

                cidade.Excluir();

                limpaControles();
                carregarGrid("");
            }
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            carregarGrid(txtPesquisa.Text);
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
