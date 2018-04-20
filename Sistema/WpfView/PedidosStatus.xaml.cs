using Controllers;
using Models;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace WpfView
{
    /// <summary>
    /// Interaction logic for PedidosStatus.xaml
    /// </summary>
    public partial class PedidosStatus : Window
    {
        private int referencia = 0;

        public PedidosStatus()
        {
            InitializeComponent();
        }

        private void gridPedidos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (gridPedidos.SelectedItem != null && referencia == 0)
            {
                MessageBoxResult result = MessageBox.Show("Deseja alterar para Saiu Para Entrega o status do pedido " + ((Pedido)gridPedidos.SelectedItem).PedidoID + " ?", "Exclusão", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    try
                    {
                        Pedido pedido = ((Pedido)gridPedidos.SelectedItem);
                        PedidoController.MudarStatus(pedido, "SAIU PARA ENTREGA");
                        gridPedidos.ItemsSource = PedidoController.ProcuraPedidoPendentes();
                        MessageBox.Show("Pedido mudado para Saiu Para Entrega com sucesso");
                    }
                    catch (Exception erro)
                    {
                        MessageBox.Show("ERRO: " + erro);
                    }
                }
            }
            else if (gridPedidos.SelectedItem != null && referencia == 1)
            {
                MessageBoxResult result = MessageBox.Show("Deseja alterar para Finalizado o status do pedido " + ((Pedido)gridPedidos.SelectedItem).PedidoID + " ?", "Exclusão", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    try
                    {
                        Pedido ped = ((Pedido)gridPedidos.SelectedItem);
                        PedidoController.MudarStatus(ped, "FINALIZADO");
                        gridPedidos.ItemsSource = PedidoController.ProcuraPedidoSaiuParaEntrega();
                        MessageBox.Show("Pedido mudado para finalizado com sucesso");
                    }
                    catch (Exception erro)
                    {
                        MessageBox.Show("ERRO: " + erro);
                    }
                }
            }
        }

        private void btnVoltar_Click(object sender, RoutedEventArgs e)
        {
            MainWindow tela = new MainWindow();
            this.Close();
            tela.ShowDialog();
        }

        private void btnSaiuEntrega_Click(object sender, RoutedEventArgs e)
        {
            referencia = 1;
            List<Pedido> pedidos = PedidoController.ProcuraPedidoSaiuParaEntrega();
            if (pedidos.Count > 0)
            {
                gridPedidos.ItemsSource = pedidos;
            }
            else
            {
                MessageBox.Show("Nada encontrado nos pedidos que saíram para entrega");
            }
        }

        private void btnAndamento_Click(object sender, RoutedEventArgs e)
        {
            referencia = 0;
            var ped = PedidoController.ProcuraPedidoPendentes();
            if (ped.Count > 0)
            {
                gridPedidos.ItemsSource = ped;
            }
            else
            {
                MessageBox.Show("Nada encontrado nos pedidos em produção");
            }
        }

        private void btnFinalizado_Click(object sender, RoutedEventArgs e)
        {
            referencia = 2;
            var pedidos = PedidoController.ProcuraPedidoFinalizado();
            if (pedidos.Count > 0)
            {
                gridPedidos.ItemsSource = pedidos;
            }
            else
            {
                MessageBox.Show("Nada encontrado nos pedidos finalizados");
            }
        }
    }
}