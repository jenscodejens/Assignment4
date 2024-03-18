using System.Text.RegularExpressions;

namespace Assignment4
{
    internal class CheckParanthesis
    {
        private static Dictionary<char, int> dictionary = new Dictionary<char, int>();

        private const string openingPattern = @"[{\(\[]";
        private const string closingPattern = @"[}\)\]]";
        private const string rules = "Checking for opening & closing of { }, ( ) and [ ]: \nYour text: ";

        public static void GetUserInputString()
        {
            bool success = false;
            string userInput;
            Console.Write(rules);

            do
            {
                userInput = Console.ReadLine()!;

                if (string.IsNullOrWhiteSpace(userInput))
                {
                    Console.Clear();
                    Console.Write(rules);
                }
                else
                {
                    success = true;
                }

            } while (!success);

            PutCharInDictionary(userInput);
        }

        // Lägger in {([ i dictionary först, sedan })]
        // Här används extension av Enqueue (DictionaryExtension.cs)
        public static void PutCharInDictionary(string userInput)
        {
            MatchCollection allOpeningMatches = Regex.Matches(userInput, openingPattern);
            MatchCollection allClosingMatches = Regex.Matches(userInput, closingPattern);

            foreach (Match match in allOpeningMatches)
            {
                foreach (char c in match.Value)
                {
                    dictionary.Enqueue(c);
                }
            }

            foreach (Match match in allClosingMatches)
            {
                foreach (char c in match.Value)
                {
                    dictionary.Enqueue(c);
                }
            }

            CheckParentheses();
        }

        // While loop som via CheckEachKind() får tillbaka en bool om antalet "{" är samma som antalet "}".
        // Sedan upprepas detta med () och sist []. Loopen avbryts vid första fel.
        private static void CheckParentheses()
        {
            while (true)
            {
                if (!CheckEachKind('{', '}'))
                {
                    Console.WriteLine("Mismatch in curly brackets.");
                    Console.ReadLine();
                    break;
                }

                if (!CheckEachKind('(', ')'))
                {
                    Console.WriteLine("Mismatch in parentheses.");
                    Console.ReadLine();
                    break;
                }

                if (!CheckEachKind('[', ']'))
                {
                    Console.WriteLine("Mismatch in square brackets.");
                    Console.ReadLine();
                    break;
                }

                Console.WriteLine("All brackets are okey.\n");
                DebugPrint(); 
                Console.ReadLine();
                break;
            }
        }
        // Linq metoden som anropas av CheckParentheses().
        // Metoden får två inparametrar som motsvarar den char som skall kollas upp i dictionary
        // Dessa är antalet öppna vs stängda och boolen om de överensstämmer skickas tillbaka till CheckParentheses()
        private static bool CheckEachKind(char o, char c)
        {
            int openingBracket = dictionary.Where(p => p.Key == o).Select(p => p.Value).Sum();
            int closingBracket = dictionary.Where(p => p.Key == c).Select(p => p.Value).Sum();

            return openingBracket == closingBracket;
        }
        public static void DebugPrint()
        {
            foreach (var item in dictionary)
            {
                Console.WriteLine($"Char: {item.Key} Hits: {item.Value}");
            }
        }
        // Teststräng: List<int> lista = new List<int>(){2, 3, 4} [[ ehre () 64ht ]//]
    }
}