﻿using Controllers;
using Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfView
{
    /// <summary>
    /// Interaction logic for CadastroPizzas.xaml
    /// </summary>
    public partial class CadastroPizzas : Window
    {
        public CadastroPizzas()
        {
            InitializeComponent();

        }

        private void btnListarPizzas_Click(object sender, RoutedEventArgs e)
        {
            List<Pizza> list = PizzaController.ListarTodasPizzas();
            if (list != null)
            {
                gridPizza.ItemsSource = list;
            }
            else
            {
                MessageBox.Show("A tabela não possui nada cadastrado");
            }
        }

        private void btnSalvarPizza_Click(object sender, RoutedEventArgs e)
        {
            PizzaController.SalvarPizza(SalvarPizza());
        }
        
        private Pizza SalvarPizza()
        {
            Pizza p = new Pizza();
            p.Nome = txtPizza.Text;
            p.Ingredientes = txtIngredientes.Text;
            p.Preco = double.Parse(txtPreco.Text);

            return p;
        }

        private void GridMostrarPizza_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (gridPizza.SelectedItem != null)
            {
                MessageBoxResult result = MessageBox.Show("Deseja editar a pizza " + ((Pizza)gridPizza.SelectedItem).Nome + " ?", "Edição", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    try
                    {
                        Pizza pizza = ((Pizza)gridPizza.SelectedItem);
                        EditarProdutos edit = new EditarProdutos();
                        edit.ProdutoEditarPizza(pizza,1);
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
        

        private void btnVoltar_Click(object sender, RoutedEventArgs e)
        {
            MainWindow m = new MainWindow();
            this.Close();
            m.ShowDialog();
        }
    }
}
