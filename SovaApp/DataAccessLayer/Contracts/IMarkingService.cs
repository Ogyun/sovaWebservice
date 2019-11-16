using System;
using System.Collections.Generic;
using System.Text;
using DataAccessLayer.Models;

namespace DataAccessLayer.Contracts
{
    public interface IMarkingService
    {
        Marking CreateMarking(Marking marking);
        bool DeleteMarking(Marking marking);
        int NumberOfMarkingsPerUser(string userEmail);
    }
}
