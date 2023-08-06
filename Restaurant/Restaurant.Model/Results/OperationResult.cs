namespace Restaurant.Model
{
    public class OperationResult
    {
        #region properties

        public bool IsSuccess { get; set; }

        public string? Message { get; set; }

        #endregion

        #region ctor
        public OperationResult(bool isSuccess, string? message = null)
        {
            IsSuccess = isSuccess;
            Message = message;
        } 
        #endregion

        #region factory methods

        public static OperationResult Success(string? message = null)
        {
            return new OperationResult(true, message);
        }

        public static OperationResult Error(string message)
        {
            return new OperationResult(false, message);
        }

        #endregion
    }
}
