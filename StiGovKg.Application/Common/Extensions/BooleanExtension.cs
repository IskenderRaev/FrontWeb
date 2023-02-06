namespace StiGovKg.Application.Common.Extensions
{
    public static class BooleanExtension
    {
        public static string ToRuLocalString(this bool value) => value ? "Да" : "Нет";
    }
}