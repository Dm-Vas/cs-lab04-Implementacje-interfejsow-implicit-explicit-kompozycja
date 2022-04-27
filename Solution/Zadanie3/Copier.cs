
using System;

namespace Zadanie3
{
    public class Copier : BaseDevice
    {
        protected Printer Printer = new Printer();
        protected Scanner Scanner = new Scanner();
        public new int Counter { get; set; }
        public int PrintCounter => Printer.PrintCounter;
        public int ScanCounter => Scanner.ScanCounter;

        public new void PowerOff()
        {
            if (GetState() == IDevice.State.on) {
                Printer.PowerOff();
                Scanner.PowerOff();
                base.PowerOff();
            }
        }

        public new void PowerOn()
        {
            if (GetState() == IDevice.State.off)
            {
                Printer.PowerOn();
                Scanner.PowerOn();
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

    }
}