using HB.TodoApp.Dtos.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace HB.TodoApp.Dtos.Dtos
{
    public class WorkCreateDto :IDto
    { 
      
        public string Defination { get; set; }
        public bool IsCompleted { get; set; }
    }
}