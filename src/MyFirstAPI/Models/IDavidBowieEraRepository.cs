using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFirstAPI.Models
{
    public interface IDavidBowieEraRepository
    {
        void Add(DavidBowieEra era);
        IEnumerable<DavidBowieEra> GetAll();
        DavidBowieEra Find(string key);
        DavidBowieEra Remove(string key);
        void Update(DavidBowieEra era);
    }
}
