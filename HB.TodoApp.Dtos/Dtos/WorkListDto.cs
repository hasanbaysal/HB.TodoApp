using HB.TodoApp.Dtos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HB.TodoApp.Dtos.Dtos
{
    public class WorkListDto : IDto
    {
        public int Id { get; set; }
        public string Defination { get; set; }
        public bool IsCompleted { get; set; }
    }
}
