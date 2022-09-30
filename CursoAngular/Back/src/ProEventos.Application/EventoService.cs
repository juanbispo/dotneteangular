using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProEventos.Application.Interfaces;
using ProEventos.Persistence.Interfaces;
using ProEventos.Domain;

namespace ProEventos.Application
{
    public class EventoService : IEventoService
    {
        private readonly IGeralPersist _geralPersist;
        private readonly IEventoPersist _eventoPersist;

        public EventoService(IGeralPersist geralPersist, IEventoPersist eventoPersist)
        {
            _geralPersist = geralPersist;
            _eventoPersist = eventoPersist;
        }

        public async Task<Evento> AddEventos(Evento model)
        {
            try{
                _geralPersist.Add<Evento>(model);

                if(await _geralPersist.SaveChangesAsync()){

                    return await _eventoPersist.GetEventoByIdAsync(model.Id, false);
                }
                return null;
            }
            catch(Exception e){

                throw new Exception(e.Message);
            }
        }

        public async Task<Evento> UpdateEvento(int eventoId, Evento model)
        {
            try
            {
                var evento = await _eventoPersist.GetEventoByIdAsync(eventoId,false);
                if (evento == null)
                {
                    return null;
                }

                model.Id = evento.Id;

                _geralPersist.Update(model);

                if(await _geralPersist.SaveChangesAsync()){

                    return await _eventoPersist.GetEventoByIdAsync(model.Id, false);
                }
                return null;
            }
            catch(Exception e){

                throw new Exception(e.Message);
            }
        }

        public async Task<bool> DeleteEvento(int eventoId)
        {
            try
            {
                var evento = await _eventoPersist.GetEventoByIdAsync(eventoId,false);
                if (evento == null)
                {
                    throw new Exception("Evento não encontrado");
                }

                _geralPersist.Delete<Evento>(evento);

                return await _geralPersist.SaveChangesAsync();

            }
            catch(Exception e){

                throw new Exception(e.Message);
            }
        }

        public async Task<Evento[]> GetAllEventosAsync(bool includePalestrantes = false)
        {
            try
            {
                var eventos = await _eventoPersist.GetAllEventosAsync(includePalestrantes);
                if (eventos == null)
                {
                    return null;
                }

                return eventos;
            }
            catch (Exception e)
            {
                
                throw new Exception(e.Message);
            }
        }

        public async Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool includePalestrantes = false)
        {
            try
            {
                var eventos = await _eventoPersist.GetAllEventosByTemaAsync(tema,includePalestrantes);
                if (eventos == null)
                {
                    return null;
                }

                return eventos;
            }
            catch (Exception e)
            {
                
                throw new Exception(e.Message);
            }
        }

        public async Task<Evento> GetEventoByIdAsync(int eventoId, bool includePalestrantes = false)
        {
            try
            {
                var eventos = await _eventoPersist.GetEventoByIdAsync(eventoId,includePalestrantes);
                if (eventos == null)
                {
                    return null;
                }

                return eventos;
            }
            catch (Exception e)
            {
                
                throw new Exception(e.Message);
            }
        }

    }
}