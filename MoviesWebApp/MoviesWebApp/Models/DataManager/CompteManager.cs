using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviesWebApp.Models.EntityFramework;
using MoviesWebApp.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesWebApp.Models.DataManager
{
    public class CompteManager : IDataRepository<Compte>
    {
        readonly FilmsDBContext _filmsDBContext;
        public CompteManager(FilmsDBContext context)
        {
            _filmsDBContext = context;
        }
        public async Task<ActionResult<IEnumerable<Compte>>> GetAll()
        {
            return await _filmsDBContext.Compte.ToListAsync();
        }
        public async Task<ActionResult<Compte>> GetById(int id)
        {
            return await _filmsDBContext.Compte.FirstOrDefaultAsync(e => e.CompteId == id);
        }
        public async Task<ActionResult<Compte>> GetByString(string mail)
        {
            return await _filmsDBContext.Compte.FirstOrDefaultAsync(e => e.Mel.ToUpper() == mail.ToUpper());
        }
        public async Task Add(Compte entity)
        {
            await _filmsDBContext.Compte.AddAsync(entity);
            await _filmsDBContext.SaveChangesAsync();
        }
        public async Task Update(Compte compte, Compte entity)
        {
            _filmsDBContext.Entry(compte).State = EntityState.Modified;
            compte.CompteId = entity.CompteId;
            compte.Nom = entity.Nom;
            compte.Prenom = entity.Prenom;
            compte.Mel = entity.Mel;
            compte.Rue = entity.Rue;
            compte.CP = entity.CP;
            compte.Ville = entity.Ville;
            compte.Pays = entity.Pays;
            compte.Latitude = entity.Latitude;
            compte.Longitude = entity.Longitude;
            compte.Pwd = entity.Pwd;
            compte.TelPortable = entity.TelPortable;
            compte.FavorisCompte = entity.FavorisCompte;
            await _filmsDBContext.SaveChangesAsync();
        }
        public async Task Delete(Compte compte)
        {
            _filmsDBContext.Compte.Remove(compte);
            await _filmsDBContext.SaveChangesAsync();
        }
    }
}
