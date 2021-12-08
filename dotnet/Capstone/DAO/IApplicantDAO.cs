using Capstone.Models;
using System.Collections.Generic;

namespace Capstone.DAO
{
    public interface IApplicantDAO
    {
        Applicant AddApplicant(int userId,Applicant itemTOAdd);
        IEnumerable<Applicant> GetAllApplicants(int userId);
    }
}