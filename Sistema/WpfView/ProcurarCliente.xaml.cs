using Controllers;
using Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;

namespace WpfView
{
    /// <summary>
    /// Interaction logic for ProcurarCliente.xaml
    /// </summary>
    public partial class ProcurarCliente : Window
    {
        private ObservableCollection<Cliente> _clientes;

        public ProcurarCliente()
        {
            InitializeComponent();
            CarregarGrid();
        }

        private void ProcuraID(object sender, RoutedEventArgs e)
        {
            ProcurarClientePorID pID = new ProcurarClientePorID();
            this.Close();
            pID.ShowDialog();
        }

        private async Task CarregarGrid()
        {
            var clientList = await ClienteController.ListarTodosClientes();
            gridCliente.ItemsSource = new ObservableCollection<Cliente>(clientList);
        }

        private void btnVoltar_Click(object sender, RoutedEventArgs e)
        {
            MainWindow m = new MainWindow();
            this.Close();
            m.ShowDialog();
        }

        private void btnProcura_Click(object sender, RoutedEventArgs e)
        {
            string caracter = txtTelefone.Text.Substring(0, 1);
            string verifica = "^[0-9]";

            if ((txtTelefone.Text.Length != 0) && (Regex.IsMatch(caracter, verifica)))
            {
                List<Cliente> clientes = ClienteController.PesquisarPorTelefone(txtTelefone.Text);
                if (clientes.Count > 0)
                {
                    gridCliente.ItemsSource = clientes;
                }
                else
                {
                    if (MessageBox.Show("Cliente não encontrado, deseja cadastrar novo cliente ?", "Cliente não encontrado", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        CadastrarCliente cad = new CadastrarCliente();
                        this.Close();
                        cad.ShowDialog();
                    }
                }
            }
            else
            {
                MessageBox.Show("Só é aceito campo númerico e que não esteja vazio.");
            }
        }

        private void MensagemErro()
        {
            MessageBoxResult result = MessageBox.Show("Telefone não cadastrado ! Deseja cadastrar cliente ?", "Cliente não encontrado", MessageBoxButton.YesNo, MessageBoxImage.Error);
            if (result == MessageBoxResult.Yes)
            {
                CadastrarCliente ccli = new CadastrarCliente();
                this.Close();
                ccli.ShowDialog();
            }
        }

        private void gridCliente_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            FazerPedido pedido = new FazerPedido();
            pedido.MostrarCliente((Cliente)gridCliente.SelectedItem);
            this.Close();
            pedido.ShowDialog();
        }
    }
}