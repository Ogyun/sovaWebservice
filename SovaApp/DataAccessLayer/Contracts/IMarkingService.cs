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
        List<Marking> GetAllMarkedQuestionsByUserEmail(string userEmail, PagingAttributes pagingAttributes);
        int NumberOfMarkingsPerUser(string userEmail);
    }
}
