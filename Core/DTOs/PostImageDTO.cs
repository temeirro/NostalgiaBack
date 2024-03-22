using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTOs
{
    public class PostImageDTO
    {
        public int Id { get; set; }
        public string? ImagePath { get; set; }
        public int? PostId { get; set; }
    }
}
