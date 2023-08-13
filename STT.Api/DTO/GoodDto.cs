using System;

namespace TRM_STT.Api.DTO
{
    public class GoodDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}