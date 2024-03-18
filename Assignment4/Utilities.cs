namespace Assignment4
{
    internal class Utilities
    {
        public static void ClearPreviousConsoleLine()
        {
            Console.CursorTop--;
            int currentLineCursor = Console.CursorTop;
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, currentLineCursor);
        }
    }
}