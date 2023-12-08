using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DtoLayer.ToDoListDtos
{
    public class UpdateToDoListDto
    {
        public int Id { get; set; }
        public string? Contect { get; set; }
        public bool? Status { get; set; }
    }
}
