using System;
using System.Collections.Generic;
using System.Text;
using Binder.Application.Entities;

namespace Binder.Application.Services.Interfaces
{
    public interface IAdressService
    {
        public IEnumerable<Country> GetCountries();
        public IEnumerable<State> GetStates(int id);
        public IEnumerable<City> GetCities(int stateId);
    }
}
