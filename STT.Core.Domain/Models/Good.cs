using System;

namespace TRM_STT.Core.Domain.Models
{
    public class Good
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}