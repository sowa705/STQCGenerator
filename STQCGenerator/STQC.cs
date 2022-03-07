using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STQCGenerator
{
    internal class STQC
    {
        public static int[] ParseFormat(string input)
        {
            var splittxt = input.Trim().Split(' ');
            List<int> l = new List<int>();
            foreach (var item in splittxt)
            {
                int o = 0;
                if (int.TryParse(item, out o))
                {
                    l.Add(o);
                }
                else
                {
                    throw new Exception("Format parse error");
                }
            }
            return l.ToArray();
        }

        static string Int32ToString(int value, int toBase)
        {
            string result = string.Empty;
            do
            {
                result = "0123456789ABCDEF"[value % toBase] + result;
                value /= toBase;
            }
            while (value > 0);

            return result;
        }

        public static string GenerateOutput(string inputFormat,string inputString) {
            var split = inputString.Trim().Split(' ');
            int[] format = ParseFormat(inputFormat);

            if (split.Length != format.Length)
            {
                throw new Exception("Input does not follow format!");
            }

            string output = "";

            for (int i = 0; i < format.Length; i++)
            {
                int digitcount = format[i];
                int inputnumber = int.Parse(split[i]);
                string unpadded = Int32ToString(inputnumber, 4);

                while (unpadded.Length < digitcount)
                {
                    unpadded = '0' + unpadded;
                }

                char[] base4 = unpadded.ToCharArray();
                if (base4.Length > digitcount)
                {
                    throw new Exception($"Value over range at group {i+1}");
                }
                char last = '0';
                for (int e = 0; e < base4.Length; e++)
                {
                    if (base4[e] == last)
                    {
                        base4[e] = '4';
                    }
                    last = base4[e];
                }
                output += new string(base4) + " ";
            }
            return output;
        }
    }
}
