using Humanizer;
using System;
using System.Globalization;

namespace WebSti.Infrastructure.Extensions
{
    public static class HumanizeExtension
    {
        public static string HumanizeRu(this DateTimeOffset dateTimeOffset)
        {
            return dateTimeOffset.Humanize(culture: CultureInfo.GetCultureInfo("ru-Ru"));
        }
        public static string HumanizeRu(this DateTime dateTimeOffset)
        {
            return dateTimeOffset.Humanize(culture: CultureInfo.GetCultureInfo("ru-Ru"));
        }
    }
}
