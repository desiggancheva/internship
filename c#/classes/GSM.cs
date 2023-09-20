using System.Data;
using System.Drawing;
using System.Reflection.PortableExecutable;
using System.Runtime.InteropServices;

static public class GSMProgram
{
    public enum BatteryType
    {
        LiIon,
        NiMH,
        NiCd
    }

    public class Battery
    {
        private readonly BatteryType type;
        private string model = " ";
        private uint hoursIdle = 0;
        private uint hoursTalk = 0;

        public Battery() { }

        public Battery(BatteryType type, string model, uint hoursIdle, uint hoursTalk)
        {
            this.type = type;
            this.model = model;
            this.hoursIdle = hoursIdle;
            this.hoursTalk = hoursTalk;
        }

        public void printBattery()
        {
            Console.WriteLine(model + " " + hoursIdle + " " + hoursTalk + "\n");
        }
    }

    public class Display
    {
        private uint size = 0;
        private uint numbersOfColors = 0;

        public Display() { }

        public Display(uint size, uint numbersOfColors)
        {
            this.size = size;
            this.numbersOfColors = numbersOfColors;
        }

        public void printDisplay()
        {
            Console.WriteLine(size + " " + numbersOfColors + "\n");
        }
    }

    public class GSM
    {
        private string model = " ";
        private string manufacturer = " ";
        private uint price = 0;
        private string owner = " ";
        private Battery battery = new Battery();
        private Display display = new Display();
        private List<Call> callHistory = new List<Call>();

        public GSM() { }

        public GSM(string model, string manufacturer, uint price, string owner, Battery battery, Display display)
        {
            this.model = model;
            this.manufacturer = manufacturer;
            this.price = price;
            this.owner = owner;
            this.battery = battery;
            this.display = display;
        }

        public static GSM iphone4s = new GSM("iphone4s", "apple", 1200, "owner", new Battery(), new Display());

        public void printGSM()
        {
            Console.WriteLine(model + " " + manufacturer + " " + price + " " + owner + "\n");
            battery.printBattery();
            display.printDisplay();
        }

        override public string ToString()
        {
            string result = model + " " + manufacturer + " " + price + " " + owner + "\n";

            return result;
        }

        public void addCall(GSM callTo, DateOnly date, TimeOnly time, uint duration)
        {
            callHistory.Add(new Call(date, time, this, callTo, duration));
        }
        public void deleteCall(Call callToDelete)
        {
            callHistory.Remove(callToDelete);
        }

        public void clearCallHistory()
        {
            callHistory.Clear();
        }

        public double calculatePrice(double pricePerMinute)
        {
            double minutes = 0;

            for (int i = 0; i < callHistory.Count; i++)
            {
                minutes += callHistory[i].getDurationInSeconds();
            }

            minutes /= 60;

            return minutes * pricePerMinute;
        }

        public void removeLongestCall()
        {
            int indexOfLongestCall = 0;

            for (int i = 0; i < callHistory.Count - 1; i++)
            {
                if (callHistory[indexOfLongestCall].getDurationInSeconds() < callHistory[i].getDurationInSeconds())
                {
                    indexOfLongestCall = i;
                }
            }

            this.deleteCall(callHistory[indexOfLongestCall]);
        }

        public void printCallHistory()
        {
            for (int i = 0; i < callHistory.Count; i++)
            {
                callHistory[i].printCall();
            }
        }
    }

    public class GSMTest
    {
        private List<GSM> data = new List<GSM>();

        public GSMTest() { }

        public void addGSM(GSM gsm)
        {
            data.Add(gsm);
        }

        public void removeGSM(GSM gsm)
        {
            data.Remove(gsm);
        }

        public void printGSMs()
        {
            for (int i = 0; i < data.Count; i++)
            {
                data[i].printGSM();
            }
        }
    }

    public class Call
    {
        private DateOnly date;
        private TimeOnly time;

        private GSM callFrom = new GSM();
        private GSM callTo = new GSM();

        private uint durationInSeconds = 0;

        public Call(DateOnly date, TimeOnly time, GSM callFrom, GSM callTo, uint durationInSeconds)
        {
            this.date = date;
            this.time = time;
            this.callFrom = callFrom;
            this.callTo = callTo;
            this.durationInSeconds = durationInSeconds;
        }

        public Call()
        {
            date = DateOnly.MinValue;
            TimeOnly time = TimeOnly.MinValue;
        }

        public void printCall()
        {
            string date = this.date.ToString();
            string time = this.time.ToString();

            Console.WriteLine(date + " " + time + " " + callFrom.ToString() + " " + callTo.ToString());
        }

        public uint getDurationInSeconds()
        {
            return durationInSeconds;
        }
    }

    static void Main(string[] args)
    {
        Battery battery = new Battery(0, "modelBattery", 90, 50);
        Display display = new Display(6, 2);
        GSM gsm = new GSM("iphone", "apple", 1500, "desi", battery, display);

        //gsm.printGSM();

        //Console.WriteLine(gsm.ToString());

        GSMTest test = new GSMTest();
        test.addGSM(gsm);
        test.addGSM(GSM.iphone4s);
        //test.printGSMs();

        Call call = new Call(new DateOnly(2023, 9, 2), new TimeOnly(15, 52), GSM.iphone4s, gsm, 569);
        //TimeOnly t = new TimeOnly()

        //call.printCall();

        Battery battery2 = new Battery(0, "modelBattery", 90, 50);
        Display display2 = new Display(6, 2);
        GSM gsm2 = new GSM("iphone2", "apple", 2500, "toni", battery, display);

        gsm.addCall(gsm2, new DateOnly(2023, 8, 4), new TimeOnly(13, 2), 60);
        gsm.addCall(GSM.iphone4s, new DateOnly(2023, 5, 4), new TimeOnly(13, 2), 120);

        Console.WriteLine(gsm.calculatePrice(0.37));

        //gsm.printCallHistory();

        gsm.removeLongestCall();

        Console.WriteLine(gsm.calculatePrice(0.37));
    }
}
