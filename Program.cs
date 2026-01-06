using System;
using System.Text;

//driver code
foreach(var keyValuePair in WordFrequency("Hello world! Hello C# World.world"))
{
   Console.Write($"KEY: {keyValuePair.Key} \t VALUE: {keyValuePair.Value}\n");
   Console.WriteLine();
}
// frequency counter function
static Dictionary<string,int> WordFrequency(string input)
{
   var freq = new Dictionary<string,int>(StringComparer.OrdinalIgnoreCase);
   if(string.IsNullOrEmpty(input)) return freq;
   var sb   =new StringBuilder();

   for(int i=0; i<input.Length; i++)
   {
      char c = input[i];
      if (char.IsLetterOrDigit(c) || c == '#')
      {
         sb.Append(c);
      }
      else if (sb.Length > 0)
      {
         //get tokenized word
         string word=sb.ToString();
         if(freq.TryGetValue(word,out int value))
            freq[word]=value+1;
         else
            freq[word]=1;
         sb.Clear();
      }
   }

   //if the last chars of @input are allowed chars
   if (sb.Length > 0)
   {
      string word=sb.ToString();
      freq[word]=freq.TryGetValue(word,out int value)? ++value: 1;
      sb.Clear();
   }
   return freq;
}