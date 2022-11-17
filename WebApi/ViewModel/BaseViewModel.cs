namespace WebApi.ViewModel
{
    public class BaseRequest
    {
    }

    public class BaseResponse
    {
        public string? Message { get; set; }
        public bool Success { get; set; }
    }

    public class BaseItemResponse<T> : BaseResponse
    {
        public T? Item { get; set; }
    }

    public class BaseListResponse<T> : BaseResponse
    {
        public List<T>? Items { get; set; }
    }
}
