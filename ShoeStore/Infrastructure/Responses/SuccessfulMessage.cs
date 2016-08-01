namespace ShoeStore.Infrastructure
{
    public class SuccessfulMessage<T>
    {
        public bool Success { get { return true; } }
        public T Data { get; set; }
    }
}
