namespace GeneticProgramming.Extensions
{
    public static class StringExtension
    {
        public static string ReplaceIndex(this string s, int index, char c)
        {
            var chars = s.ToCharArray();
            if (index >= chars.Length)
                return s;
            chars[index] = c;
            return new string(chars);
        }
    }
}
