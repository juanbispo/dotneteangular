using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProEventos.Domain;
using Microsoft.EntityFrameworkCore;
using ProEventos.Persistence.Interfaces;
using ProEventos.Persistence.Context;

namespace ProEventos.Persistence
{
    public class PalestrantePersist : IPalestrantePersist
    {
        private readonly ProEventosContext _context;

        public PalestrantePersist(ProEventosContext context)
        {
            _context = context;
        }
      
        //GET PALESTRANTES
        public async Task<Palestrante[]> GetAllPalestrantesAsync(bool includeEventos = false)
        {
             IQueryable<Palestrante> query = _context.Palestrantes.Include(e => e.RedesSociais);

            if(includeEventos){
                query = query.Include( e=> e.PalestrantesEventos).ThenInclude( p => p.Evento);
            }

            query = query.AsNoTracking().OrderBy(e => e.Id);

            return await query.ToArrayAsync();
        }

        public async Task<Palestrante[]> GetAllPalestrantesByNomeAsync(string nome, bool includeEventos = false)
        {
            IQueryable<Palestrante> query = _context.Palestrantes.Include(e => e.RedesSociais);

            if(includeEventos){
                query = query.Include( e=> e.PalestrantesEventos).ThenInclude( p => p.Evento);
            }

            query = query.AsNoTracking().OrderBy(e => e.Id).Where(p=>p.Nome.ToLower().Contains(nome.ToLower()));

            return await query.ToArrayAsync();
        }


        public async Task<Palestrante> GetPalestranteByIdAsync(int palestranteId, bool includeEventos = false)
        {
            IQueryable<Palestrante> query = _context.Palestrantes.Include(e => e.RedesSociais);

            if(includeEventos){
                query = query.Include( e=> e.PalestrantesEventos).ThenInclude( p => p.Evento);
            }

            query = query.AsNoTracking().OrderBy(e => e.Id).Where(p=>p.Id == palestranteId);

            return await query.FirstOrDefaultAsync();
        }

        
    }
}