namespace Assignment4
{
    // Fick göra extension eftersom mitt dictionary inte fyller någon
    // funktion om inte antalet en viss char förekommer.
    public static class DictionaryExtension
    {
        //public static void Enqueue<TKey>(this Dictionary<TKey, int> dictionary, TKey key) <-varning
        public static void Enqueue<TKey>(this Dictionary<TKey, int> dictionary, TKey key) where TKey : notnull
        {
            if (dictionary.ContainsKey(key))
            {
                dictionary[key]++;
            }
            else
            {
                dictionary[key] = 1;
            }
        }
    }
}
