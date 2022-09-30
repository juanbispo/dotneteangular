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
    public class EventoPersist : IEventoPersist
    {
        private readonly ProEventosContext _context;

        public EventoPersist(ProEventosContext context)
        {
            _context = context;
        }

       
       //GET EVENTOS

        public async Task<Evento[]> GetAllEventosAsync(bool includePalestrantes = false)
        {
            IQueryable<Evento> query = _context.Eventos.Include(e => e.Lotes).Include(e => e.RedesSociais);

            if(includePalestrantes){
                query = query.Include( e=> e.PalestrantesEventos).ThenInclude( p => p.Palestrante);
            }

            query = query.AsNoTracking().OrderBy(e => e.Id);

            return await query.ToArrayAsync();
        }

        public async Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool includePalestrantes = false)
        {
            IQueryable<Evento> query = _context.Eventos.Include(e => e.Lotes).Include(e => e.RedesSociais);

            if(includePalestrantes){
                query = query.Include( e=> e.PalestrantesEventos).ThenInclude( p => p.Palestrante);
            }

            query = query.AsNoTracking().OrderBy(e => e.Id).Where(e=>e.Tema.ToLower().Contains(tema.ToLower()));

            return await query.ToArrayAsync();
        }

        public async Task<Evento> GetEventoByIdAsync(int eventoId, bool includePalestrantes = false)
        {
            IQueryable<Evento> query = _context.Eventos.Include(e => e.Lotes).Include(e => e.RedesSociais);

            if(includePalestrantes){
                query = query.Include( e=> e.PalestrantesEventos).ThenInclude( p => p.Palestrante);
            }

            query = query.AsNoTracking().OrderBy(e => e.Id).Where(e=>e.Id == eventoId);

            return await query.FirstOrDefaultAsync();
        }
        
        
    }
}