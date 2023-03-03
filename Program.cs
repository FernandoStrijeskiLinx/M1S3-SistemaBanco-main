using System.Globalization;
using M1S3_SistemaBanco;

ClienteServico.clientes.Add(new PessoaFisica("Vitor", "123456", "vitor@email", "666", "rua 1", new DateTime(2002, 5, 15), 1));
ClienteServico.clientes.Add(new PessoaFisica("Fernando", "654321", "Fernando@email", "777", "rua 2", new DateTime(2002, 5, 15), 2));
ClienteServico.clientes.Add(new PessoaFisica("Vanessa", "123123", "Vanessa@email", "888", "rua 3", new DateTime(2002, 5, 15), 3));
ClienteServico.clientes.Add(new PessoaFisica("Lucas", "321321", "Lucas@email", "999", "rua 4", new DateTime(2002, 5, 15), 4));

string opcao;
do
{
    Console.WriteLine("Bem vindos ao Banco FULL STACK BANK, escolha uma opção");
    Console.WriteLine("1 - Criar Conta ");
    Console.WriteLine("2 - Adicionar Transacao");
    Console.WriteLine("3 - Consultar Extrato");
    Console.WriteLine("4 - Sair");
    Console.WriteLine("5 - Exibir Clientes");
    opcao = Console.ReadLine();

    if (opcao == "1")
    {
        Console.WriteLine("Vamos criar uma conta! Informe o tipo de conta que deseja criar:");
        Console.WriteLine("1 - Pessoa Fisica");
        Console.WriteLine("2 - Pessoa Juridica");
        string tipoConta = Console.ReadLine();
        ClienteServico.CriarConta(tipoConta);
    }
    else if (opcao == "5")
    {
        ClienteServico.ExibirClientes();
    }
    else if (opcao == "2")
    {
        AdicionarTransacao();
    }
    else if (opcao == "3")
    {
        ExibirExtrato();
    }

    Console.WriteLine("Tecle Enter para continuar");
    Console.ReadLine();
} while (opcao != "4");

void AdicionarTransacao()
{
    Console.WriteLine("Qual a conta?");
    int numeroConta = int.Parse(Console.ReadLine());

    Cliente contaCliente = ClienteServico.BuscarClientePorNumeroDeConta(numeroConta);

    if (contaCliente == null)
    {
        Console.WriteLine("Conta não cadastrada, favor cadastrar antes");
        return;
    }

    Console.WriteLine("Qual o valor da transação?");
    double valor = double.Parse(Console.ReadLine());
    Transacao transacao = new Transacao(DateTime.Now, valor);

    contaCliente.Extrato.Add(transacao);

}

void ExibirExtrato()
{
    Console.WriteLine("Qual a conta?");
    int numeroConta = int.Parse(Console.ReadLine());

    Cliente contaCliente = ClienteServico.BuscarClientePorNumeroDeConta(numeroConta);

    if (contaCliente == null)
    {
        Console.WriteLine("Conta não cadastrada, favor cadastrar antes");
        return;
    }
    double saldo = 0;
    foreach (Transacao transacao in contaCliente.Extrato)
    {
        Console.WriteLine(" Data: " + transacao.Data + " Valor: " + transacao.Valor.ToString("C2", new CultureInfo("pt-BR")));
        saldo += transacao.Valor;
        //Console.WriteLine($"Data: {transacao.Data} Valor: R$  {transacao.Valor}" );
    }

    Console.WriteLine("Saldo = " + contaCliente.Saldo);
}