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
                        //Transferir();
                        break;
                    case "4":
                        //Sacar();
                        break;
                    case "5":
                        //Depositar();
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

            Conta NovaConta = new Conta(tipoConta: (TipoContaEnum)EntradaTipoConta, 
                saldo: EntradaSaldo, 
                credito: EntradaCredito, 
                nome: EntradaNome);

            listaContas.Add(NovaConta);
        }


        private static void ListarContas()
        {
            Console.WriteLine("Listar conta");

            if(listaContas.Count == 0)
            {
                Console.WriteLine("Nenhuma conta cadastrada!");
                return;
            }

            for(int i = 0; i < listaContas.Count; i++)
            {
                Conta conta = listaContas[i];
                Console.Write("#{0} - " , i);
                Console.WriteLine(conta);
            }
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
