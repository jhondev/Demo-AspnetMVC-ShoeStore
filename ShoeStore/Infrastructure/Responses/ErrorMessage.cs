namespace ShoeStore.Infrastructure
{
    public class ErrorMessage
    {
        public bool Success { get { return false; } }
        public int error_code { get; set; }
        public string error_msg { get; set; }
    }
}