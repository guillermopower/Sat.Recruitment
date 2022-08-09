using System;
using System.Text.RegularExpressions;

namespace Sat.Recruitment.Business.Validations
{
    public class RegularExpressionValidation
    {
        public static int WordReserved(string wordsStr)
        {
            string[] dictionary = { "SCRIPT", "SELECT", "DROP", "FROM", "INSERT", "DELETE", "ALTER", "DUMP", "EXECUTE", "EXEC", "UPDATE", "TRUNCATE", "REPLACE", "PRINT", "TRUE", "FALSE", "TRUE", "*" };
            var words = Regex.Split(wordsStr, "\\s+");

            foreach (var word in words)
            {
                var index = Array.IndexOf(dictionary, word.ToUpper());
                if (index > -1)
                {
                    return index;
                }
            }

            return -1;
        }
    }
}