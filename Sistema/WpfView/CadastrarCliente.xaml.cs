using Controllers;
using Models;
using System.Text.RegularExpressions;
using System.Windows;

namespace WpfView
{
    /// <summary>
    /// Interaction logic for CadastrarCliente.xaml
    /// </summary>
    public partial class CadastrarCliente : Window
    {
        public CadastrarCliente()
        {
            InitializeComponent();
        }

        private void btnSalvar_Click(object sender, RoutedEventArgs e)
        {
            if (VerificarItens())
            {
                Cliente clinovo = SalvarCliente(txtNome.Text, txtCPF.Text.Trim(), txtTelefone.Text.Trim(), txtRua.Text, int.Parse(txtNumero.Text.Trim()), txtBairro.Text, txtComplemento.Text, txtReferencia.Text);
                ClienteController.SalvarCliente(clinovo);
                MessageBox.Show("Cliente salvo com sucesso");
            }
        }

        private void btnVoltar_Click(object sender, RoutedEventArgs e)
        {
            var m = new MainWindow();
            this.Close();
            m.ShowDialog();
        }

        private Cliente SalvarCliente(string Nome, string CPF, string Telefone, string Rua, int Num, string Bairro, string Compl, string Refe)
        {
            return new Cliente
            {
                Nome = Nome,
                Cpf = CPF,
                Telefone = Telefone,
                Endereco = new Endereco
                {
                    Rua = Rua,
                    Numero = Num,
                    Bairro = Bairro,
                    Complemento = Compl,
                    Referencia = Refe
                }
            };
        }

        private bool VerificarItens()
        {
            string caracter = txtNumero.Text.Substring(0, 1);
            string verifica = "^[0-9]";

            if (!Regex.IsMatch(txtNome.Text, @"^[a-zA-Z]+$") || (txtNome.Text == null))
            {
                MessageBox.Show("ERRO, digite apenas caracter");
                return false;
            }
            else if ((!Regex.IsMatch(caracter, verifica) || txtCPF.Text.Length.Equals(11) == false) || (txtCPF.Text == null))
            {
                MessageBox.Show("Erro ! Digite 11 dígitos no CPF e apenas números");
                return false;
            }
            else if (!Regex.IsMatch(txtTelefone.Text, verifica) || (txtTelefone.Text == null))
            {
                return false;
            }
            else if ((txtRua.Text == null))
            {
                return false;
            }
            else if (!Regex.IsMatch(txtNumero.Text, verifica) || (txtNumero.Text == null))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}