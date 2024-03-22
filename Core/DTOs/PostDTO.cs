using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTOs
{
    public class PostDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public DateTime Published { get; set; }
        public DateTime Modified { get; set; }

        public int CategoryId { get; set; }

        // Navigation property
        public Category Category { get; set; }

        public IEnumerable<Tag> Tags { get; set; } = new List<Tag>();
        public ICollection<PostImage> PostImages { get; } = new List<PostImage>();
        public List<string>? ImagesPath { get; set; }
    }
}
