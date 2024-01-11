using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;

namespace HotelBookingConsoleProject.Presentation.ConsoleCommand;

class CountIntegersCommand
{
    public void Execute()
    {
        int[] sizes = { 100000, 1000000, 10000000 };
        foreach (var size in sizes)
        {
            int[] array = GenerateArray(size);

            Stopwatch sw = Stopwatch.StartNew();
            long sumNormal = Sum(array);
            sw.Stop();
            long timeNormal = sw.ElapsedMilliseconds;

            sw.Restart();
            long sumParallel = ParallelSum(array);
            sw.Stop();
            long timeParallel = sw.ElapsedMilliseconds;

            sw.Restart();
            long sumLinq = LinqSum(array);
            sw.Stop();
            long timeLinq = sw.ElapsedMilliseconds;

            Console.WriteLine($"Size: {size}");
            Console.WriteLine($"Normal Sum: {sumNormal}, Time: {timeNormal}ms");
            Console.WriteLine($"Parallel Sum: {sumParallel}, Time: {timeParallel}ms");
            Console.WriteLine($"LINQ Sum: {sumLinq}, Time: {timeLinq}ms");
            Console.WriteLine();
        }
    }
    static int[] GenerateArray(int size)
    {
        var random = new Random();
        return Enumerable.Range(0, size).Select(_ => random.Next(100)).ToArray();
    }

    static long Sum(int[] array)
    {
        long sum = 0;
        for (int i = 0; i < array.Length; i++)
        {
            sum += array[i];
        }
        return sum;
    }
    static long ParallelSum(int[] array)
    {
        int threadCount = Environment.ProcessorCount;
        int partLength = array.Length / threadCount;
        long totalSum = 0;

        Thread[] threads = new Thread[threadCount];
        object lockObj = new object();

        for (int threadIndex = 0; threadIndex < threadCount; threadIndex++)
        {
            int localIndex = threadIndex;
            threads[threadIndex] = new Thread(() =>
            {
                long partialSum = 0;
                for (int i = localIndex * partLength; i < (localIndex + 1) * partLength && i < array.Length; i++)
                {
                    partialSum += array[i];
                }

                lock (lockObj)
                {
                    totalSum += partialSum;
                }
            });

            threads[threadIndex].Start();
        }

        foreach (var thread in threads)
        {
            thread.Join();
        }

        return totalSum;
    }
    static long LinqSum(int[] array)
    {
        return array.AsParallel().Sum(x => (long)x);
    }
}
