﻿using HospitalAPI.Errors;

namespace HospitalAPI.Shared
{
    public class Result
    {
        public Result(bool isSuccess, Error error)
        {
            if (isSuccess && error != Error.None ||
                !isSuccess && error == Error.None)
            {
                throw new ArgumentException("Invalid error", nameof(error));
            }
            IsSuccess = isSuccess;
            Error = error;
        }
        public bool IsSuccess { get; }
        public bool IsFailure => !IsSuccess;
        public Error Error { get; } = default!;
        public static Result Success() => new(true, Error.None);
        public static Result<T> Success<T>(T value) => new Result<T>(value, true, Error.None);
        public static Result Failure(Error error) => new(false, error);
        public static Result<T> Failure<T>(Error error) => new Result<T>(default!, false, error);

    }
    public class Result<T> : Result
    {
        public T Value { get; set; }
        public Result(T value, bool isSuccess, Error error) : base(isSuccess, error)
        {
            Value = value;
        }
    }
}
