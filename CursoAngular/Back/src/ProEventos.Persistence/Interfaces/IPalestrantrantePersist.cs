using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProEventos.Domain;

namespace ProEventos.Persistence.Interfaces
{
    public interface IPalestrantePersist
    {

        //PALESTRANTES
        Task<Palestrante[]> GetAllPalestrantesByNomeAsync(string nome, bool includeEventos = false);

        Task<Palestrante[]> GetAllPalestrantesAsync( bool includeEventos = false);

        Task<Palestrante> GetPalestranteByIdAsync(int palestranteId, bool includeEventos = false);


    }
}