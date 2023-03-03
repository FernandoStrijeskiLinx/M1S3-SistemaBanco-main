using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace M1S3_SistemaBanco
{
    public class ClienteServico
    {
        public static List<Cliente> clientes = new List<Cliente>();
        public static Cliente BuscarClientePorNumeroDeConta (int numeroConta) => clientes.Find(x => x.NumeroConta == numeroConta);

        public static void ExibirClientes(){
        Console.WriteLine("Número da conta        | Nome         | CPF    ");
        for(int i =0; i < clientes.Count; i++){
                Console.WriteLine(clientes[i].ResumoCliente());
            }
        }

        public static void CriarConta(string tipoConta){
            if(tipoConta=="1"){
            PessoaFisica cliente = new PessoaFisica();
            Console.WriteLine("Data de Nascimento do cliente:");
            cliente.DataNascimento = DateTime.Parse(Console.ReadLine());

            if(!cliente.EhMaior()){
                Console.WriteLine("Não é possivel abrir a conta pois o Cliente é menor de idade.");
                return;
            }

            Console.WriteLine("A idade do cliente é " + cliente.Idade);
            Console.WriteLine("Nome do cliente:");
            cliente.Nome = Console.ReadLine();
            Console.WriteLine("CPF do cliente:");
            cliente.CPF = Console.ReadLine();
            Console.WriteLine("Endereco do cliente:");
            cliente.Endereco = Console.ReadLine();
            Console.WriteLine("Telefone do cliente:");
            cliente.Telefone = Console.ReadLine();
            Console.WriteLine("Email do cliente:");
            cliente.Email = Console.ReadLine();
            Console.WriteLine("Numero Da Conta");
            cliente.NumeroConta = int.Parse(Console.ReadLine());
            clientes.Add(cliente);

            } else if (tipoConta=="2"){
                PessoaJuridica cliente = new PessoaJuridica();
                Console.WriteLine("Razão Social do cliente:");
                cliente.RazaoSocial = Console.ReadLine();
                Console.WriteLine("CNPJ do cliente:");
                cliente.CNPJ = Console.ReadLine();
                Console.WriteLine("Endereco do cliente:");
                cliente.Endereco = Console.ReadLine();
                Console.WriteLine("Telefone do cliente:");
                cliente.Telefone = Console.ReadLine();
                Console.WriteLine("Email do cliente:");
                cliente.Email = Console.ReadLine();
                Console.WriteLine("Numero Da Conta");
                cliente.NumeroConta = int.Parse(Console.ReadLine());
                clientes.Add(cliente);
            }        
        }
    }
}