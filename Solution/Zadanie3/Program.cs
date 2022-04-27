using System;

namespace Zadanie3
{
    class Program
    {
        static void Main(string[] args)
        {
            var xerox = new Copier();
            xerox.PowerOn();
            IDocument doc1 = new PDFDocument("aaa.pdf");
            xerox.Print(in doc1);

            IDocument doc2;
            xerox.Scan(out doc2);

            xerox.ScanAndPrint();
            System.Console.WriteLine(xerox.Counter);
            System.Console.WriteLine(xerox.PrintCounter);
            System.Console.WriteLine(xerox.ScanCounter);

            xerox.PowerOff();
            xerox.PowerOn();
            System.Console.WriteLine(xerox.Counter);
            System.Console.WriteLine(xerox.PrintCounter);
            System.Console.WriteLine(xerox.ScanCounter);

            System.Console.WriteLine("----------------");

            var multidimensionalDevice = new MultidimensionalDevice();
            multidimensionalDevice.PowerOn();

            multidimensionalDevice.Print(in doc1);
            multidimensionalDevice.Scan(out doc2);
            multidimensionalDevice.ScanAndPrint();
            multidimensionalDevice.SendFax(in doc1, "receiver 1");

            System.Console.WriteLine(multidimensionalDevice.Counter);
            System.Console.WriteLine(multidimensionalDevice.PrintCounter);
            System.Console.WriteLine(multidimensionalDevice.ScanCounter);
            System.Console.WriteLine(multidimensionalDevice.FaxCounter);

            multidimensionalDevice.PowerOff();
            multidimensionalDevice.PowerOn();
            multidimensionalDevice.SendFax(in doc1, "receiver 2");
            System.Console.WriteLine(multidimensionalDevice.Counter);
            System.Console.WriteLine(multidimensionalDevice.PrintCounter);
            System.Console.WriteLine(multidimensionalDevice.ScanCounter);
            System.Console.WriteLine(multidimensionalDevice.FaxCounter);
        }
    }
}
