using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StructureMap;
using StructureMap.Configuration.DSL;

namespace Ioc_Container
{
    class MyRegistry : Registry
    {
        public MyRegistry()
        {
            For<IMeioPagamento>().Use<DebitoEmConta>();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var container = new Container(new MyRegistry());
            container.Configure(x => x.For<IMeioPagamento>().Use<Cartao>());

            var braspag = container.GetInstance<Braspag>();

            Console.WriteLine(braspag.DoSomeThing());
            Console.Read();
        }
    }

    class Braspag
    {
        private readonly IMeioPagamento _meioPagamento;
       
        public Braspag(IMeioPagamento meioPagamento)
        {
            _meioPagamento = meioPagamento;
        }

        public string DoSomeThing()
        {
            //Faz alguma coisa aqui sem maldade
            return _meioPagamento.Processar(1, "Zé", 18.00);
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
