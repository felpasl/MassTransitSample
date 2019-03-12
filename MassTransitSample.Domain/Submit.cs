using System;
using System.Collections.Generic;
using System.Text;

namespace MassTransitSample.Domain
{
    public class Submit
    {
        public Guid Id { get; set; }
        public string Message { get; set; }

        public Submit()
        {
            this.Id = Guid.NewGuid();
        }
    }
}
