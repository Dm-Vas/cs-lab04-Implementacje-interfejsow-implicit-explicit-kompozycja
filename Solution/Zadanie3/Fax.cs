using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie3
{
    public class Fax : IFax
    {
        public int FaxCounter { get; set; }
        public int Counter { get; set; }

        public IDevice.State GetState() => state;
        protected IDevice.State state = IDevice.State.off;
        public void PowerOff()
        {
            if (state == IDevice.State.on)
            {
                state = IDevice.State.off;
                Console.WriteLine("... Fax is off !");
            }
        }

        public void PowerOn()
        {
            if (state == IDevice.State.off)
            {
                state = IDevice.State.on;
                Console.WriteLine("Fax is on ...");
                Counter++;
            }
        }

        public void SendFax(in IDocument document, string receiver)
        {
            if (state == IDevice.State.on)
            {
                Console.WriteLine($"{DateTime.Now:dd.MM.yyyy HH:mm:ss} Fax: {document.GetFileName()} send to {receiver}");
                FaxCounter++;
            }
        }
    }
}
