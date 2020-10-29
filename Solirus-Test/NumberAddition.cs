using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Solirus
{
    public class NumberAddition
    {
        public static uint AddString(string[] args)
        {
            /*
             
            1. Start with the simplest case of an empty string and move to 1 and 2 numbers. -- DONE
            2. Allow the Add method to handle an unknown amount of numbers. -- DONE
            3. Allow the Add method to handle new lines between numbers (as well as commas).
                a. The following input is ok: “1\n2,3” (will equal 6). -- DONE
                b. The following input is NOT ok: “1,\n”. -- DONE
            4. Support different single character delimiters (case-insensitive).
                a. To change a delimiter, the beginning of the string will contain a separate line that looks like 
                this: “//[delimiter]\n[numbers…]” for example “//;\n1;2” should return three where the delimiter is ‘;’. -- DONE
            5. Calling Add with a negative number will throw an exception “Negatives not allowed” - and the negative that was passed in. 
                If there are multiple negatives, show all of them in the exception message. -- DONE
            6. Numbers greater than 1000 should be ignored, so adding 2 + 1001 + 13 = 15. -- DONE
            7. Allow multiple delimiters like this: “//[delim1][delim2]\n” for example “//*%\n1*2%3” should return 6. -- DONE
            
            

             * */

            uint sum = 0;
            List<uint> numbers = new List<uint>();

           
            StringBuilder negativeNumbersString = new StringBuilder();

            foreach (var item in args)
            {

                if (item.Contains("\n,"))
                    continue;

                // default delimeters
                char[] delimeters = new char[] { '\n',','};
                
                var result = Regex.Match(@item, @"\/\/.*\n").Value;

                // multiple delimeters check
                if (!string.IsNullOrEmpty(result))
                    delimeters = result.Substring(2, result.Length - 3).ToCharArray();

                string[] elements = item.Split(delimeters);

                foreach (var numItem in elements)
                {
                    
                    // check for negative numbers
                    if (isNegativeNumber(numItem))
                    {
                        negativeNumbersString.Append(numItem);
                        continue;
                    }

                    // check for number > 1000
                    if (isNumberGreaterThanThousand(numItem))
                    {
                        continue;
                    }

                    uint numericValue = 0;
                    if (uint.TryParse(numItem, out numericValue))
                    {
                        numbers.Add(numericValue);
                    }
                }
            }
            string negativeNumbers = negativeNumbersString.ToString();
            if (negativeNumbers.Length > 0)
                throw new FormatException("Negatives not allowed - " + negativeNumbers);

            foreach (var finalNumber in numbers)
            {
                sum += finalNumber;
            }

            //Console.WriteLine(sum);
            return sum;
        }

        static bool isNegativeNumber(string numItem)
        {
            int negativeNumber;
            if (int.TryParse(numItem, out negativeNumber) && negativeNumber < 0)
            {
                return true;
            }
            return false;
        }

        static bool isNumberGreaterThanThousand(string numItem)
        {
            int number;
            if (int.TryParse(numItem, out number) && number > 1000)
            {
                return true;
            }
            return false;
        }
    }
}
