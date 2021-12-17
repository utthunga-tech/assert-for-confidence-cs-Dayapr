using System;
using System.Collections.Generic;
using System.Linq;

namespace StringCalculatorLib
{
    public class StringCalculatorClass
    {
        #region Private Properties

        private List<string> _Delimiters = new List<string> { ",", "\n" };
        private string _BackSlashDelimiter = "//";

        #endregion

        #region Public Methods

        public int Add(string inputParameter)
        {
            if (string.IsNullOrEmpty(inputParameter)) return 0;

            if (inputParameter.StartsWith(_BackSlashDelimiter))
            {
                inputParameter = GetNumberRemoveDelimiters(inputParameter);
            }

            var listOfNumbers = inputParameter.Split(_Delimiters.ToArray(), 0).Select(int.Parse).ToList();
            
            if (CheckNegativeNumber(listOfNumbers))
            {
                throw new Exception("Negative number doesn't support");
            }
            else
            {
                return listOfNumbers.Sum();
            }
        }

        public bool CheckNegativeNumber(List<int> listOfNumbers)
        {
            return listOfNumbers.Any(x => x < 0) ? true : false;
        }

        #endregion

        #region Private Methods

        private string GetNumberRemoveDelimiters(string listOfNumbers)
        {
            var delimiters = GetDelimiters(listOfNumbers);
            _Delimiters.AddRange(delimiters);

            int delimiterLength = delimiters.Count > 1 ? (delimiters.Count * 2) : 0;

            int index = 3 + delimiters.Sum(x => x.Length) + delimiterLength;

            return listOfNumbers.Substring(index);
        }

        private List<string> GetDelimiters(string numbers)
        {
            string delimiterString = numbers.Substring(2, numbers.IndexOf('\n') - 2).Trim();

            return delimiterString.Split('[').Select(x => x.TrimEnd(']').Trim()).ToList();
        }

        #endregion
    }
}
