using ENAapp.Models;
using ENAapp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ENAapp.Repositories
{
    public interface ICompteRepository
    {
        Task<Compte> SaveAysnc(Compte compte);
        Compte Find(string matricule);
        Compte this[int id] { get; }
        bool FindEtudiant(string matricule);
        Compte UpdateAsync(Compte compte);
        bool FindByMatricule(string matricule);
       
        bool FindByEmail(string matricule);
        //void updateConnect(Compte connect);
        Compte Add(Compte compte);
        bool CompteExists(int id);
        bool ConfirmEmailAsync(Compte compte, string code);
       
        Compte FindByEmailAsync(string email);
        Compte FindByMatriculeAsync(string matricule);
        bool ConfirmateForgotPasswordAsync(Compte user, string token);
        IEnumerable<Compte> ListCompte();
        //notification

        IEnumerable<Compte> AllUserConnected();
    }
}
