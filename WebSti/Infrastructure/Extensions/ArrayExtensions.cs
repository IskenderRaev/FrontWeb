using System.Text;

namespace WebSti.Infrastructure.Extensions
{
    public static class ArrayExtensions
    {
        public static string ToArrayString(this string[] arr)
        {
            var sb = new StringBuilder();

            foreach (string item in arr)
                sb.Append(item);

            return sb.ToString();
        }
    }
}