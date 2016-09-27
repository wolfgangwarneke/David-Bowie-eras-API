using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Concurrent;

namespace MyFirstAPI.Models
{
    public class DavidBowieEraRepository : IDavidBowieEraRepository
    {
        private static ConcurrentDictionary<string, DavidBowieEra> _davidBowieEras = new ConcurrentDictionary<string, DavidBowieEra>();

        public DavidBowieEraRepository()
        {
            Add(new DavidBowieEra { Name = "Era1" });
            Add(new DavidBowieEra { Name = "Era2" });
        }

        public IEnumerable<DavidBowieEra> GetAll()
        {
            return _davidBowieEras.Values;
        }

        public void Add(DavidBowieEra era)
        {
            era.Key = Guid.NewGuid().ToString();
            _davidBowieEras[era.Key] = era;
        }

        public DavidBowieEra Find(string key)
        {
            DavidBowieEra era;
            _davidBowieEras.TryGetValue(key, out era);
            return era;
        }

        public DavidBowieEra Remove(string key)
        {
            DavidBowieEra era;
            _davidBowieEras.TryRemove(key, out era);
            return era;
        }

        public void Update(DavidBowieEra era)
        {
            _davidBowieEras[era.Key] = era;
        }

    }
}
