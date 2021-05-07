using System;
using System.Collections.Generic;
using Dio.Bank.Classes;
using Dio.Bank.Enum;

namespace dio.bank
{
    class Program
    {   
        static List<Conta> listaContas = new List<Conta>();
        
        static private int _escolha;
        static private double _valor;

        static void Main(string[] args)
        {
            string opcUsuario = ObterOpcUsuario();

            while(opcUsuario.ToUpper() != "X")
            {   
                try
                {
                    switch(opcUsuario)
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

                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                }
                catch (ArgumentOutOfRangeException) 
                {
                    Console.Clear();
                    Console.WriteLine("Selecione uma das Alternativas!\n");
                }
                
                opcUsuario = ObterOpcUsuario();
            } 
            Console.WriteLine("Obrigado por utilizar o banco");
            Console.ReadKey();
        }
        private static string ObterOpcUsuario()
        {
            Console.WriteLine("Bem Vindo ao Banco");
            Console.WriteLine("Informe a Opção Desejada: \n");
            Console.WriteLine("1 - Listar Contas");
            Console.WriteLine("2 - Inserir Nova Conta");
            Console.WriteLine("3 - Transferir");
            Console.WriteLine("4 - Sacar");
            Console.WriteLine("5 - Depositar");
            Console.WriteLine("X - Sair");

            string opcUsuario = Console.ReadLine().ToUpper();
            return opcUsuario;
        }
        private static void InserirConta()
        {
            Console.Clear();
            Console.WriteLine("Insira uma nova conta");
            
            Console.Write("Digite 1 para Conta Fisica ou 2 para Juridica: ");
            if (ValidarEscolhaPessoa() != 0)
            {
                int TipoConta = _escolha;
            
                Console.Write("Digite o Nome do Cliente: ");
                string Nome = Console.ReadLine();

                Console.Write("Digite o saldo inicial: ");
                
                if (validaNumero() != 0)
                {
                    double Saldo = _valor;
 
                    Console.Write("Digite o crédito: ");
                    if (validaNumero() != 0)
                    {
                        double Credito = _valor;
                        Conta novaConta = new Conta(tipoConta: (TipoConta)TipoConta, saldo: Saldo, credito: Credito, nome: Nome);

                        listaContas.Add(novaConta);  
                    }
                }
            }
        }
        private static double validaNumero()
        {
            try
            {
                Convert.ToDouble(_valor = double.Parse(Console.ReadLine()));
                return _valor;
            }
            catch
            {
                Console.WriteLine("Insira Números!");
                return 0;
            }
        }

        private static int ValidarEscolhaPessoa()
        {
            try
            {
                Convert.ToInt32(_escolha = int.Parse(Console.ReadLine()));
                if(_escolha != 1  && _escolha != 2)
                {
                    Console.WriteLine("Informe Corretamente!\n");
                    return 0;
                }
                return _escolha;
            }
            catch
            {
                Console.WriteLine("Insira Números!\n");
                return 0;
            } 
        }

        private static bool ListarContas()
		{
            Console.Clear();
			Console.WriteLine("Contas Cadastradas: ");

			if (listaContas.Count == 0)
			{  
				Console.WriteLine("Nenhuma conta cadastrada.\n");
				return false;
			}

			for (int i = 0; i < listaContas.Count; i++)
			{
				Conta conta = listaContas[i];
				Console.Write("#{0} - ", i + 1);
				Console.WriteLine(conta);
			}
            Console.WriteLine();
            return true;
		}
        private static void Depositar()
		{
            if (ListarContas() == true)
            {
                Console.Write("Digite o número da conta: ");
                int indiceConta = int.Parse(Console.ReadLine());

                Console.Write("Digite o valor a ser depositado: ");
                double valorDeposito = double.Parse(Console.ReadLine());

                listaContas[indiceConta - 1].Depositar(valorDeposito);
            }
		}
        private static void Sacar()
        {
            if (ListarContas() == true)
            {
                Console.Write("Digite o número da conta: ");
                int indiceConta = int.Parse(Console.ReadLine());

                Console.Write("Digite o valor a ser sacado: ");
                double valorSaque = double.Parse(Console.ReadLine());

                listaContas[indiceConta - 1].Sacar(valorSaque);
            }
        }
        private static void Transferir()
		{
            if (ListarContas() == true)
            {
                if (listaContas.Count >= 2)
                {
                    Console.Write("Digite o número da conta de origem: ");
                    if(validaNumero() != 0)
                    {
                        int indiceContaOrigem = Convert.ToInt32(_valor);

                        Console.Write("Digite o número da conta de destino: ");
                        if(validaNumero() != 0)
                        {
                            int indiceContaDestino = Convert.ToInt32(_valor);

                            Console.Write("Digite o valor a ser transferido: ");
                            if(validaNumero() != 0)
                            {
                                double valorTransferencia = _valor;
                                listaContas[indiceContaOrigem - 1].Transferir(valorTransferencia, listaContas[indiceContaDestino - 1]);
                            }
                        }
                    }
                }
                Console.WriteLine("Números de Contas Insuficientes!\n"); 
                return; 
            }
		}
    }
}