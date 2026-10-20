using Persistence.Tasks.Interfaces;

namespace Persistence.Tasks.Implementations {
   public class TaskRecord : ITaskRecord {


      public TaskRecord(TaskRecord_DBModel dbModel) {
         TaskUID        = dbModel.TASK_UID;
         TaskID         = dbModel.TASK_ID;
         TaskDecription = dbModel.TASK_Description;
         TaskIssueDate  = dbModel.TASK_IssueDate;
         TaskDueDate    = dbModel.TASK_DueDate;
         ProjectID      = dbModel.PROJECT_ID;
      }

      public Guid     TaskUID        { get; set; }
      public int      TaskID         { get; set; }
      public string?  TaskDecription { get; set; }
      public DateTime TaskIssueDate  { get; set; }
      public DateTime TaskDueDate    { get; set; }
      public string?  ProjectID      { get; set; }
   }

   public class TaskRecord_DBModel {

      public TaskRecord_DBModel() { }

      public Guid TASK_UID            { get; set; }
      public int TASK_ID              { get; set; }
      public string? TASK_Description { get; set; }
      public DateTime TASK_IssueDate  { get; set; }
      public DateTime TASK_DueDate    { get; set; }
      public string? PROJECT_ID       { get; set; }
   }
}
