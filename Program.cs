using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        public static string setNome()
        {
            Console.Write("Por favor insira o nome do usuário: ");
            return Console.ReadLine();
        }

        public static double setSalario()
        {
            Console.Write("Por favor insira o salário do usuário: ");
            return Convert.ToDouble(Console.ReadLine());
        }

        public static double setPercentual()
        {
            Console.Write("Por favor insira o percentual de reajuste: ");
            return Convert.ToDouble(Console.ReadLine());
        }

        public static double setSalarioBase(double salarioUsuario, double percentualReajuste)
        {
            return salarioUsuario + (salarioUsuario * (percentualReajuste / 100));
        }

        public static double setSalarioFinal(double salarioBase)
        {
            double salarioFinal = salarioBase;

            const double FUNDO_GARANTIA = 7.5;
            const double INSS           = 7.5;
            double IRRF                 = 0;

            salarioFinal = salarioFinal - (salarioBase * (FUNDO_GARANTIA / 100));
            salarioFinal = salarioFinal - (salarioBase * (INSS / 100));

            if(salarioBase >= 1900 && salarioBase < 2800)
            {
                IRRF = 7.5;
            }
            if(salarioBase >= 2800 && salarioBase < 3700)
            {
                IRRF = 15;
            }
            if(salarioBase >= 3700 && salarioBase < 4600)
            {
                IRRF = 22;
            }
            if(salarioBase >= 4600)
            {
                IRRF = 27;
            }

            salarioFinal = IRRF > 0 ? (salarioFinal - (salarioBase * (IRRF / 100))) : salarioFinal;

            if(IRRF > 0)
            {
                salarioFinal = (salarioFinal - (salarioBase * (IRRF / 100)));
            }
            else
            {
                salarioFinal = salarioFinal;
            }

            return salarioFinal;
        }
               
        static void Main(string[] args)
        {
            string nomeUsuario;
            double salarioBase;
            double salarioFinal;
            double salarioUsuario;
            double percentualReajuste;

            nomeUsuario         = setNome();
            salarioUsuario      = setSalario();
            percentualReajuste  = setPercentual();
            salarioBase         = setSalarioBase(salarioUsuario, percentualReajuste);
            salarioFinal        = setSalarioFinal(salarioBase);

            Console.WriteLine(salarioFinal);

            Console.ReadLine();

        }
    }
}
