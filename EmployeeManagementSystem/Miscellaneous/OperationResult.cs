namespace EmployeeManagementSystem.Server.Miscellaneous.Interfaces {
    public interface OperationResult {
        bool IsSuccess { get; }

        string Message { get; }

        void VerifyOperation();
    }
}