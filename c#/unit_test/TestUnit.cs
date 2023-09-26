using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Diagnostics;
using System.Runtime.InteropServices;
using classes;

namespace classes
{
    internal class Utils<T>
    {
        public T? getReflectionValue(Call call, string propertyName)
        {
            T result = default(T);
            Type type = call.GetType();

            FieldInfo fieldInfo = type.GetField(propertyName, BindingFlags.NonPublic | BindingFlags.Instance);

            if (fieldInfo != null)
            {
                result = (T)fieldInfo.GetValue(call);
            }

            return result;
        }
    }

    //['prop1', 'prop2', 'prop3']
    //[DateOnly, int, string]
   

    [TestFixture]
    internal class TestUnit
    {
        [TestCase]
        public void testAddCall()
        {
            Battery battery = new Battery(0, "modelBattery", 90, 50);
            Display display = new Display(6, 2);
            GSM gsm = new GSM("iphone", "apple", 1500, "desi", battery, display);

            Call call = new Call(new DateOnly(2023, 5, 4), new TimeOnly(13, 2), gsm, GSM.iphone4s, 120);

            gsm.addCall(call/*GSM.iphone4s, new DateOnly(2023, 5, 4), new TimeOnly(13, 2), 120*/);

            
            Assert.AreEqual(gsm.getCallHistory().Count, 1);

            Utils<DateOnly> utilsDateOnly = new Utils<DateOnly>();
            Assert.AreEqual(utilsDateOnly.getReflectionValue(call, "date"), utilsDateOnly.getReflectionValue(gsm.getCall(0), "date"));

            Utils<TimeOnly> utilsTimeOnly = new Utils<TimeOnly>();
            Assert.AreEqual(utilsTimeOnly.getReflectionValue(call, "time"), utilsTimeOnly.getReflectionValue(gsm.getCall(0), "time"));

            Utils<GSM> utilsCallTo = new Utils<GSM>();
            Assert.AreEqual(utilsCallTo.getReflectionValue(call, "callTo"), utilsCallTo.getReflectionValue(gsm.getCall(0), "callTo"));

           // Utils<GSM> utilsCallTo = new Utils<GSM>();
            Assert.AreEqual(utilsCallTo.getReflectionValue(call, "callFrom"), utilsCallTo.getReflectionValue(gsm.getCall(0), "callFrom"));

        }

        [TestCase]
        public void testRemoveCall()
        {
            Battery battery = new Battery(0, "modelBattery", 90, 50);
            Display display = new Display(6, 2);
            GSM gsm = new GSM("iphone", "apple", 1500, "desi", battery, display);

            Call call = new Call(new DateOnly(2023, 5, 4), new TimeOnly(13, 2), gsm, GSM.iphone4s, 120);

            gsm.addCall(call/*GSM.iphone4s, new DateOnly(2023, 5, 4), new TimeOnly(13, 2), 120*/);

            Call tempCall = gsm.getCall(0);
            gsm.deleteCall(call);

            Assert.AreEqual(gsm.getCallHistory().Count, 0);

            Utils<DateOnly> utilsDateOnly = new Utils<DateOnly>();
            Assert.AreEqual(utilsDateOnly.getReflectionValue(call, "date"), utilsDateOnly.getReflectionValue(tempCall, "date"));

            Utils<TimeOnly> utilsTimeOnly = new Utils<TimeOnly>();
            Assert.AreEqual(utilsTimeOnly.getReflectionValue(call, "time"), utilsTimeOnly.getReflectionValue(tempCall, "time"));

            Utils<GSM> utilsCallTo = new Utils<GSM>();
            Assert.AreEqual(utilsCallTo.getReflectionValue(call, "callTo"), utilsCallTo.getReflectionValue(tempCall, "callTo"));

            // Utils<GSM> utilsCallTo = new Utils<GSM>();
            Assert.AreEqual(utilsCallTo.getReflectionValue(call, "callFrom"), utilsCallTo.getReflectionValue(tempCall, "callFrom"));

        }

        [TestCase]
        public void testRemoveLongestCall()
        {
            Battery battery = new Battery(0, "modelBattery", 90, 50);
            Display display = new Display(6, 2);
            GSM gsm = new GSM("iphone", "apple", 1500, "desi", battery, display);

            Call call = new Call(new DateOnly(2023, 5, 4), new TimeOnly(13, 2), gsm, GSM.iphone4s, 120);
            Call longestCall = new Call(new DateOnly(2023, 6, 4), new TimeOnly(13, 2), gsm, GSM.iphone4s, 500);

            gsm.addCall(call/*GSM.iphone4s, new DateOnly(2023, 5, 4), new TimeOnly(13, 2), 120*/);
            gsm.addCall(longestCall/*GSM.iphone4s, new DateOnly(2023, 5, 4), new TimeOnly(13, 2), 120*/);

            Call tempCall = gsm.getCall(1);

            gsm.removeLongestCall();
         
            Assert.AreEqual(gsm.getCallHistory().Count, 1);

            Utils<DateOnly> utilsDateOnly = new Utils<DateOnly>();
            Assert.AreEqual(utilsDateOnly.getReflectionValue(longestCall, "date"), utilsDateOnly.getReflectionValue(tempCall, "date"));

            Utils<TimeOnly> utilsTimeOnly = new Utils<TimeOnly>();
            Assert.AreEqual(utilsTimeOnly.getReflectionValue(longestCall, "time"), utilsTimeOnly.getReflectionValue(tempCall, "time"));

            Utils<GSM> utilsCallTo = new Utils<GSM>();
            Assert.AreEqual(utilsCallTo.getReflectionValue(longestCall, "callTo"), utilsCallTo.getReflectionValue(tempCall, "callTo"));

            // Utils<GSM> utilsCallTo = new Utils<GSM>();
            Assert.AreEqual(utilsCallTo.getReflectionValue(longestCall, "callFrom"), utilsCallTo.getReflectionValue(tempCall, "callFrom"));
        }

        [TestCase]
        public void testCalculatePrice()
        {
            Battery battery = new Battery(0, "modelBattery", 90, 50);
            Display display = new Display(6, 2);
            GSM gsm = new GSM("iphone", "apple", 1500, "desi", battery, display);

            Call call = new Call(new DateOnly(2023, 5, 4), new TimeOnly(13, 2), gsm, GSM.iphone4s, 60);
            gsm.addCall(call/*GSM.iphone4s, new DateOnly(2023, 5, 4), new TimeOnly(13, 2), 120*/);

            double price = gsm.calculatePrice(1);

            Assert.AreEqual(price, 1);

        }
        [TestCase]
        public void testClearCallHistory()
        {
            Battery battery = new Battery(0, "modelBattery", 90, 50);
            Display display = new Display(6, 2);
            GSM gsm = new GSM("iphone", "apple", 1500, "desi", battery, display);

            Call call = new Call(new DateOnly(2023, 5, 4), new TimeOnly(13, 2), gsm, GSM.iphone4s, 60);
            gsm.addCall(call/*GSM.iphone4s, new DateOnly(2023, 5, 4), new TimeOnly(13, 2), 120*/);

            gsm.clearCallHistory();

            Assert.AreEqual(0, gsm.getCallHistory().Count);
        }

        [TestCase]
        public void testToString()
        {
            Battery battery = new Battery(0, "modelBattery", 90, 50);
            Display display = new Display(6, 2);
            GSM gsm = new GSM("iphone", "apple", 1500, "desi", battery, display);

            string result = "iphone" + " " + "apple" + " " + "1500" + " " + "desi"  + "\n";

            Assert.AreEqual(result, gsm.ToString());
        }

       public void print()
        {
            Battery battery = new Battery(0, "modelBattery", 90, 50);
            Display display = new Display(6, 2);
            GSM gsm = new GSM("iphone", "apple", 1500, "desi", battery, display);

            DateOnly date = new DateOnly(2023, 5, 4);
            TimeOnly time = new TimeOnly(13, 2);

            Call call = new Call(date, time, gsm, GSM.iphone4s, 60);
            gsm.addCall(call/*GSM.iphone4s, new DateOnly(2023, 5, 4), new TimeOnly(13, 2), 120*/);

            string dateString = date.ToString();
            string timeString = time.ToString();

            string callToString = GSM.iphone4s.ToString();
            string callFromString = gsm.ToString();

            string result = date + " " + time + " " + callFromString + " " + callToString;

           // Console.WriteLine(result);
            gsm.printCallHistory();
        }
        [TestCase]
        public void testPrintCallHistory()
        {
            /*Battery battery = new Battery(0, "modelBattery", 90, 50);
            Display display = new Display(6, 2);
            GSM gsm = new GSM("iphone", "apple", 1500, "desi", battery, display);

            DateOnly date = new DateOnly(2023, 5, 4);
            TimeOnly time = new TimeOnly(13, 2);

            Call call = new Call(date, time, gsm, GSM.iphone4s, 60);
            gsm.addCall(call*//*GSM.iphone4s, new DateOnly(2023, 5, 4), new TimeOnly(13, 2), 120*//*);

            string dateString = date.ToString();
            string timeString = time.ToString();

            string callToString = GSM.iphone4s.ToString();
            string callFromString = gsm.ToString();

            string result = date + " " + time + " " + callFromString + " " + callToString;

            Console.WriteLine(result);
            gsm.printCallHistory();

            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);
            var output = stringWriter.ToString();

            Assert.AreEqual(result + "\n", output);*/
        }
        static void Main(string[] args)
        {
            TestUnit test = new TestUnit();
            //test.print();
            Battery battery = new Battery(0, "modelBattery", 90, 50);
            Display display = new Display(6, 2);
            GSM gsm = new GSM("iphone", "apple", 1500, "desi", battery, display);

            DateOnly date = new DateOnly(2023, 5, 4);
            TimeOnly time = new TimeOnly(13, 2);

            Call call = new Call(date, time, gsm, GSM.iphone4s, 60);
            gsm.addCall(call/*GSM.iphone4s, new DateOnly(2023, 5, 4), new TimeOnly(13, 2), 120*/);

            string dateString = date.ToString();
            string timeString = time.ToString();

            string callToString = GSM.iphone4s.ToString();
            string callFromString = gsm.ToString();

            string result = date + " " + time + " " + callFromString + " " + callToString;

            //Console.WriteLine(result);
            gsm.printCallHistory();

            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);
            var output = stringWriter.ToString();

            Assert.AreEqual(result + "\n", output);

        }
    }
   
   
}


