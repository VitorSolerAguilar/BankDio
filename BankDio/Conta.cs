using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankDio
{
    class Conta
    {
        public TipoContaEnum TipoConta { get; set; }
        private double Saldo { get; set; }
        private double Credito { get; set; }
        private string Nome { get; set; }

        public Conta(TipoContaEnum tipoConta, double saldo, double credito, string nome)
        {
            this.TipoConta = tipoConta;
            this.Saldo = saldo;
            this.Credito = credito;
            this.Nome = nome;
        }

        public bool Sacar(double valorSaque)
        {
            //Validação de saldo
            if (this.Saldo - valorSaque < (this.Credito * -1))
            {
                Console.WriteLine("Saldo insuficiente!");
                return false;
            }

            //A abreviação abaixo substitui: this.Saldo = this.Saldo - valorSaque;
            this.Saldo -= valorSaque;
            Console.WriteLine(this.Nome + "o saldo atual da conta é de: R$" + this.Saldo);
            return true;
        }

        public void Depositar(double valorDeposito)
        {
            //A abreviação abaixo substitui: this.Saldo = this.Saldo + valorDeposito;
            this.Saldo += valorDeposito;
            Console.WriteLine(this.Nome + "o saldo atual da conta é de: R$" + this.Saldo);
        }

        public void Transferencia(double valorTransferencia, Conta contaDestino)
        {
            if (this.Sacar(valorTransferencia))
            {
                contaDestino.Depositar(valorTransferencia);
            }
        }

        public override string ToString()
        {
            string Retorno = "";
            Retorno += "Tipo de Conta: " + this.TipoConta + " | ";
            Retorno += "Nome: " + this.Nome + " | ";
            Retorno += "Saldo: " + this.Saldo + " | ";
            Retorno += "Crédito: " + this.Credito + " | ";
            return Retorno;
        }
    }
}
