namespace Core.Application.Responses
{
    public class BaseCommandResponse<T>
    {
        public BaseCommandResponse() { }

        public BaseCommandResponse(int id, bool success, string message, T data, List<string> errors)
        {
            Id = id;
            Success = success;
            Message = message;
            Data = data;
            Errors = errors;
        }

        public int Id { get; set; }
        public bool Success { get; set; } = true;
        public string Message { get; set; }
        public T Data { get; set; }
        public List<string> Errors { get; set; }
    }
}
