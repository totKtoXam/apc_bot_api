using Microsoft.AspNetCore.Mvc;

namespace apc_bot_api.Models.Base
{
    public class Result<TData>
    {
        public Result(int _code, string _nameCode, string _title = "", string _message = "", bool _isError = true)
        {
            this.Code = _code;
            this.NameCode = _nameCode;
            this.Title = _title;
            this.Message = _message;
            this.IsError = _isError;
        }

        public Result(TData _data, int _code, string _nameCode, string _title, string _message = "", bool _isError = true)
        {
            this.Data = _data;
            this.Code = _code;
            this.NameCode = _nameCode;
            this.Title = _title;
            this.Message = _message;
            this.IsError = _isError;
        }

        public Result(TData _data)
        {
            this.Data = _data;
            this.Code = 200;
            this.NameCode = "SUCCESS";
            this.Title = "";
            this.Message = "";
            this.IsError = false;
        }

        public int Code { get; }
        public string NameCode { get; }
        public string Title { get; }
        public string Message { get; }
        public bool IsError { get; }
        public TData Data { get; }
    }
}