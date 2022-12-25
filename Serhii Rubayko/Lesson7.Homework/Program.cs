class String
{
    static bool SringEqual(string word1, string word2)
    {
        if (word1==word2) 
            return true;
        return false;
    }

    static int NumberofChars(string sentence)
    {
        //int tmp = 0;

        //sentence = "to be or not to be";
              
        
        return sentence.Length;

    }
      


    static void Main()
    {
        var c = "alfa";
        var d = "alfa";

        Console.WriteLine(SringEqual(c, d));

        var sentence1 = "one two three - rat on the tree";

        //int A = NumberofChars(sentence1);

        Console.WriteLine($"Sentence {sentence1} contain {NumberofChars(sentence1)} chars" );
        

    }
}

