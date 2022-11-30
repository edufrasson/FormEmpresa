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
    public partial class FrmCliente : Form
    {
        Cidade cidade;
        Cliente cliente;
        public FrmCliente()
        {
            
            InitializeComponent();
            carregarGrid("");
        }

        void limpaControles()
        {
            txtId.Clear();

            txtNome.Clear();
            txtCPF.Clear();
            txtRenda.Clear();
            dtpDataNasc.Value = DateTime.Now;
            chkVenda.Checked = false;
            txtUF.Clear();
            cboCidade.SelectedIndex = -1; 
            pictureBox1.ImageLocation = "";
            txtPesquisa.Clear();
        }

        void carregarGrid(string pesquisa)
        {
            cliente = new Cliente()
            {
                Nome = pesquisa
            };

            dgvCliente.DataSource = cliente.Consultar();
        }

        private void FrmCliente_Load(object sender, EventArgs e)
        {
            cidade = new Cidade();
            cboCidade.DataSource = cidade.Consultar();
            cboCidade.DisplayMember = "nome_cidade";
            cboCidade.ValueMember = "id";

            //dgvCliente.Columns["idCidade"].Visible = false;
            //dgvCliente.Columns["foto"].Visible = false;
        }

        private void dgvCliente_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtId.Text = dgvCliente.CurrentRow.Cells["id"].Value.ToString();
            txtNome.Text = dgvCliente.CurrentRow.Cells["nome"].Value.ToString();
            txtCPF.Text = dgvCliente.CurrentRow.Cells["cpf"].Value.ToString();
            chkVenda.Checked = bool.Parse(dgvCliente.CurrentRow.Cells["venda"].Value.ToString());
            txtRenda.Text = dgvCliente.CurrentRow.Cells["renda"].Value.ToString();
            dtpDataNasc.Text = dgvCliente.CurrentRow.Cells["dataNasc"].Value.ToString();
            txtUF.Text = dgvCliente.CurrentRow.Cells["uf"].Value.ToString();
            cboCidade.Text = dgvCliente.CurrentRow.Cells["nome_cidade"].Value.ToString();
            pictureBox1.ImageLocation = dgvCliente.CurrentRow.Cells["foto"].Value.ToString();
        }

        private void btnIncluir_Click(object sender, EventArgs e)
        {
            if (txtNome.Text == String.Empty)
                return;

            cliente = new Cliente
            {               
                Nome = txtNome.Text,
                CPF = txtCPF.Text,
                Renda = double.Parse(txtRenda.Text),
                Foto = pictureBox1.ImageLocation,
                Venda = chkVenda.Checked,
                DataNasc = dtpDataNasc.Value,
                Id_Cidade = (int)cboCidade.SelectedValue
            };

            cliente.Incluir();

            limpaControles();
            carregarGrid("");
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (txtId.Text == String.Empty)
                return;

            cliente = new Cliente()
            {
                Id = int.Parse(txtId.Text),
                Nome = txtNome.Text,
                CPF = txtCPF.Text,
                Renda = double.Parse(txtRenda.Text),
                Foto = pictureBox1.ImageLocation,
                Venda = chkVenda.Checked,
                DataNasc = dtpDataNasc.Value,
                Id_Cidade = (int)cboCidade.SelectedValue

            };
            cliente.Alterar();

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

            if (MessageBox.Show("Deseja excluir o cliente?", "Excluir",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                cliente = new Cliente()
                {
                    Id = int.Parse(txtId.Text)
                };

                cliente.Excluir();

                limpaControles();
                carregarGrid("");
            }
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            ofdArquivo.InitialDirectory = "E:/fotos/clientes";
            ofdArquivo.FileName = "";
            ofdArquivo.ShowDialog();
            pictureBox1.ImageLocation = ofdArquivo.FileName;
        }

        private void cboCidade_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cboCidade.SelectedIndex != -1)
            {
                DataRowView reg = (DataRowView)cboCidade.SelectedItem;
                txtUF.Text = reg["uf"].ToString();
            }
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            carregarGrid(txtPesquisa.Text);
        }
    }
}
