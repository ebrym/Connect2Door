namespace connect2door.UnitTest.Models
{
    public class ResponseModel<T>
    {

        public T data { get; set; }

        public bool isSuccessful { get; }


        public string message { get; } = "Operation Successful";

        public ResponseModel(T Data, bool IsSuccessful = true, string Message = "Operation Successful")
        {
            data = Data;
            isSuccessful = IsSuccessful;
            message = Message;
        }

    }
    public static class ResponseExtention
    {
        public static ResponseModel<object> ToResponse(this object data, bool succeed = true, string message = "Operation Successful")
        {
            return new ResponseModel<object>(data, succeed, message);
        }
    }
}

