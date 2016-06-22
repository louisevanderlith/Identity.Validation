using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Identity.Validation.Interfaces;

namespace Identity.Validation.Country
{
    public class SouthAfricanID : IIdentification
    {
        private int[] splitNumbers;

        public SouthAfricanID(string idNumber)
        {
            if (string.IsNullOrWhiteSpace(idNumber))
                throw new ArgumentNullException("ID Number");

            if (idNumber.Length != 13)
                throw new ArgumentException("ID Number is not 13 characters long.");

            if (!Regex.IsMatch(idNumber, "^[0-9]*$"))
                throw new ArgumentException("ID Number should only contain numbers.");

            RawNumber = idNumber;
            SplitString();
            PopulateValues();
        }

        private void PopulateValues()
        {
            ControlDigit = CalculateControlDigit();
            IsValid = ControlDigit != -1;

            if (IsValid)
            {
                DateOfBirth = GetDateOfBirth();
                Gender = GetGender();
            }
        }

        private DateTime GetDateOfBirth()
        {
            var yearPart = RawNumber.Substring(0, 2);
            var rawYear = CultureInfo.CurrentCulture.Calendar.ToFourDigitYear(int.Parse(yearPart));
            var rawMonth = int.Parse(RawNumber.Substring(2, 2));
            var rawDay = int.Parse(RawNumber.Substring(4, 2));

            return new DateTime(rawYear, rawMonth, rawDay);
        }

        private Gender GetGender()
        {
            var genderPart = splitNumbers[6];

            return genderPart >= 5 ? Gender.Male : Gender.Female;
        }

        private int CalculateControlDigit()
        {
            var result = -1;

            var oddValue = GetOddDigitValue();
            var subControl = 0;

            while (oddValue > 0)
            {
                subControl += oddValue % 10;
                oddValue = oddValue / 10;
            };

            subControl += GetEvenDigitSum();
            result = 10 - (subControl % 10);

            if (result == 10)
                result = 0;

            return result;
        }

        private int GetEvenDigitSum()
        {
            var total = 0;

            for (var i = 0; i < 6; i++)
            {
                total += splitNumbers[2 * i];
            }

            return total;
        }

        private int GetOddDigitValue()
        {
            var total = 0;

            for (var i = 0; i < 6; i++)
            {
                total = total * 10 + splitNumbers[2 * (i + 1)];
            }

            return total *= 2;
        }

        private void SplitString()
        {
            splitNumbers = RawNumber.Select(a => int.Parse(a.ToString())).ToArray();
        }

        public Citizenship Citizenship { get; private set; }

        public DateTime DateOfBirth { get; private set; }

        public Gender Gender { get; private set; }

        public bool IsValid { get; private set; }

        public string RawNumber { get; private set; }

        public int ControlDigit { get; private set; }
    }
}
