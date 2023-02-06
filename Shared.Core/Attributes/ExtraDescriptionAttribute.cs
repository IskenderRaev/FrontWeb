using System.ComponentModel;

namespace Shared.Core.Attributes
{
    public class ExtraDescriptionAttribute : DescriptionAttribute
    {
        private string extraInfo;
        public string ExtraInfo
        { get { return extraInfo; } set { extraInfo = value; } }

        public ExtraDescriptionAttribute(string description)
        {
            DescriptionValue = description;
            extraInfo = "";
        }
    }
}