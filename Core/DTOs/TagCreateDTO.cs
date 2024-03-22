using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTOs
{
    public class TagCreateDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<PostTag>? Posts { get; } = new List<PostTag>();
    }
}
