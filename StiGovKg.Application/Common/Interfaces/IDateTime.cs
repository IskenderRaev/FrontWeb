using System;

namespace StiGovKg.Application.Common.Interfaces
{
    public interface IDateTime
    {
        DateTime Now
        {
            get { return DateTime.Now; }
        }
    }
}