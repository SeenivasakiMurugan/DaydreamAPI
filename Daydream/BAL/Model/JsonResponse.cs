namespace Daydream.BAL.Model
{
    public class JsonResponse
    {
        public int Id { get; set; }

        public string? Status { get; set; }

        public string? Message { get; set; } 

        public object? Data { get; set; }
    }
}
