using Capstone.Models;
using System.Collections.Generic;

namespace Capstone.DAO
{
    public interface IApplicantDAO
    {
        int AcceptApplication(Applicant acceptedApplication);
        Applicant AddApplicant(int userId,Applicant itemTOAdd);
        int DenyApplication(Applicant deniedApplication);
        IEnumerable<Applicant> GetAllApplicants(int userId);
        IEnumerable<Applicant> OwnerGetAllApplicants(int userId);
    }
}