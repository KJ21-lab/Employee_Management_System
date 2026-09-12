namespace Miscellaneous.OperationResult {
    public class GlobalOperationResult : OperationResult {

        public GlobalOperationResult(string message) {
            IsSuccess = false;
            Message = message;

        }
        public GlobalOperationResult() {
            IsSuccess = true;
        }

        public bool IsSuccess { get; }

        public string Message { get; } = string.Empty;

        public void VerifyOperation() {
            if (!IsSuccess)
                throw new InvalidOperationException(Message);
        }

    }
}
