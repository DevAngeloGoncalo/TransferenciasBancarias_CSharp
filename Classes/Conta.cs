using System;
using Dio.Bank.Enum;

namespace Dio.Bank.Classes
{
    public class Conta
    {
        private string Nome {get; set;}
        private double Saldo {get; set;}
        private double Credito {get; set;}
        private TipoConta TipoConta {get; set;}
        public Conta(string nome, double saldo, double credito, TipoConta tipoConta)
        {
            this.Nome = nome;
            this.Saldo = saldo;
            this.Credito = credito;
            this.TipoConta = tipoConta;
        }
        public bool Sacar(double valorSaque)
        {
            if(this.Saldo - valorSaque < (this.Credito * -1))
            {
                Console.WriteLine("Saldo Insuficiente");
                return false;  
            }  
            else
            {
                this.Saldo -= valorSaque;
                Console.WriteLine("Olá " + this.Nome + "\nSaldo atual é : R$" + this.Saldo);
                return true;
            }   
        }
        public void Depositar(double valorDeposito)
        {
            this.Saldo += valorDeposito;
            Console.WriteLine("Olá " + this.Nome + "\nSaldo atual é : R$" + this.Saldo);;
        }
        public void Transferir(double valorTransferencia, Conta contaDestino)
        {
            if(Sacar(valorTransferencia)) //Verifica se tem dinheiro suficiente para saque.
            {
                contaDestino.Depositar(valorTransferencia);
            }
        }
        public override string ToString()
        {
            string retorno = "";
            retorno += "TipoConta " + this.TipoConta + " | "; 
            retorno += "Nome " + this.Nome + " | "; 
            retorno += "Crédito " + this.Credito + " | "; 
            retorno += "Saldo " + this.Saldo; 
            return retorno;
        }
    }
}