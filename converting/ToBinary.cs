using System.Text;

namespace Converting
{
    public class Binary
    {
        
        public string Convert(string input)
        {
            StringBuilder sb = new StringBuilder();
            foreach (char c in input.ToCharArray())
                sb.Append(System.Convert.ToString(c, 2).PadLeft(8, '0'));
            return sb.ToString();
        }
    }
}