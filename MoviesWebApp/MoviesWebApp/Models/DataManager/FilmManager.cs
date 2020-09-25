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
    public class FilmManager : IDataRepository<Film>
    {
        readonly FilmsDBContext _filmsDBContext;
        public FilmManager(FilmsDBContext context)
        {
            _filmsDBContext = context;
        }
        public async Task<ActionResult<IEnumerable<Film>>> GetAll()
        {
            return await _filmsDBContext.Film.ToListAsync();
        }
        public async Task<ActionResult<Film>> GetById(int id)
        {
            return await _filmsDBContext.Film.FirstOrDefaultAsync(f => f.FilmId == id);
        }
        public async Task<ActionResult<Film>> GetByString(string titre)
        {
            return await _filmsDBContext.Film.FirstOrDefaultAsync(f => f.Titre == titre);
        }
        public async Task Add(Film entity)
        {
            await _filmsDBContext.Film.AddAsync(entity);
            await _filmsDBContext.SaveChangesAsync();
        }
        public async Task Update(Film film, Film entity)
        {
            _filmsDBContext.Entry(film).State = EntityState.Modified;
            film.FilmId = entity.FilmId;
            film.Titre = entity.Titre;
            film.Synopsis = entity.Synopsis;
            film.DateParution = entity.DateParution;
            film.Duree = entity.Duree;
            film.Genre = entity.Genre;
            film.UrlPhoto = entity.UrlPhoto;
            await _filmsDBContext.SaveChangesAsync();
        }
        public async Task Delete(Film film)
        {
            _filmsDBContext.Film.Remove(film);
            await _filmsDBContext.SaveChangesAsync();
        }
    }
}
