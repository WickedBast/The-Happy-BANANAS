using System;
using System.Collections.Generic;
using System.Text;

namespace HB.Core.Enum
{
    public class Enums
    {
        public enum RecordStatus
        {
            Active = 1,
            InActive = 2,
            Deleted = 3
        }

        public enum Role
        {
            Visitor = 0,
            User = 1,
            Admin = 2
        }
    }
}