namespace Miscellaneous.OperationResult {
    public interface OperationResult {
        bool IsSuccess { get; }

        string Message { get; }

        ResultTypes ResultType { get; }

        void VerifyOperation();
    }
}