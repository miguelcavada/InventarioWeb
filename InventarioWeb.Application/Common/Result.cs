namespace InventarioWeb.Application.Common;

public class Result
{
    public bool IsSuccess { get; set; }
    public bool IsFailure => !IsSuccess;
    public string? ErrorMessage { get; set; }
    public string? SuccessMessage { get; set; }

    public static Result Success(string? message = null)
    {
        return new Result { IsSuccess = true, SuccessMessage = message };
    }

    public static Result Failure(string errorMessage)
    {
        return new Result { IsSuccess = false, ErrorMessage = errorMessage };
    }
}

public class Result<T>
{
    public bool IsSuccess { get; set; }
    public bool IsFailure => !IsSuccess;
    public T? Data { get; set; }
    public string? ErrorMessage { get; set; }
    public string? SuccessMessage { get; set; }

    public static Result<T> Success(T data, string? message = null)
    {
        return new Result<T> { IsSuccess = true, Data = data, SuccessMessage = message };
    }

    public static Result<T> Failure(string errorMessage)
    {
        return new Result<T> { IsSuccess = false, ErrorMessage = errorMessage };
    }
}