using System.Text;

namespace Converting
{
    public class Binary
    {
        
        public string Convert(string input)
        {
            StringBuilder BinaryBuilder = new StringBuilder();
            foreach (char c in input.ToCharArray())
                BinaryBuilder.Append(System.Convert.ToString(c, 2).PadLeft(8, '0'));
            return BinaryBuilder.ToString();
        }
    }
}