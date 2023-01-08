//string str2 = new string('\u0027', 5);
//Console.WriteLine(str2);

//string string1 = "it's hard day ";

//string1 += "night";

//Console.WriteLine(string1);

//char CH = '\u0027';

//Console.Write(CH);


// First sentence of The Mystery of the Yellow Room, by Leroux.
string opening = "Ce n'est pas sans une certaine émotion que " +
                 "je commence à raconter ici les aventures " +
                 "extraordinaires de Joseph Rouletabille.";
// Character counters.
int nChars = 0;
// Objects to store word count.
List<int> chars = new List<int>();
List<int> elements = new List<int>();

foreach (var ch in opening)
{
    // Skip the ' character.
    if (ch == '\u0027') continue;

    if (Char.IsWhiteSpace(ch) | (Char.IsPunctuation(ch)))
    {
        chars.Add(nChars);
        nChars = 0;
    }
    else
    {
        nChars++;
    }
}

System.Globalization.TextElementEnumerator te =
   System.Globalization.StringInfo.GetTextElementEnumerator(opening);
while (te.MoveNext())
{
    string s = te.GetTextElement();
    // Skip the ' character.
    if (s == "\u0027") continue;
    if (String.IsNullOrEmpty(s.Trim()) | (s.Length == 1 && Char.IsPunctuation(Convert.ToChar(s))))
    {
        elements.Add(nChars);
        nChars = 0;
    }
    else
    {
        nChars++;
    }
}

// Display character counts.
Console.WriteLine("{0,10} {1,20} {2,20}",
                  "Word #", "Char Objects", "Characters");
for (int ctr = 0; ctr < chars.Count; ctr++)
    Console.WriteLine("{0,5} {1,20} {2,20}",
                      ctr, chars[ctr], elements[ctr]);
