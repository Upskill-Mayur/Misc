using System;
using System.Globalization;
using System.Runtime.InteropServices;

namespace BoxingUnboxing
{
    public class TestBoxUnbox
    {
        public static void Box()
        {
            int i = 10;
            Console.WriteLine("Boxing started....");
            unsafe
            {
                int* pointterTointi = &i;
                Console.WriteLine($"Address of the variable i is {(long)pointterTointi:X}");
            }
            //Boxing
            object o = i;

            unsafe
            {
                GCHandle objHandle = GCHandle.Alloc(o, GCHandleType.WeakTrackResurrection);
                int address = GCHandle.ToIntPtr(objHandle).ToInt32();
                Console.WriteLine($"Address of the variable o is {(long)address:X}");
            }


            //unboxing //Note that address of j is different that address of i.
            int j = (int)o;
            unsafe
            {
                int* pointterTointi = &j;
                Console.WriteLine($"Address of the variable j is {(long)pointterTointi:X}");
            }

            //This will throw invalid cast.
            double d = (double)o;
        }
    }
}