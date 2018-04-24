using Controllers;
using Models;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace WpfView
{
    /// <summary>
    /// Interaction logic for FazerPedido.xaml
    /// </summary>
    public partial class FazerPedido : Window
    {
        private double valorTotal = 0;
        private Cliente clientePedido;
        private ObservableCollection<Pizza> _pizzasEscolhidas;
        private ObservableCollection<Pizza> _pizzas;
        private ObservableCollection<PedidoPizza> _pedidoPizzas;

        public FazerPedido()
        {
            InitializeComponent();
            _pizzasEscolhidas = new ObservableCollection<Pizza>();
            _pedidoPizzas = new ObservableCollection<PedidoPizza>();
            MostrarGrid();
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            MainWindow tela = new MainWindow();
            if (MessageBox.Show("Deseja cancelar pedido ?", "Cancelar pedido", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                tela.Show();
                this.Close();
            }
        }

        public void MostrarCliente(Cliente cliente)
        {
            blockCliente.Text = cliente.Nome;
            blockTelefone.Text = cliente.Telefone;
            clientePedido = cliente;
        }

        private void AdicionarPizza(Pizza pizza)
        {
            if (_pedidoPizzas.Count > 0)
            {
                var existe = (from p in _pedidoPizzas where p.PizzaID == pizza.PizzaID select p).SingleOrDefault();
                if (existe != null)
                {
                    existe.Quantidade++;
                    return;
                }
            }
            _pedidoPizzas.Add(new PedidoPizza { PizzaID = pizza.PizzaID, Quantidade = 1, Tamanho = TamanhoPizzaEnum.Media });
        }

        private async void MostrarGrid()
        {
            gridPizzasEscolhidas.ItemsSource = _pizzasEscolhidas;
            _pizzas = new ObservableCollection<Pizza>(await PizzaController.ListarTodasPizzas());
            gridPizza.ItemsSource = _pizzas;
        }

        private void gridPizza_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            _pizzasEscolhidas.Add(gridPizza.SelectedItem as Pizza);
            AtualizarTotal();
        }

        private void gridPizzasEscolhidas_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            _pizzasEscolhidas.Remove(gridPizzasEscolhidas.SelectedItem as Pizza);
            AtualizarTotal();
        }

        private void AtualizarTotal()
        {
            valorTotal = _pizzasEscolhidas.Sum(x => x.Preco);
            blockValorTotal.Text = Convert.ToString(valorTotal);
        }

        private void SalvarPedido()
        {
            _pizzasEscolhidas.ToList().ForEach(AdicionarPizza);
            var pedido = new Pedido
            {
                ClienteID = clientePedido.ClienteID,
                Pizzas = _pedidoPizzas,
                Status = StatusPedidoEnum.Em_Producao,
                ValorTotal = valorTotal,
                Data = DateTime.Now
            };
            PedidoController.SalvarPedido(pedido);
        }

        private void btnConfirmar_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Confirmar pedido ?", "Confirma Pedido", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                SalvarPedido();
                MessageBox.Show("Pedido finalizado");
                MainWindow tela = new MainWindow();
                this.Close();
                tela.ShowDialog();
            }
        }

        private void Bebidas_Click(object sender, RoutedEventArgs e)
        {
            PedidoBebidas bebidas = new PedidoBebidas();
            bebidas.MostrarClienteParteBebidas(clientePedido, valorTotal);
            this.Close();
            bebidas.ShowDialog();
        }
    }
}