namespace Assignment4
{
    // Ville inte ha spammig output varje gång ett item läggs till på listan.
    // Så de döljs och det sker en output endast vid dubblering av capacity och trimming av capacity vid borttagning av items på listan.
    internal class ExamineList
    {
        private List<string> stringList = new List<string>();
        private static int tempCapacity = 0;

        public void InitialiseList()
        {
            var stringList = new List<string>();
            tempCapacity = stringList.Capacity;
            Console.Clear();
            Console.WriteLine("We start with an empty list\n" +
                              "List count:    " + stringList.Count + "\n" +
                              "List capacity: " + stringList.Capacity + "\n" +
                              "....");
        }
        public void ExamineListMenu()
        {
            Console.WriteLine("\n"
                            + "\n[+]  Add string to list"
                            + "\n[-]  Remove string from list"
                            + "\n[0]  Exit\n");
            InitialiseList();
            while (true)
            {
                /// <summary>
                /// From:
                /// Click <see href="https://learn.microsoft.com/en-us/dotnet/api/system.console.readkey?view=net-8.0">here</see> to See the picture.
                /// 
                /// If the intercept parameter is true, the pressed key is intercepted and not displayed
                /// in the console window; otherwise, the pressed key is displayed.
                ///
                ///</summary>
                ConsoleKeyInfo keyInfo = Console.ReadKey(intercept: true);
                char keyChar = keyInfo.KeyChar;

                switch (keyChar)
                {
                    case '+':
                        AddToList();
                        break;
                    case '-':
                        RemoveFromList();
                        break;
                    case '0':
                        return;
                    default:
                        Console.WriteLine("Enter + or -");
                        Console.ReadKey(intercept: true);
                        Utilities.ClearPreviousConsoleLine();
                        break;
                }
            }
        }

        // Liten notis som jag noterade sent. Om en lista får sitt första item blir dess capacity 4 by default.
        // I koden nedan när första item läggs till listan får den lite felaktigt en output att capacity dubblerats. Borde fixas.
        public void AddToList()
        {
            stringList.Add("Adam");

            if (tempCapacity != stringList.Capacity)
            {
                Console.WriteLine($"You now added item number: {stringList.Count} to the list.\n" +
                                  $"And that exceeds its capacity ({tempCapacity}) so capacity now gets doubled");

                Console.WriteLine("List count:    " + stringList.Count +
                                "\nList capacity: " + stringList.Capacity +
                                "\n....");
                tempCapacity = stringList.Capacity;
            }
        }

        public void RemoveFromList()
        {
            if (stringList.Count == 0)
            {
                Console.WriteLine("List is empty");
                Console.WriteLine("List count:    " + stringList.Count +
                                "\nList capacity: " + stringList.Capacity +
                                "\nAuto trimming to 0 capacity.");
                stringList.TrimExcess();
            }
            else
            {
                stringList.Remove("Adam");

                if ((stringList.Capacity - stringList.Count) >= 5)
                {
                    TrimExcessList();
                }
            }
        }

        // Metod för att trimma ned listans capacity eftersom det inte sker automatiskt
        // Valde attkalla på den direkt från RemoveFromList() är logiskt.
        // Ingen aning hur många objekts som kommer läggas till. 
        // Ett alternati hade varit någon form av loop som den körs kontinuerligt i. 
        // Trimming sker vid 5+ överflödig capacity.
        public void TrimExcessList()
        {
            Console.WriteLine("List count:    " + stringList.Count +
                            "\nList capacity: " + stringList.Capacity);

            stringList.TrimExcess();

            Console.WriteLine("The capacity of the list had 5 or more slots unused. Autotrimmed!");
            Console.WriteLine("List count:    " + stringList.Count +
                            "\nList capacity: " + stringList.Capacity +
                            "\n....");
        }
    }
}
