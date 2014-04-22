using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using HidLibrary;

namespace ApcUps
{
    class Class1
    {
        public static void Main()
        {
            Task upsTask = Task.Factory.StartNew( () => {                               
                               
                HidDevice ups = HidDevices.Enumerate(0x051D, 0x0002).FirstOrDefault();

                if (ups == null) return;

                do
                {                 
                    byte[] status;
                    byte[] status2;
                    byte[] status3;

                    ups.ReadFeatureData(out status, 0x06);
                    ups.ReadFeatureData(out status2, 0x31);
                    ups.ReadFeatureData(out status3, 0x50);

                    FileWriter.addValue(status);
                    FileWriter.addValue(status2);
                    FileWriter.addValue(status3);                    

                    Thread.Sleep(4000);

                } while (true);
            });

            upsTask.Wait();
            upsTask.Dispose();
            
        }
    }
}