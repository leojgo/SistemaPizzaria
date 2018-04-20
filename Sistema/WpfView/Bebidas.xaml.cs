using Controllers;
using Models;
using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace WpfView
{
    /// <summary>
    /// Interaction logic for Bebidas.xaml
    /// </summary>
    public partial class Bebidas : Window
    {
        public Bebidas()
        {
            InitializeComponent();
        }


        private void BtnListarBebidas_Click(object sender, RoutedEventArgs e)
        {
            CarregarGrid();
        }

        private void BtnSalvarBebida_Click(object sender, RoutedEventArgs e)
        {
            Bebida bebida = SalvarBebida();
            BebidasController.SalvarBebidas(bebida);
            CarregarGrid();
            LimparCampos();
        }

        private Bebida SalvarBebida()
        {
            Bebida b = new Bebida();
            b.Nome = txtBebida.Text;
            b.Preco = double.Parse(txtPreco.Text);
            return b;
        }

        private void GridMostrarBebida_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (GridMostrarBebida.SelectedItem != null)
            {
                MessageBoxResult result = MessageBox.Show("Deseja editar a bebida " + ((Bebida)GridMostrarBebida.SelectedItem).Nome + " ?", "Edição", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    try
                    {
                        Bebida bebida = ((Bebida)GridMostrarBebida.SelectedItem);
                        EditarProdutos edit = new EditarProdutos();
                        edit.ProdutoEditarBebida(bebida, 2);
                        this.Close();
                        edit.ShowDialog();
                    }
                    catch (Exception erro)
                    {
                        MessageBox.Show("ERRO: " + erro);
                    }
                }
            }
        }

        private void LimparCampos()
        {
            txtBebida.Text = "";
            txtPreco.Text = "";
        }

        private async void CarregarGrid()
        {
            GridMostrarBebida.ItemsSource = await BebidasController.ListarTodasBebidas();
        }

        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {
        }

        private void btnVoltar_Click(object sender, RoutedEventArgs e)
        {
            MainWindow m = new MainWindow();
            this.Close();
            m.ShowDialog();
        }
    }
}