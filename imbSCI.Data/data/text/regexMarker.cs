namespace imbSCI.Data.data.text
{
    using System;
    using System.Text.RegularExpressions;

    public class regexMarker<T>
    {
       

        public regexMarker(String regex, T __m)
        {
            marker = __m;
            test = new Regex(regex);

        }

        public ConsoleColor foreground { get; set; } = ConsoleColor.White;
        public ConsoleColor background { get; set; } = ConsoleColor.DarkGray;

        public Regex test { get; set; }
        public T marker { get; set; }
    }

}