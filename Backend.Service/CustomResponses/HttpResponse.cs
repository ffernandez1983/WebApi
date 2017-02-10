using System.Net;

namespace Backend.Service

{
    public class HttpResponse<T> where T:class

    {
        public HttpStatusCode Status { get; set; }
        public T Entity { get; set; }
    }
}