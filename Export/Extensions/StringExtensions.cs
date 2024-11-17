namespace Export.Extensions
{
    /// <summary>
    /// Extensions for the <see cref="System.String"/>.
    /// </summary>
    public static class StringExtensions
    {
        #region [ Methods ]

        /// <summary>
        /// Prints the <paramref name="this"/> string as debug message.
        /// </summary>
        /// <param name="this">Message to be written to the console.</param>
        public static string Debug(this string @this)
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write(@this);
            Console.Write(" ");
            Console.ResetColor();

            return @this;
        }


        /// <summary>
        /// Prints the <paramref name="this"/> string as info message.
        /// </summary>
        /// <param name="this">Message to be written to the console.</param>
        public static string Success(this string @this)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write(@this);
            Console.Write(" ");
            Console.ResetColor();

            return @this;
        }
        
        
        /// <summary>
        /// Prints the <paramref name="this"/> string as error message.
        /// </summary>
        /// <param name="this">Message to be written to the console.</param>
        public static string Error(this string @this)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write(@this);
            Console.Write(" ");
            Console.ResetColor();

            return @this;
        }


        /// <summary>
        /// Prints the new line.
        /// </summary>
        /// <param name="this">Message to be written to the console.</param>
        public static string Eol(this string @this)
        {
            Console.WriteLine();

            return @this;
        }


        /// <summary>
        /// Prints the new line.
        /// </summary>
        /// <param name="this">Message to be written to the console.</param>
        public static string Indent(this string @this)
        {
            Console.Write("    ");

            return @this;
        }

        #endregion
    }
}
