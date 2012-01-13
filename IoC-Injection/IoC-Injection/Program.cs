using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IoC_Injection
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Constructor Injection
            //IMeioPagamento meioPagamento = new Cartao();
            //var braspag = new BraspagConstructor(meioPagamento);
            #endregion

            #region Setter Injection
            
            var braspag = new BraspagSetter();
            braspag.MeioPagamento = new DebitoEmConta();
            #endregion

            Console.WriteLine(braspag.DoSomeThing());
            Console.Read();
        }
    }

    class BraspagConstructor
    {
        private readonly IMeioPagamento _meioPagamento;

        public BraspagConstructor(IMeioPagamento meioPagamento)
        {
            _meioPagamento = meioPagamento;
        }

        public string DoSomeThing()
        {
            //Faz alguma coisa aqui sem maldade
            return _meioPagamento.Processar(1, "Zé", 18.00);
        }
    }

    class BraspagSetter
    {
        public IMeioPagamento MeioPagamento {get;set;}

        public string DoSomeThing()
        {
            //Faz alguma coisa aqui sem maldade
            return MeioPagamento.Processar(1, "Mané", 69.00);
        }
    }

    interface IMeioPagamento
    {
        string Processar(int idPedido, string nomeCliente, double valor);
    }

    class Cartao : IMeioPagamento
    {

        public string Processar(int idPedido, string nomeCliente, double valor)
        {
            return "Processando via cartão!!";
        }
    }

    class DebitoEmConta : IMeioPagamento
    {

        public string Processar(int idPedido, string nomeCliente, double valor)
        {
            return "Processando via débito em conta!!";
        }
    }
}
