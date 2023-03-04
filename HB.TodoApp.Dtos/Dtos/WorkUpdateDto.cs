using HB.TodoApp.Dtos.Interfaces;


namespace HB.TodoApp.Dtos.Dtos
{
    public class WorkUpdateDto : IDto
    {
        public int Id { get; set; }

       
        public string Defination { get; set; }
        public bool IsCompleted { get; set; }

    }
}
