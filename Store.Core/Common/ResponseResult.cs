namespace Store.Core.Common;

public enum ResponseStatus : byte
{
    Error,
    Success
}

public readonly struct ResponseResult<TValue> : IEquatable<ResponseResult<TValue?>>
{
    internal readonly ResponseStatus Status;
    public readonly TValue? Value { get; }
    public readonly Exception? Exception { get; }


    public bool isError => Status == ResponseStatus.Error;
    public bool isSuccess => Status == ResponseStatus.Success;

    #region Constructors
    public ResponseResult(TValue? value)
    {
        Status = ResponseStatus.Success;
        Value = value;
        Exception = null;
    }

    public ResponseResult(Exception exception)
    {
        Status = ResponseStatus.Error;
        Value = default;
        Exception = new AggregateException(exception);
    }

    public ResponseResult(ICollection<Exception> exceptions)
    {
        Status = ResponseStatus.Error;
        Value = default;
        Exception = new AggregateException(exceptions);
    }
    #endregion

    public override bool Equals(object? obj)
    {
        return obj is ResponseResult<TValue?>;
    }

    public bool Equals(ResponseResult<TValue?> other)
    {
        return (Value?.Equals(other.Value) ?? false);
    }

    public override int GetHashCode() { return base.GetHashCode(); }

    public static bool operator ==(ResponseResult<TValue?> left, ResponseResult<TValue?> right)
    {
        return !(left.Equals(right));
    }

    public static bool operator !=(ResponseResult<TValue?> left, ResponseResult<TValue?> right)
    {
        return !(left == right);
    }
}
