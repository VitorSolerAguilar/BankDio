using System;
using System.Collections.Generic;

namespace BankDio
{
    class Program
    {
        //"Banco de dados" ficticio
        static List<Conta> listaContas = new List<Conta>();

        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarContas();
                        break;
                    case "2":
                        InserirConta();
                        break;
                    case "3":
                       Transferir();
                        break;
                    case "4":
                        Sacar();
                        break;
                    case "5":
                        Depositar();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                }
                opcaoUsuario = ObterOpcaoUsuario();
            }
            Console.WriteLine("Obrigado por utilizar nossos serviços.");
            Console.ReadLine();
        }
               
        private static void ListarContas()
        {
            Console.WriteLine("Listar conta");

            if (listaContas.Count == 0)
            {
                Console.WriteLine("Nenhuma conta cadastrada!");
                return;
            }

            for (int i = 0; i < listaContas.Count; i++)
            {
                Conta conta = listaContas[i];
                Console.Write("#{0} - ", i);
                Console.WriteLine(conta);
            }
        }

        private static void InserirConta()
        {
            Console.WriteLine();
            Console.WriteLine("Inserir nova conta");

            Console.Write("1 - Conta fisica || 2 - juridica?: ");
            int EntradaTipoConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o nome do cliente: ");
            string EntradaNome = Console.ReadLine();

            Console.Write("Digite o saldo inicial: ");
            double EntradaSaldo = double.Parse(Console.ReadLine());

            Console.Write("Digite o crédito: ");
            double EntradaCredito = double.Parse(Console.ReadLine());

            //Esse comando cria um objeto da classe conta e coloca os requisitos para o construtor da classe.
            Conta NovaConta = new Conta(tipoConta: (TipoContaEnum)EntradaTipoConta,
                saldo: EntradaSaldo,
                credito: EntradaCredito,
                nome: EntradaNome);

            //O nome do "banco de dados" criado na linha 9 é chamado, utilizando o metodo add da lista e assim passa o objeto criado a cima para ser adicionado.
            listaContas.Add(NovaConta);
        }

        private static void Transferir()
        {
            Console.Write("Digite o numero da conta de origem: ");
            int IndiceContaOrigem = int.Parse(Console.ReadLine());

            Console.Write("Digite o numero da conta de destino: ");
            int IndiceContaDestino = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor a ser transferido: ");
            double ValorTransferencia = double.Parse(Console.ReadLine());

            //Segue o mesmo padão dos metodos sacar e depositar, a unica diferença é que o metodo transferencia criado na classe conta, precisa de dois parametro de entrada.
            //Em caso de duvida usar o debug.
            listaContas[IndiceContaOrigem].Transferencia(ValorTransferencia, listaContas[IndiceContaDestino]);
        }

        private static void Sacar()
        {
            Console.Write("Digite o número da conta: ");
            int IndiceConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor a ser sacado: ");
            double ValorSaque = double.Parse(Console.ReadLine());

            //O "Banco de dados" é chamado passando como objeto a variavel local "IndiceConta" e acessando o metodo sacar definido na classe conta.
            listaContas[IndiceConta].Sacar(ValorSaque);
        }

        private static void Depositar()
        {

            Console.Write("Digite o número da conta: ");
            int IndiceConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor a ser depositado: ");
            double ValorDeposito = double.Parse(Console.ReadLine());

            listaContas[IndiceConta].Depositar(ValorDeposito);
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine("\r\n ========================");
            Console.WriteLine(" Dio Bank a seu dispor!");
            Console.WriteLine(" ========================= \r\n");

            Console.WriteLine("Informe a opção desejada");
            Console.WriteLine("1 - Listar Contas");
            Console.WriteLine("2 - Inserir Nova Conta");
            Console.WriteLine("3 - Transferir");
            Console.WriteLine("4 - Sacar");
            Console.WriteLine("5 - Depositar");
            Console.WriteLine("C - Limpar Tela");
            Console.WriteLine("X - Sair \r\n");

            string OpcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return OpcaoUsuario;
        }
    }
}
