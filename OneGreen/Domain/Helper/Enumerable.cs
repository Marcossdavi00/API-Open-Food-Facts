using System;
using System.ComponentModel;

namespace Domain.Helper
{
    public class Enumerable
    {
        [Flags]
        public enum Status
        {
            [Description("Published")]
            published,
            [Description("Trash")]
            trash,
            [Description("Draft")]
            draft
        }
    }
}
