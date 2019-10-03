using CLeanArch.Domain.Core.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace CLeanArch.Domain.Core.Commands
{
    public abstract class Command:Message
    {
        public DateTime Timestamp { get; set; }

        protected Command()
        {
            Timestamp = DateTime.Now;
        }

    }
}
