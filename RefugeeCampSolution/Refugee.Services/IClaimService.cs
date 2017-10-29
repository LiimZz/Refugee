using Refugee.Domain.Entities;
using Refugee.Pattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refugee.Services
{
    public interface IClaimService : IServices<PostClaims>
    {
        void createClaim(PostClaims p);
        List<PostClaims> getAllClaims();
        void updateClaim(PostClaims p);
        PostClaims getClaimByObject(string Objet);
        PostClaims getClaimByID(int idp,string idu);
        void deleteClaim(int idp, string idu);
    }
}
