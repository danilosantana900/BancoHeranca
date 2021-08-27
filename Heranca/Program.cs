using System; 

namespace Heranca
{
    class Program
    {
        static void Main(string[] args)
        {
            var primeiraConta = new ContaCorrente(20);
            Console.WriteLine($"Tipo: {primeiraConta.GetType().Name}, " +
                              $"Agencia: {primeiraConta.Agencia} / " +
                              $"Conta: {primeiraConta.Numero} / " +
                              $"Saldo: {primeiraConta.Saldo}");
            
            var contaTransformada = ConverteConta<ContaCorrente, ContaInvestimento>(primeiraConta);
            Console.WriteLine($"Tipo: {contaTransformada.GetType().Name} , " +
                              $"Agencia: {contaTransformada.Agencia} / " +
                              $"Conta: {contaTransformada.Numero} / " +
                              $"Saldo: {contaTransformada.Saldo}");
            primeiraConta = null;
        }

        public static B ConverteConta<A, B>(A contaRecebida) 
            where A : Conta 
            where B : Conta
        {
            var novaConta = Activator.CreateInstance<B>();
            contaRecebida.Transferir(contaRecebida.Saldo, novaConta);            
            return novaConta;
        }
    }
}
