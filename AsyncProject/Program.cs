using System;
using System.Threading.Tasks;

namespace AsyncProject;

class Program
{
    static async Task Main()
    {
        Console.WriteLine("Entering Main() application entry point.");

        int millisecondsDelay = 2000;
        await CallingMethodAsync(millisecondsDelay);

        Console.WriteLine("Exiting Main() application entry point.");

        await Task.Delay(millisecondsDelay + 500);
    }

    static async Task CallingMethodAsync(int millisecondsDelay)
    {
        Console.WriteLine("  Entering calling method.");

        // Call #1.
        // Call an async method. Because you don't await it, its completion
        // isn't coordinated with the current method, CallingMethodAsync.
        // The following line causes warning CS4014.
         CalledMethodAsync(millisecondsDelay);

        // Call #2.
        // To suppress the warning without awaiting, you can assign the
        // returned task to a variable. The assignment doesn't change how
        // the program runs. However, recommended practice is always to
        // await a call to an async method.

        // Replace Call #1 with the following line.
        //Task delayTask = CalledMethodAsync(millisecondsDelay);

        // Call #3
        // To contrast with an awaited call, replace the unawaited call
        // (Call #1 or Call #2) with the following awaited call. Best
        // practice is to await the call.

        // await CalledMethodAsync(millisecondsDelay);

        Console.WriteLine("  Returning from calling method.");
    }

    static async Task CalledMethodAsync(int millisecondsDelay)
    {
        Console.WriteLine("    Entering called method, starting and awaiting Task.Delay.");

        await Task.Delay(millisecondsDelay);

        Console.WriteLine("    Task.Delay is finished--returning from called method.");
    }
}

// Output with Call #1 or Call #2. (Wait for the last line to appear.)

// Entering Main() application entry point.
//   Entering calling method.
//     Entering called method, starting and awaiting Task.Delay.
//   Returning from calling method.
// Exiting Main() application entry point.
//     Task.Delay is finished--returning from called method.

// Output with Call #3, which awaits the call to CalledMethodAsync.

// Entering Main() application entry point.
//   Entering calling method.
//     Entering called method, starting and awaiting Task.Delay.
//     Task.Delay is finished--returning from called method.
//   Returning from calling method.
// Exiting Main() application entry point.

// Source + Explanation:
// https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/compiler-messages/cs4014?f1url=%3FappId%3Droslyn%26k%3Dk(CS4014)