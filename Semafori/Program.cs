using System;

namespace Semafori
{
    class Program
    {
        static void Main(string[] args)
        {
            // Semafori problem (traffic lights)
            // https://open.kattis.com/problems/semafori
            // this is my solution.

            // --------------------------------------
            var twoParameters = Road2Parameters();
            var numOfTraffLights = twoParameters[0];
            var roadLength = twoParameters[1];

            // ---------------------------------------

            int initialDistance = 0;
            int cycle;
            int d, r, g;
            int previousDistance = 0;
            for (int count = 0; count < numOfTraffLights; count++)
            {
                var traffParameters = TraffLight3Parameters(roadLength);
                d = traffParameters[0];
                r = traffParameters[1];
                g = traffParameters[2];

                cycle = r + g;
                initialDistance = initialDistance + (d - previousDistance);

                if ((initialDistance % cycle) < r)
                    initialDistance = initialDistance + (Math.Abs((initialDistance % cycle) - r));

                previousDistance = d;
            }
            initialDistance = initialDistance + (roadLength - previousDistance);
            Console.WriteLine(initialDistance);
        }

        private static int[] TraffLight3Parameters(int roadLeng)
        {
            string str = " ";
            string[] strArr = new string[3] { " ", " ", " " };
            int[] res = new int[3] { 0, 0, 0 };
            try
            {
                strArr = Console.ReadLine().Split(' ', 3);
                if (strArr.Length != 3)
                    throw new IndexOutOfRangeException();
                res[0] = int.Parse(strArr[0]);
                res[1] = int.Parse(strArr[1]);
                res[2] = int.Parse(strArr[2]);
                if (res[0] <1 || res[0] >= roadLeng)
                    throw new IndexOutOfRangeException();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.GetType().ToString());
                return TraffLight3Parameters(roadLeng);
            }
            return res;
        }


        private static int[] Road2Parameters()
        {
            string[] strArr = new string[2] { " ", " " };
            int[] res = new int[2] { 0, 0 };
            try
            {
                strArr = Console.ReadLine().Split(' ', 2);
                if (strArr.Length != 2)
                    throw new IndexOutOfRangeException();
                res[0]= int.Parse(strArr[0]);
                res[1]= int.Parse(strArr[1]);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.GetType().ToString());
                return Road2Parameters();
            }
            return res;
        }
    }
}
