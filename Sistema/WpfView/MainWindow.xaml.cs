using System.Windows;

namespace WpfView
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnRealizarPedido_Click(object sender, RoutedEventArgs e)
        {
            ProcurarCliente cl = new ProcurarCliente();
            this.Close();
            cl.ShowDialog();
        }

        private void btnCadastrar_Click(object sender, RoutedEventArgs e)
        {
            CadastrarCliente cc = new CadastrarCliente();
            this.Close();
            cc.ShowDialog();
        }

        private void ItemPizzas_Click(object sender, RoutedEventArgs e)
        {
            CadastroPizzas cp = new CadastroPizzas();
            this.Close();
            cp.ShowDialog();
        }

        private void ItemBebibas_Click(object sender, RoutedEventArgs e)
        {
            Bebidas b = new Bebidas();
            this.Close();
            b.ShowDialog();
        }

        private void Exclusao_Click(object sender, RoutedEventArgs e)
        {
            AreaAdministrativa ad = new AreaAdministrativa();
            this.Close();
            ad.ShowDialog();
        }

        private void ItemPedidoAndamento_Click(object sender, RoutedEventArgs e)
        {
            PedidosStatus tela = new PedidosStatus();
            this.Close();
            tela.ShowDialog();
        }

        private void ItemListaPedidos_Click(object sender, RoutedEventArgs e)
        {
            ListaPedidos tela = new ListaPedidos();
            this.Close();
            tela.ShowDialog();
        }

        private void ListagemCliente_Click(object sender, RoutedEventArgs e)
        {
            var tela = new ListagemClientes();
            Close();
            tela.Show();
        }

        private void BuscaCLiente_Click(object sender, RoutedEventArgs e)
        {
            var buscaCliente = new ProcurarCliente();
            Close();
            buscaCliente.Show();
        }
    }
}