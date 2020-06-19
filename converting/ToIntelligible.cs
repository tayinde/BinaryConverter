using System.Text;
using System;
using System.Collections.Generic;

namespace Converting
{
    public class Intelligible
    {
        
        public string Translate(string input)
        {
            var list = new List<byte>();
            if (input.Length < 8) return "Invalid sequence inputted";
            try
            {
                for (int i = 0; i < input.Length; i += 8)
                {
                    list.Add(Convert.ToByte(input.Substring(i, 8), 2));
                }
            }
            catch (Exception)
            {
                return "Invalid sequence inputted";
            }
            return Encoding.ASCII.GetString(list.ToArray());
        }
    }
}