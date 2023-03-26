using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public class Comment : IEntity
    {
        public int CommentId { get; set; }
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public string CommentContent { get; set; }
    }
}
