using Sistema.Models.DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;

namespace Models.DAL.Migrations
{
    public class Configuration : DbMigrationsConfiguration<MeuContexto>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(MeuContexto context)
        {
            var cliente = new Cliente
            {
                ClienteID = 1,
                Nome = "Ana Maria dos Santos",
                Cpf = "01350159464",
                Telefone = "987459871",
                Endereco = new Endereco
                {
                    Rua = "Avenida Marginal Pinheiros",
                    Bairro = "Osasco",
                    Numero = 453,
                    Referencia = "Ao lado da padaria"
                }
            };

            var pizzas = new List<Pizza>
            {
                new Pizza
                {
                    PizzaID = 1,
                    Nome = "Calabresa",
                    Ingredientes = "Queijo, Calabresa, Cebola",
                    Preco = 25
                },
                new Pizza
                {
                    PizzaID = 2,
                    Nome = "Alho",
                    Ingredientes = "Queijo, Alho",
                    Preco = 25
                },
                new Pizza
                {
                    PizzaID = 3,
                    Nome = "Portuguesa",
                    Ingredientes = "Queijo, Presunto, Ovo, Azeitona",
                    Preco = 25
                },
                new Pizza
                {
                    PizzaID = 4,
                    Nome = "Marguerita",
                    Ingredientes = "Queijo, Tomate, Manjericão",
                    Preco = 25
                },
            };

            var bebidas = new List<Bebida>
            {
                new Bebida
                {
                    BebidaID = 1,
                    Nome = "Sprite",
                    Preco = 5
                },
                new Bebida
                {
                    BebidaID = 2,
                    Nome = "Coca Cola",
                    Preco = 5
                },
                new Bebida
                {
                    BebidaID = 3,
                    Nome = "Malzebier",
                    Preco = 8
                }
            };

            context.Cliente.AddOrUpdate(cliente);
            pizzas.ForEach(x => context.Pizza.AddOrUpdate(x));
            bebidas.ForEach(x => context.Bebida.AddOrUpdate(x));
            context.SaveChanges();

            var pedido = new Pedido
            {
                PedidoID = 1,
                ClientID = 1,
                Data = DateTime.Now,
                Pizza = pizzas.Find(x => x.PizzaID == 1),
                Bebida = bebidas.Find(x => x.BebidaID == 2),
                ValorTotal = 45,
                Status = "EM PRODUÇÃO"
            };
            context.Pedido.AddOrUpdate(pedido);
            context.SaveChanges();
        }
    }
}