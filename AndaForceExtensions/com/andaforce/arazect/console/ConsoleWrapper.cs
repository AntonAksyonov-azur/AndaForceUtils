using System;

namespace AndaForceExtensions.com.andaforce.arazect.console
{
    public static class ConsoleWrapper
    {
        public static void WriteUserWaitPattern()
        {
            Console.WriteLine("\n\nPress any key to continue...");
            Console.ReadKey();
        }
    }
}