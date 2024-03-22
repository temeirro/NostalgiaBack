using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTOs
{
    public class CategoryCreateDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public IEnumerable<Post> Posts { get; } = new List<Post>();
    }
}
 