namespace MLAPI.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class BaseEntity
    {
        [Key]
        public long? Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}