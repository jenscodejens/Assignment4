using System.Text;

namespace Assignment4
{
    internal class ExamineQueue
    {
        private Queue<string> icaQueue = new Queue<string>();
        private int i = 1;
        private const string namePrefix = "Person#";

        public void InitialQueue()
        {
            var icaQueue = new Queue<string>();
            Console.Clear();
            Console.WriteLine("We start with an empty queue\n" +
                              $"Number of people in queue: {icaQueue.Count}");

            ExamineListMenu();
        }

        private void ExamineListMenu()
        {
            Console.WriteLine("\n"
                            + "\n[+]  Add person to queue"
                            + "\n[-]  Remove person from queue"
                            + "\n[0]  Exit\n");
            while (true)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(intercept: true);
                char keyChar = keyInfo.KeyChar;
                string personName = namePrefix + i;

                switch (keyChar)
                {
                    case '+':
                        icaQueue.Enqueue(personName);
                        Console.WriteLine($"{personName} added to the queue.");
                        DisplayQueuingInfo();
                        i++;
                        break;
                    case '-':
                        if (icaQueue.Count > 0)
                        {
                            icaQueue.Dequeue();
                            Console.WriteLine($"Removed {personName} from the queue.");
                            DisplayQueuingInfo();
                        }
                        else
                        {
                            Console.WriteLine("Queue is empty");
                        }
                        break;
                    case '0':
                        return;
                    default:
                        Console.WriteLine("Invalid input. Enter + or -");
                        break;
                }
            }
        }

        private void DisplayQueuingInfo()
        {
            // Tenarary version
            Console.WriteLine(icaQueue.Count == 0
                ? "Queue is empty"
                : $"Next to be dequeued: {icaQueue.Peek()}\n" +
                  $"Number of people in queue: {icaQueue.Count}");
            /* 
             * if (icaQueue.Count == 0)
             * {
             *    Console.WriteLine("Queue is empty");
             * }
             * else
             * {
             *    Console.WriteLine($"People in queue: {icaQueue.Count}\nNext to be dequeued: {icaQueue.Peek()}\n");
             * }
            */
            StringBuilder sb = new StringBuilder();
            foreach (string item in icaQueue)
            {
                sb.Append(item + ", ");
            }
            Console.WriteLine(sb);
            Console.WriteLine("....\n");
        }
    }
}