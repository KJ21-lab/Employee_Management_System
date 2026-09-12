namespace Miscellaneous.OperationResult {
    public interface OperationResult {
        bool IsSuccess { get; }

        string Message { get; }

        void VerifyOperation();
    }
}