using System.Net;

namespace Domain.Wrapper;

public class PagedResponse<T> : Response<T>
{

    public int PageNumber { get; set; } // 2
    public int PageSize { get; set; } // 12
    public int TotalPages { get; set; } // 30
    public int TotalRecords { get; set; } // 350
    
    public PagedResponse(T data,int totalRecords,int pageSize, int pageNumber) : base(data)
    {
        TotalRecords = totalRecords;
        PageNumber = pageNumber;
        PageSize = pageSize;
        TotalPages = (int)Math.Ceiling(totalRecords / (double)pageSize);
    }

    public PagedResponse(HttpStatusCode statusCode, List<string> errors) : base(statusCode, errors)
    {
    }

    public PagedResponse(HttpStatusCode statusCode, string errors) : base(statusCode, errors)
    {
    }
}