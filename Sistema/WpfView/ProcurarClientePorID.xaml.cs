using Controllers;
using Models;
using System;
using System.Text.RegularExpressions;
using System.Windows;

namespace WpfView
{
    /// <summary>
    /// Interaction logic for ProcurarClientePorID.xaml
    /// </summary>
    public partial class ProcurarClientePorID : Window
    {
        public ProcurarClientePorID()
        {
            InitializeComponent();
        }

        private void btnVoltar_Click(object sender, RoutedEventArgs e)
        {
            MainWindow m = new MainWindow();
            this.Close();
            m.ShowDialog();
        }

        private void btnProcurar_Click(object sender, RoutedEventArgs e)
        {
            string caracter = txtID.Text.Substring(0, 1);
            string verifica = "^[0-9]";

            if ((Regex.IsMatch(caracter, verifica) || (txtID.Text != null)))
            {
                Cliente cliente = ClienteController.PesquisarPorID(int.Parse(txtID.Text));

                if (cliente != null)
                {
                    blockID.Text = Convert.ToString(cliente.ClienteID);
                    txtNome.Text = cliente.Nome;
                    txtCPF.Text = cliente.Cpf;
                    txtTelefone.Text = cliente.Telefone;
                    txtRua.Text = cliente.Endereco.Rua;
                    txtNumero.Text = Convert.ToString(cliente.Endereco.Numero);
                    txtBairro.Text = cliente.Endereco.Bairro;
                    txtComplemento.Text = cliente.Endereco.Complemento;
                    txtReferencia.Text = cliente.Endereco.Referencia;
                }
                else
                {
                    MessageBox.Show("ID não encontrado");
                }
            }
            else
            {
                MessageBox.Show("Campo inválido, digite apenas números.");
            }
        }

        /* private void GridMostrar_SelectionChanged(object sender, SelectionChangedEventArgs e)
         {
             if (GridMostrar.SelectedItem != null)
             {
                 MessageBoxResult result = MessageBox.Show("Deseja editar o cliente de nome: " + ((Cliente)GridMostrar.SelectedItem).Nome + " ?", "Editar", MessageBoxButton.YesNo, MessageBoxImage.Question);
                 if (result == MessageBoxResult.Yes)
                 {
                     try
                     {
                         Cliente cli = ((Cliente)GridMostrar.SelectedItem);
                         EditarCliente edit = new EditarCliente();
                         edit.EditarNome(cli);
                         this.Close();
                         edit.ShowDialog();
                     }
                     catch (Exception erro)
                     {
                         MessageBox.Show("ERRO: " + erro);
                     }
                 }
                 else
                 {
                     FazerPedido pedido = new FazerPedido();
                     pedido.MostrarCliente(((Cliente)GridMostrar.SelectedItem).ClienteID);
                     this.Close();
                     pedido.ShowDialog();
                 }
             }
         }*/
    }
}