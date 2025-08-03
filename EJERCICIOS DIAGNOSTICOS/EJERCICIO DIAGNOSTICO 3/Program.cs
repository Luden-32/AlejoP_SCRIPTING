using System;
using System.Linq;

namespace SampleApp
{
    public abstract class AbstractSample
    {
        private string message;

        public AbstractSample(string message)
        {
            this.message = message;
        }

        public abstract void PrintMessage(string message);

        public virtual string InvertMessage(string message)
        {
            char[] arr = message.ToCharArray();
            Array.Reverse(arr);
            return new string(arr);
        }
    }

    public class SimplePrinter : AbstractSample
    {
        public SimplePrinter(string message) : base(message) { }

        public override void PrintMessage(string message)
        {
            Console.WriteLine(message);
        }
    }

    public class InvertedCasePrinter : AbstractSample
    {
        public InvertedCasePrinter(string message) : base(message) { }

        public override void PrintMessage(string message)
        {
            Console.WriteLine(SwapCase(message));
        }

        public override string InvertMessage(string message)
        {
            string inverted = base.InvertMessage(message);
            return SwapCase(inverted);
        }

        private string SwapCase(string input)
        {
            char[] arr = input.ToCharArray();
            for (int i = 0; i < arr.Length; i++)
            {
                char c = arr[i];
                if (char.IsUpper(c)) arr[i] = char.ToLower(c);
                else if (char.IsLower(c)) arr[i] = char.ToUpper(c);
            }
            return new string(arr);
        }
    }

    public class MessageManager
    {
        public void Run(string message)
        {
            AbstractSample printer1 = new SimplePrinter(message);
            AbstractSample printer2 = new InvertedCasePrinter(message);

            Console.WriteLine("-- SimplePrinter -> PrintMessage --");
            printer1.PrintMessage(message);

            Console.WriteLine("-- InvertedCasePrinter -> PrintMessage --");
            printer2.PrintMessage(message);

            Console.WriteLine("-- InvertedCasePrinter -> InvertMessage --");
            string inv = printer2.InvertMessage(message);
            Console.WriteLine(inv);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Ingrese frase o palabra: ");
            string input = Console.ReadLine() ?? string.Empty;

            var manager = new MessageManager();
            manager.Run(input);
        }
    }
}
