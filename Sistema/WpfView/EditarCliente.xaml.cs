using Controllers;
using Models;
using System;
using System.Text.RegularExpressions;
using System.Windows;

namespace WpfView
{
    /// <summary>
    /// Interaction logic for EditarCliente.xaml
    /// </summary>
    public partial class EditarCliente : Window
    {
        private Cliente cliEdicao;

        public EditarCliente()
        {
            InitializeComponent();
        }

        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {
            EnviarClienteEditado(txtNome.Text, txtCPF.Text, txtTelefone.Text);
            MessageBox.Show("Cliente editado");
            FazerPedido pedido = new FazerPedido();
            pedido.MostrarCliente(cliEdicao);
            this.Close();
            pedido.ShowDialog();
        }

        private void btnVoltar_Click(object sender, RoutedEventArgs e)
        {
            MainWindow m = new MainWindow();
            this.Close();
            m.ShowDialog();
        }

        public void Editar(Cliente cliente)
        {
            txtNome.Text = cliente.Nome;
            txtCPF.Text = cliente.Cpf;
            txtTelefone.Text = cliente.Telefone;
            txtRua.Text = cliente.Endereco.Rua;
            txtNumero.Text = Convert.ToString(cliente.Endereco.Numero);
            txtBairro.Text = cliente.Endereco.Bairro;
            txtComplemento.Text = cliente.Endereco.Complemento;
            txtReferencia.Text = cliente.Endereco.Referencia;
            cliEdicao = cliente;
            ClienteController.EditarCliente(cliente.ClienteID, cliente);
        }

        private void EnviarClienteEditado(string Nome, string CPF, string Telefone)
        {
            Cliente cliente = new Cliente();
            cliente.Nome = Nome;
            cliente.Cpf = CPF;
            cliente.Telefone = Telefone;

            ClienteController.EditarCliente(cliEdicao.ClienteID, cliente);
        }

        private bool VerificarItens()
        {
            string caracter = txtNumero.Text.Substring(0, 1);
            string verifica = "^[0-9]";

            if (!Regex.IsMatch(txtNome.Text, @"^[a-zA-Z]+$") || (txtNome.Text == null))
            {
                MessageBox.Show("ERRO, digite apenas caracter");
                return false;
            }
            else if ((!Regex.IsMatch(caracter, verifica) || txtCPF.Text.Length.Equals(11) == false) || (txtCPF.Text == null))
            {
                MessageBox.Show("Erro ! Digite 11 dígitos no CPF e apenas números");
                return false;
            }
            else if (!Regex.IsMatch(txtTelefone.Text, verifica) || (txtTelefone.Text == null))
            {
                return false;
            }
            else if ((txtRua.Text == null))
            {
                return false;
            }
            else if (!Regex.IsMatch(txtNumero.Text, verifica) || (txtNumero.Text == null))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}