using FormEmpresa.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormEmpresa.View
{
    public partial class FrmCategoria : Form
    {
        Categoria categoria;
        public FrmCategoria()
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
            categoria = new Categoria()
            {
                Descricao = pesquisa
            };

            dgvCategoria.DataSource = categoria.Consultar();
        }

        private void btnIncluir_Click(object sender, EventArgs e)
        {
            if (txtDescricao.Text == String.Empty)
                return;

            categoria = new Categoria()
            {
                Descricao = txtDescricao.Text
            };

            categoria.Incluir();

            limpaControles();
            carregarGrid("");
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (txtId.Text == String.Empty)
                return;

            categoria = new Categoria()
            {
                Id = int.Parse(txtId.Text),
                Descricao = txtDescricao.Text,

            };
            categoria.Alterar();

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

            if (MessageBox.Show("Deseja excluir a categoria?", "Excluir",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                categoria = new Categoria()
                {
                    Id = int.Parse(txtId.Text)
                };

                categoria.Excluir();

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

        private void dgvCategoria_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvCategoria.RowCount > 0)
            {
                txtId.Text = dgvCategoria.CurrentRow.Cells["id"].Value.ToString();
                txtDescricao.Text = dgvCategoria.CurrentRow.Cells["descricao"].Value.ToString();
            }

        }
    }
}
