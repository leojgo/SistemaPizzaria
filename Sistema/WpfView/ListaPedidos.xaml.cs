using Controllers;
using Models;
using System.Collections.Generic;
using System.Windows;

namespace WpfView
{
    /// <summary>
    /// Interaction logic for ListaPedidos.xaml
    /// </summary>
    public partial class ListaPedidos : Window
    {
        public ListaPedidos()
        {
            InitializeComponent();
            MostrarGrid();
        }

        private void MostrarGrid()
        {
            List<Pedido> list = PedidoController.ListarTodosPedidos();
            if (list != null)
            {
                gridPedidos.ItemsSource = list;
            }
            else
            {
                MessageBox.Show("Nenhum pedido cadastrado");
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow tela = new MainWindow();
            this.Close();
            tela.ShowDialog();
        }
    }
}