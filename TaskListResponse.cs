namespace TodoApi.Models.DTO.Entities;

public class TaskListResponse
{
        public IEnumerable<TaskEntity>? Data { get; set; }
        public int Ready { get; set; }
        public int NumberOfElements { get; set; }
        public int NotReady { get; set; }
}