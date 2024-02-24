using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace ICannotDie.Plugins.Common.Extensions
{
    public static class StringExtensions
    {
        public static string Log(this string value, string action = null, params object[] args)
        {
            if (string.IsNullOrEmpty(value)) return value;

            var formattedString = new StringBuilder();

            formattedString.Append($"{value.SplitOnCapitals().Join(" ")} ");

            if (action != null) formattedString.Append($"{action.SplitOnCapitals(" ").Join(" ")}");

            formattedString.Append(args.Select(arg => arg.ToString().SplitOnCapitals().Join(" ")));

            return formattedString.ToString().Trim();
        }

        public static string WriteLog(this string value, bool debugEnabled = false)
        {
            if (!string.IsNullOrEmpty(value)) Utility.LogForDebug(debugEnabled, value);
            return value;
        }

        public static IEnumerable<string> SplitOnCapitals(this string value, string padEnd = "")
        {
            if (value.IsMixedCase())
            {
                Regex regex = new Regex(@"\p{Lu}\p{Ll}*");
                foreach (Match match in regex.Matches(value))
                {
                    yield return match.Value.Trim() + padEnd;
                }
            }
            else
            {
                yield break;
            }
        }

        public static string Join(this IEnumerable<string> value, string delimiter = "") => string.Join(delimiter, value.ToArray());

        public static bool IsMixedCase(this string value) => value != value.ToLower() && value != value.ToUpper();

    }
}
