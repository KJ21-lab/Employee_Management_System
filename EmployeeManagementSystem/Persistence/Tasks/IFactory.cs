using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Tasks {

   public interface  ITaskFactory {
   
      Task<IEnumerable<ITaskRecord>> ReadAll();
      Task<IEnumerable<ITaskRecord>> Read(IEnumerable<Guid> taskUIDs);
      Task<ITaskRecord?> Read(Guid taskUID) => 
         Task.Run(() => Read([taskUID]).Result.FirstOrDefault());

   }
   public interface ITaskRecord {
      Guid TaskID { get; }
   }

   public interface ITaskRecordProperty {
      public DateTime TaskDecription { get; set; }
      public DateTime TaskIssueDate  { get; set; }
      public DateTime TaskDueDate    { get; set; }
      public Guid     ProjectID      { get; set; }
   }
}
