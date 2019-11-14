using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Contracts
{
    public interface IMarkingService
    {
        public Marking CreateMarking(Marking marking);
        public bool DeleteMarking(Marking marking);
    }
}
