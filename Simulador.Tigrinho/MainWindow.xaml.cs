using System.Windows;

namespace Simulador.Tigrinho;

public partial class MainWindow : Window
{
    public decimal saldoInicial = 10M;

    public MainWindow()
    {
        InitializeComponent();
    }

    private async void BotaoSorteio_OnClick(object sender, RoutedEventArgs e)
    {
        btnSorteio.IsEnabled = false;

        var quantidadeTexto = tbQuantidade.Text;
        var quantidadeSorteios = Convert.ToInt32(quantidadeTexto);
        if (quantidadeSorteios < 1) quantidadeSorteios = 1;

        var sorteador = new Random();
        for (var contador = 0; contador < quantidadeSorteios; contador++)
            if (saldoInicial >= 10)
            {
                tbResultado.Text = sorteador.Next(0, 40000000).ToString();
                await Task.Delay(1000);
            }
            else
            {
                MessageBox.Show("Você não tem saldo suficiente para realizar o sorteio!");
                break;
            }

        btnSorteio.IsEnabled = true;
    }
}