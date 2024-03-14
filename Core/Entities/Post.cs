using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public DateTime Published { get; set; }
        public DateTime PostedOn { get; set; }
        public DateTime Modified { get; set; }

        public int CategoryId { get; set; }

        // Navigation property
        public Category Category { get; set; }

        public ICollection<PostTag>? Tags { get; } = new List<PostTag>();
        public ICollection<PostImage> PostImages { get; } = new List<PostImage>();

    }
}
