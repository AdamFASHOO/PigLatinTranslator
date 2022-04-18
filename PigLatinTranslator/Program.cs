class Program
{
    public static void Main()
    {
        bool goAgain = true;
        while (goAgain == true)
        {
            Console.WriteLine("Please enter your word or sentence for translation: ");
            string userInput = Console.ReadLine().ToLower().Trim();

            string pigLatin = Translator(userInput);
            Console.WriteLine(pigLatin);

            goAgain = RunAgain();
        }
    }

    /// <summary>
    /// Method translates user input to Pig Latin
    /// </summary>
    /// <param name="userInput">A user defined string</param>
    /// <returns>Returns translated sentence from user as string</returns>

    private static string Translator(string userInput)
    {
        char[] vowels = { 'a', 'e', 'i', 'o', 'u'};
        string returnSentence = "";

        foreach (string word in userInput.Split())
        {
            int currentIndex = -1;
            int firstVowel;
            foreach (char vow in vowels)
            {
                firstVowel = word.IndexOf(vow);
                if (firstVowel >= 0)
                {
                    if (firstVowel < currentIndex || currentIndex == -1)
                    {
                        currentIndex = firstVowel;
                    }
                }
            }
            if (currentIndex == -1)
            {
                returnSentence += word + "way ";
            }
            else
            {
                string firstConsonants = word.Substring(0, currentIndex);
                string endOfWord = word.Substring(currentIndex);

                returnSentence += endOfWord + firstConsonants + "ay ";
            }
            
        }
        return returnSentence;
    }
    
    public static string GetUserInput(string prompt)
    {
        Console.WriteLine(prompt);
        string input = Console.ReadLine();
        return input;
    }

    public static bool RunAgain()
    {
        string answer = GetUserInput("\nWould you like to translate another word/sentence? y/n ").ToLower();
        if (answer == "y")
        {
            return true;
        }
        else if (answer == "n")
        {
            Console.WriteLine("Goodbye!");
            return false;
        }
        else
        {
            Console.WriteLine("\nI'm sorry, I didn't understand that. \nPlease input y/n\nTry again:");
            return RunAgain();
        }
    }
}