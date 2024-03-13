using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDiary
{
    public class TextService
    {
        public static string GetStringFromUser()
        {
            return Console.ReadLine();
        }

        public static int GetIntegerFromUser()
        {
            int integerNumber;
            var input = Console.ReadLine();
            while (!int.TryParse(input, out integerNumber))
            {
                Console.WriteLine($"{Constants.WarningEmoji} Invalid input. Please enter a valid number:");
                input = Console.ReadLine();
            }
            return integerNumber;
        }
    }
}
