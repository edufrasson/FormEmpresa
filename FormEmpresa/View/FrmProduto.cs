using FormEmpresa.Model;
using MySqlX.XDevAPI;
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
    public partial class FrmProduto : Form
    {
        Produto produto;
        Categoria categoria;
        Marca marca;
        public FrmProduto()
        {
            InitializeComponent();
            carregarGrid("");
        }

        void limpaControles()
        {
            txtId.Clear();

            txtDescricao.Clear();
            txtValor.Clear();
            txtEstoque.Clear();              
            cboCategoria.SelectedIndex = -1;
            cboMarca.SelectedIndex = -1;
            pictureBox1.ImageLocation = "";
            txtPesquisa.Clear();
        }

        void carregarGrid(string pesquisa)
        {
            produto = new Produto()
            {
                Descricao = pesquisa
            };

            dgvProduto.DataSource = produto.Consultar();
        }

        private void btnIncluir_Click(object sender, EventArgs e)
        {
            if (txtDescricao.Text == String.Empty)
                return;

            produto = new Produto
            {
                Descricao = txtDescricao.Text,
                Valor = double.Parse(txtValor.Text),
                Estoque = int.Parse(txtEstoque.Text),
                Foto = pictureBox1.ImageLocation,              
                Id_Marca = (int)cboMarca.SelectedValue,
                Id_Categoria = (int)cboCategoria.SelectedValue
            };

            produto.Incluir();

            limpaControles();
            carregarGrid("");
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (txtDescricao.Text == String.Empty)
                return;

            produto = new Produto
            {
                Id = int.Parse(txtId.Text),
                Descricao = txtDescricao.Text,
                Valor = double.Parse(txtValor.Text),
                Estoque = int.Parse(txtEstoque.Text),
                Foto = pictureBox1.ImageLocation,
                Id_Marca = (int)cboMarca.SelectedValue,
                Id_Categoria = (int)cboCategoria.SelectedValue
            };

            produto.Alterar();

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

            if (MessageBox.Show("Deseja excluir o produto?", "Excluir",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                produto = new Produto()
                {
                    Id = int.Parse(txtId.Text)
                };

                produto.Excluir();

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

        private void dgvProduto_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtId.Text = dgvProduto.CurrentRow.Cells["id"].Value.ToString();
            txtDescricao.Text = dgvProduto.CurrentRow.Cells["descricao"].Value.ToString();
            txtValor.Text = dgvProduto.CurrentRow.Cells["valor"].Value.ToString();            
            txtEstoque.Text = dgvProduto.CurrentRow.Cells["estoque"].Value.ToString();           
            cboCategoria.Text = dgvProduto.CurrentRow.Cells["descricao_categoria"].Value.ToString();
            cboMarca.Text = dgvProduto.CurrentRow.Cells["descricao_marca"].Value.ToString();
            pictureBox1.ImageLocation = dgvProduto.CurrentRow.Cells["foto"].Value.ToString();
        }

        private void FrmProduto_Load(object sender, EventArgs e)
        {
            categoria = new Categoria();            
            cboCategoria.DataSource = categoria.Consultar();
            cboCategoria.DisplayMember = "descricao_categoria";
            cboCategoria.ValueMember = "id";

            marca = new Marca();
            cboMarca.DataSource = marca.Consultar();
            cboMarca.DisplayMember = "descricao_marca";
            cboMarca.ValueMember = "id";
        }
    }
}
