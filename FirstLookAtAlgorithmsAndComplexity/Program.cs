using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstLookAtAlgorithmsAndComplexity
{
    class Program
    {
        private static int[] theArray;
        private static int arraySize;
        private static int itemsInArray = 0;
        private static DateTime startTime;
        private static DateTime endTime;
        private static TimeSpan elapsedTIme;
        private static Stopwatch sw = new Stopwatch();
        private static Random randomNumberGenerator = new Random();


        /// <summary>
        /// In this applicaiton I will be exploring examples of algorithms with different complexities. The complexities that will be investigated are as follows;
        /// O(1)
        /// O(N)
        /// O(N^N)
        /// O(log N)
        /// O(N log N)
        /// </summary>
        /// <param name="args"></param>

        static void Main(string[] args)
        {
            //Algorithms with different sizes of Arrays

            //O(N)
            BigONotation(10000);
            GenerateRandomNumberArray();
            linearSearchForValue(101);

            BigONotation(20000);
            GenerateRandomNumberArray();
            linearSearchForValue(101);

            BigONotation(30000);
            GenerateRandomNumberArray();
            linearSearchForValue(101);

            BigONotation(40000);
            GenerateRandomNumberArray();
            linearSearchForValue(101);

            //O(N^2)
            BigONotation(10000);
            GenerateRandomNumberArray();
            BubbleSort();

            BigONotation(20000);
            GenerateRandomNumberArray();
            BubbleSort();

            BigONotation(30000);
            GenerateRandomNumberArray();
            BubbleSort();

            BigONotation(40000);
            GenerateRandomNumberArray();
            BubbleSort();

            //O(log N)
            BigONotation(10000);
            GenerateRandomNumberArray();
            BinarySearchForValue(20);

            BigONotation(20000);
            GenerateRandomNumberArray();
            BinarySearchForValue(20);

            BigONotation(30000);
            GenerateRandomNumberArray();
            BinarySearchForValue(20);

            BigONotation(40000);
            GenerateRandomNumberArray();
            BinarySearchForValue(20);

            //O(N log N)
            BigONotation(10000);
            GenerateRandomNumberArray();
            sw.Reset();
            sw.Start();
            QuickSort(0,theArray.Length - 1);
            sw.Stop();
            PrintResults("O(N log N)");

            BigONotation(20000);
            GenerateRandomNumberArray();
            sw.Reset();
            sw.Start();
            QuickSort(0, theArray.Length - 1);
            sw.Stop();
            PrintResults("O(N log N)");

            BigONotation(30000);
            GenerateRandomNumberArray();
            sw.Reset();
            sw.Start();
            QuickSort(0, theArray.Length - 1);
            sw.Stop();
            PrintResults("O(N log N)");

            BigONotation(40000);
            GenerateRandomNumberArray();
            sw.Reset();
            sw.Start();
            QuickSort(0, theArray.Length - 1);
            sw.Stop();
            PrintResults("O(N log N)");


        }

        private static void QuickSort(int left, int right)
        {
           
            if (right - left <= 0)
            {
                return;
            }
            else
            {
                var pivot = theArray[right];
                var pivotLocation = partitionArray(left, right, pivot);
                QuickSort(left, pivotLocation - 1);
                QuickSort(pivotLocation + 1, right);
            }
           
        }

        private static int partitionArray(int left, int right, int pivot)
        {
            var leftPointer = left - 1;
            var rightPointer = right;

            while (true)
            {
                while (theArray[++leftPointer] < pivot)
                {

                }
                while (rightPointer > 0 && theArray[--rightPointer] > pivot)
                {

                }
                if (leftPointer >= rightPointer)
                {
                    break;
                }
                else
                {
                    swapValues(leftPointer, rightPointer);
                }
            }

            swapValues(leftPointer, right);
            return leftPointer;
        }

        private static void BinarySearchForValue(int value)
        {
            sw.Reset();
            sw.Start();

            var lowIdx = 0;
            var highIdx = arraySize - 1;

            var timesThrough = 0;

            while (lowIdx <= highIdx)
            {
                var middleIdx = (highIdx + lowIdx) / 2;

                if (theArray[middleIdx] < value)
                {
                    lowIdx = middleIdx + 1;
                }
                else if (theArray[middleIdx] > value)
                {
                    highIdx = middleIdx - 1;
                }
                else
                {
                    lowIdx = highIdx + 1;
                }

                timesThrough++;
            }

            sw.Stop();
            PrintResults("O(log N)", timesThrough.ToString());
        }

        private static void BubbleSort()
        {
            sw.Reset();
            sw.Start();

            for (int i = arraySize - 1; i > 1; i--)
            {
                for (int j = 0; j < i; j++)
                {
                    if (theArray[j] > theArray[j+1])
                    {
                        swapValues(j, j + 1);
                    }
                }
            }

            sw.Stop();
            PrintResults("O(N^2)");

        }

        private static void swapValues(int indexOne, int indexTwo)
        {
            var temp = theArray[indexOne];
            theArray[indexOne] = theArray[indexTwo];
            theArray[indexTwo] = temp;
        }

        private static void GenerateRandomNumberArray()
        {
            for (int i = 0; i < arraySize; i++)
            {
                theArray[i] = Int32.Parse(randomNumberGenerator.Next(0, 65500).ToString()) + 10;
            }
        }

        private static void BigONotation(int size)
        {
            arraySize = size;
            theArray = new int[size];
        }

        private static void OrderOf1Algorithm()
        {
            var newItem = 0;

            AddItemToArray(newItem);
        }

        private static void AddItemToArray(int newItem)
        {
            theArray[itemsInArray++] = newItem;
        }

        private static void OrderOfNAlgorithm()
        {
            var value = 0;
            linearSearchForValue(value);
        }

        private static void linearSearchForValue(int value)
        {
            bool valueInArray = false;
            string indecesWithValue = "";

            sw.Reset();
            sw.Start();

            for (int i = 0; i < arraySize; i++)
            {
                if (theArray[i] == value)
                {
                    valueInArray = true;
                    indecesWithValue += i + ",";
                }
            }

            sw.Stop();
            PrintResults("O(N) ");
        }

        private static void PrintResults(string orderType, string timesThrough = "")
        {
            Console.Write(orderType  + " Size: " + arraySize + " Ticks: {0:N} ", sw.ElapsedTicks);

            if (!string.IsNullOrWhiteSpace(timesThrough))
            {
                Console.WriteLine("Times Though: {0:N}", timesThrough);
            }
            else
            {
                Console.WriteLine();
            }
        }
    }
}
