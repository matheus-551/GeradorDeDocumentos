using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdGeneratorBr.Services
{
    public class GeneratorService
    {
        public string GenerateCpf()
        {
            Random rnd = new Random();
            int firstDigit;
            int lastDigit;

            var cpf = rnd.Next(100000000, 999999999).ToString();
            List<int> cpfMembers = cpf.Select(digit => int.Parse(digit.ToString())).ToList();
            firstDigit = GenerateVerifyDigitsCpf(cpfMembers, 10);

            cpfMembers.Add(firstDigit);

            lastDigit = GenerateVerifyDigitsCpf(cpfMembers, 11);

            return cpf + firstDigit + lastDigit;
        }
    
        private int GenerateVerifyDigitsCpf(List<int> cpfMembers, int mulplier)
        {
            int sum = 0;
            int division;
            int rest;

            foreach (int position in cpfMembers)
            {
                sum += (position * mulplier);

                mulplier--;
            }

            division = sum / 11;
            rest = sum - (11 * division);

            switch (rest)
            {
                case 2:
                case 3:
                case 4:
                case 5:
                case 6:
                case 7:
                case 8:
                case 9:
                case 10:
                    return 11 - rest;
                default:
                    return 0;
            }
        }
    }
}
