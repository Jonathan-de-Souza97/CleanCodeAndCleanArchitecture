namespace signup.Application.Responses
{
    public class Response<T> where T : class
    {
        public bool Sucess { get; private set; }
        public string Message { get; private set; }
        public T? Data { get; set; }

        private Response(bool sucess, string message, T? data)
        {
            Sucess= sucess;
            Message = message;
            Data = data;
        }

        public static Response<T> Success(T data, string message = "Done")
        {
            return new Response<T>(true, message, data);
        }

        public static Response<T> Error(string message)
        {
            return new Response<T>(false, message, default);
        }
    }
}
