using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Tasks.Interfaces {

   public interface  ITaskFactory {
   
      Task<IEnumerable<ITaskRecord>> ReadAll();
      Task<IEnumerable<ITaskRecord>> ReadTaskByUIDs(IEnumerable<Guid> taskUIDs);
      Task<ITaskRecord?> Read(Guid taskUID) => 
         Task.Run(() => ReadTaskByUIDs([taskUID]).Result.FirstOrDefault());

      Task<IEnumerable<ITaskRecord>> Upsert(Guid taskUID) => Task.Run(() => Upsert([taskUID]));
      Task<IEnumerable<ITaskRecord>> Upsert(IEnumerable<Guid> taskUID);
   }
   public interface ITaskRecord {
      Guid TaskUID      { get; }
      public int TaskID { get; }
   }

   public interface ITaskRecordProperty {
      public DateTime TaskDecription { get; set; }
      public DateTime TaskIssueDate  { get; set; }
      public DateTime TaskDueDate    { get; set; }
      public Guid     ProjectID      { get; set; }
   }
}
