using ENAapp.Models;
using ENAapp.Repositories;
using ENAapp.utils;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ENAapp.Models.Repositories.Implementations
{
    public class CompteRepository : ICompteRepository
    {
        private readonly bd_entContext _context;

        public Compte this[int id] => _context.Compte.First(c => c.Id == id);

        public CompteRepository(bd_entContext context)
        {
            _context = context;
        }

        public  Compte Find(string matricule)
        {
            return _context.Compte.First(c => c.Matricule == matricule);
        }

        public bool FindByEmail(string email)
        {
            return _context.Compte.Any(e => e.Email == email);
        }

        public bool FindByMatricule(string matricule)
        {
            return _context.Compte.Any(e => e.Matricule == matricule);
        }

        public bool FindEtudiant(string matricule)
        {
            return _context.Etudiant.Any(e => e.Matricule == matricule);
        }

        public Compte UpdateAsync(Compte compte)
        {
            try
            {

                Compte c = _context.Update(compte).Entity;
                _context.SaveChangesAsync();

                return c;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (CompteExists(compte.Id))
                {
                    throw;

                }
            }
            return null;
        }

        public bool CompteExists(int id)
        {
            return _context.Compte.Any(e => e.Id == id);
        }

        public async Task<Compte> SaveAysnc(Compte compte)
        {
            _context.Add(compte);
            await _context.SaveChangesAsync();

            return _context.Compte.First(c => c.Matricule == compte.Matricule);
        }
        //add
        public bool ConfirmEmailAsync(Compte compte, string code)
        {
            if (compte.ConfirmationToken != code)
            {
                return false;
            }

            compte = this[compte.Id];

            compte.ConfirmationToken = "";
            compte.ConfirmatAt = DateTime.Now;

            _context.Update(compte);
            _context.SaveChanges();

            return true;
        }

        public Compte FindByEmailAsync(string email)
        {
            if (!FindByEmail(email)) return null;

            return _context.Compte.First(c => c.Email == email);
        }

        public Compte FindByMatriculeAsync(string matricule)
        {
            if (!FindByMatricule(matricule)) return null;

            return _context.Compte.First(c => c.Matricule == matricule);
        }

        public bool ConfirmateForgotPasswordAsync(Compte user, string token)
        {
            if (user.ResetToken != token)
            {
                return false;
            }

            user = this[user.Id];

            user.ResetToken = "";
            user.ResetAt = DateTime.Now;

            _context.Update(user);
            _context.SaveChanges();

            return true;
        }

        public Compte Add(Compte obj)
        {
            Compte compte = _context.Compte.Add(obj).Entity;
            _context.SaveChanges();
            return compte;
        }

        public IEnumerable<Compte> AllUserConnected()
        {
            return _context.Compte.ToList().Where(c => c.Status == 1);
        }

        public IEnumerable<Compte> ListCompte()
        {
            return _context.Compte.ToArray();
        }
    }
}
