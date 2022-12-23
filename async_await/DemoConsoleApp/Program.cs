/*
 * The examples below show how async and await can be used to start multiple methods at the same time, resulting in increased performance and save processing time by running multiple threads concurrently.
 * 
 * Here 7 differed tasks are demonstrated out of first three i.e. washing, drying and ironing clothes are synchnous and rest four i.e. Pay utility bill, shopping groceries, cleaning and fixing door handle are asynchronously called. 
 */
using System;

namespace TestingCSharp
{
    class ProgramTest
    {

        static async Task Main()
        {
            ConsoleWriteLine(" START");    
            
            /* Synchronous calls */
            String ret = await washClothes();            
            await dryClothes(ret);
            await ironClothes();

            /* Asynchronous calls */
            Task t2 = payUtilityBill();
            Task t3 = shoppingGroceries();
            Task t4 = cleaning();
            Task t5 = fixDoorHandle();
            await Task.WhenAll(t2, t3, t4, t5);

            ConsoleWriteLine(" END");
        }

        static async Task<String> washClothes()
        {
            ConsoleWriteLine(" washing started..");
            await Task.Delay(1000);
            ConsoleWriteLine(" washing done..");
            return " drying started";
        }

        static async Task dryClothes(String retindication)
        {
            ConsoleWriteLine(retindication);
            await Task.Delay(1000);
            ConsoleWriteLine(" drying done..");
        }

        static async Task ironClothes()
        {
            ConsoleWriteLine(" ironing started..");
            await Task.Delay(1000);
            ConsoleWriteLine(" ironing done..");
        }

        static async Task shoppingGroceries()
        {
            ConsoleWriteLine(" shopping started");
            await Task.Delay(1000);
            ConsoleWriteLine(" shopping done");
        }

        static async Task payUtilityBill()
        {            
            ConsoleWriteLine(" start paying bill");
            await Task.Delay(1000);
            ConsoleWriteLine(" bill paid");
        }

        static async Task cleaning()
        {
            ConsoleWriteLine(" start cleaning");
            await Task.Delay(1000);
            ConsoleWriteLine(" cleaning done");
        }
        static async Task fixDoorHandle()
        {
            ConsoleWriteLine(" start fixing door handle");
            await Task.Delay(1000);
            ConsoleWriteLine(" door handle fixed");
        }

        static void ConsoleWriteLine(string str)
        {
            int threadId = Thread.CurrentThread.ManagedThreadId;
            Console.ForegroundColor = threadId == 1 ? ConsoleColor.White : ConsoleColor.Cyan;
            Console.WriteLine(
               $"{DateTime.Now} - {str}{new string(' ', 36 - str.Length)}   Thread {threadId}");
        }
    }
}