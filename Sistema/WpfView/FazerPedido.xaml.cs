using Controllers;
using Models;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

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

        public FazerPedido()
        {
            InitializeComponent();
            _pizzasEscolhidas = new ObservableCollection<Pizza>();
            MostrarGrid();
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            MainWindow w = new MainWindow();
            this.Close();
            w.ShowDialog();
        }

        public void MostrarCliente(Cliente cliente)
        {
            blockCliente.Text = cliente.Nome;
            blockTelefone.Text = cliente.Telefone;
            clientePedido = cliente;
        }

        private void MostrarGrid()
        {
            gridPizzasEscolhidas.ItemsSource = _pizzasEscolhidas;
            _pizzas = new ObservableCollection<Pizza>(PizzaController.ListarTodasPizzas());
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

        private void SalvandoTabelaEscolhidos()
        {
            Pizza pizzaEscolhida = ((Pizza)gridPizza.SelectedItem);
            SalvarPedido(pizzaEscolhida);
            valorTotal += ((Pizza)gridPizza.SelectedItem).Preco;
            blockValorTotal.Text = Convert.ToString(valorTotal);
        }

        private void btnConfirmar_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Confirmar pedido ?", "Confirma Pedido", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                SalvandoNaTabelaPedidos();
                MessageBox.Show("Pedido finalizado");
                MainWindow tela = new MainWindow();
                this.Close();
                tela.ShowDialog();
            }
        }

        private void SalvarPedido(Pizza pizza)
        {
            /*ClientesPizzas novo = new ClientesPizzas();
            novo.ClienteID = clientePedido.ClienteID;
            novo.PizzaID = pizza.PizzaID;
            novo.Preco = pizza.Preco;
            DateTime data = DateTime.Now;
            novo.Data = data;
            ClientesPizzasController.SalvarItem(novo);
            MostrarGridPizzasEscolhidas();*/
        }

        private void MostrarGridPizzasEscolhidas()
        {
            //List<ClientesPizzas> list = ClientesPizzasController.PesquisarClientePedidos(clientePedido.ClienteID);
            //gridPizzasEscolhidas.ItemsSource = list;
        }

        private void SalvandoNaTabelaPedidos()
        {
            //List<ClientesPizzas>list=ClientesPizzasController.PesquisarClientePedidos(clientePedido.ClienteID);
            Pedido novoPed = new Pedido();

            /* foreach (var item in list)
             {
                 novoPed.Status = "EM PRODUÇÃO";
                 novoPed.ClientesProdutosEscolhidosID = item.ClientesPizzasID;
                 novoPed.NumPedido = numPedido;
                 novoPed.ValorTotal = double.Parse(blockValorTotal.Text);
                 novoPed.Tamanho_Pizza = TamPizza;
                 PedidoController.SalvarPedido(novoPed);
             }*/
        }

        private void Bebidas_Click(object sender, RoutedEventArgs e)
        {
            PedidoBebidas bebidas = new PedidoBebidas();
            bebidas.MostrarClienteParteBebidas(clientePedido, valorTotal);
            this.Close();
            bebidas.ShowDialog();
        }

        private void gridPizzasEscolhidas_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (gridPizzasEscolhidas.SelectedItem != null)
            {
                /*MessageBoxResult result = MessageBox.Show("Confirma a exclusão do item " + ((ClientesPizzas)gridPizzasEscolhidas.SelectedItem).ClientesPizzasID + " ?", "Exclusão", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    try
                    {
                        //int id = ((ClientesPizzas)gridPizzasEscolhidas.SelectedItem).ClientesPizzasID;
                        //ClientesPizzasController.ExcluirSelecao(id);
                        MessageBox.Show("Item excluído com sucesso");
                        //valorTotal -= ((ClientesPizzas)gridPizzasEscolhidas.SelectedItem).Preco;
                        blockValorTotal.Text = Convert.ToString(valorTotal);
                        MostrarGrid();
                        MostrarGridPizzasEscolhidas();
                    }
                    catch (Exception erro)
                    {
                        MessageBox.Show("ERRO: " + erro);
                    }
                }*/
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MainWindow tela = new MainWindow();
            if (MessageBox.Show("Deseja cancelar pedido ?", "Cancelar pedido", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                tela.Show();
            }
        }
    }
}