using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public class Reply : IEntity
    {
        public int ReplyId { get; set; }
        public int CommentId { get; set; }
        public string ReplyContent { get; set; }
    }
}
