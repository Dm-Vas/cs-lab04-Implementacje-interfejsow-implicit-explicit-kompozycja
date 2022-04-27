using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie3
{
    public class MultidimensionalDevice : BaseDevice
    {
        protected Printer Printer = new Printer();
        protected Scanner Scanner = new Scanner();
        protected Fax Fax = new Fax();

        public new int Counter { get; set; }
        public int PrintCounter => Printer.PrintCounter;
        public int ScanCounter => Scanner.ScanCounter;
        public int FaxCounter => Fax.FaxCounter;

        public new void PowerOff()
        {
            if (GetState() == IDevice.State.on)
            {
                Printer.PowerOff();
                Scanner.PowerOff();
                Fax.PowerOff();
                base.PowerOff();
            }
        }

        public new void PowerOn()
        {
            if (GetState() == IDevice.State.off)
            {
                Printer.PowerOn();
                Scanner.PowerOn();
                Fax.PowerOn();
                base.PowerOn();
                Counter++;
            }
        }

        public void Print(in IDocument document)
        {
            if (GetState() == IDevice.State.on)
            {
                Printer.Print(document);
            }
        }

        public void Scan(out IDocument document, IDocument.FormatType formatType = IDocument.FormatType.PDF)
        {
            document = null;

            if (GetState() == IDevice.State.on)
            {
                Scanner.Scan(out document, formatType);
            }
        }

        public void ScanAndPrint()
        {
            if (GetState() == IDevice.State.on)
            {
                Scan(out IDocument document, IDocument.FormatType.PDF);
                Print(in document);
            }
        }

        public void SendFax(in IDocument document, string receiver) {
            if (GetState() == IDevice.State.on)
            {
                Fax.SendFax(document, receiver);
            }
        }
    }
}
