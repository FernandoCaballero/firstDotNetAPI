using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstApi.Helpers
{
    public class CommentQueryObject
    {
        public string Symbol { get; set; } = "";
        public bool IsDecending { get; set; } = true;
    }
}