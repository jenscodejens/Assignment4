namespace Assignment4
{
    class Program
    {
        static void Main()
        {
            Console.Title = "Assignment 4 - Memory";
            while (true)
            {
                Console.Clear();
                Console.WriteLine("\n"
                    + "\n1. Examine a List"
                    + "\n2. Examine a Queue"
                    + "\n3. Examine a Stack"
                    + "\n4. CheckParenthesis"
                    + "\n0. Exit the application");
                char input = ' ';
                try
                {
                    input = Console.ReadLine()![0]; 
                }
                catch (IndexOutOfRangeException)
                {
                    Console.Clear();
                }
                switch (input)
                {
                    case '1':
                        //ExamineList();
                        ExamineList examineList = new ExamineList();
                        examineList.ExamineListMenu();
                        break;
                    case '2':
                        //ExamineQueue();
                        ExamineQueue examineQueue = new ExamineQueue();
                        examineQueue.InitialQueue();
                        break;
                    case '3':
                        //ExamineStack();
                        break;
                    case '4':
                        //CheckParanthesis();
                        CheckParanthesis.GetUserInputString();
                        break;
                    case '0':
                        Environment.Exit(0);
                        break;
                    default:
                        break;
                }
            }
        }
    }
}