using System;

namespace StiGovKg.Domain.Common
{
    /// <summary>Общий базовый класс</summary>
    public abstract class BaseEntity
    {
        /// <summary>PK</summary>
        public Guid Id { get; set; }
    }
}