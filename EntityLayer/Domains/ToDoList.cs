using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Domains
{
    public class ToDoList : BaseEntity
    {
        public string? Contect { get; set; }
        public bool? Status { get; set; }
    }
}
