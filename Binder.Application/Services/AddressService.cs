using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Binder.Application.Entities;
using Binder.Application.Entities.DbEntities;
using Binder.Application.Repositories;
using Binder.Application.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
namespace Binder.Application.Services
{
    public class AddressService : IAdressService
    {
        private readonly IRepository<CountryDbEntity> _countryRepository;
        private readonly IRepository<CitiesDbEntity> _citiesRepository;
        private readonly IRepository<StatesDbEntity> _stateRepository;
        public AddressService(IRepository<CountryDbEntity> countryRepository, IRepository<CitiesDbEntity> citiesRepository, IRepository<StatesDbEntity> stateRepository)
        {
            _countryRepository = countryRepository;
            _citiesRepository = citiesRepository;
            _stateRepository = stateRepository;
        }
        public IEnumerable<Country> GetCountries()
        {
            return _countryRepository.GetAll().Select(countryDb => Build(countryDb));//tüm country getir.
        }
        public IEnumerable<State> GetStates(int CountryId)
        {
         return   _stateRepository.GetAll().Include(x=>x.Country).Where(x => x.Id == CountryId).Select(x=>Build(x));
        }

        public IEnumerable<City> GetCities(int stateId)
        {
         return  _citiesRepository.GetAll().Include(x=>x.State).
             Include(x=>x.State.Country)
             .Where(x => x.State.Id == stateId).Select(citiesDb => Build(citiesDb));
        }
        public static State Build(StatesDbEntity statesDb)
        {
            return new State
            {
                Id = statesDb.Id,
                Name = statesDb.Name,
                Country = Build(statesDb.Country)
            };
        }
        #region SexyMethod
        public IEnumerable<Country> AddCountries(IQueryable<CountryDbEntity> countryDbEntity)
        {
            foreach (var countryDb in countryDbEntity)
            {
                yield return Build(countryDb);
            }
        }
        #endregion
        public static Country Build(CountryDbEntity countryDb)
        {
            return new Country
            {
                Name = countryDb.Name,
                Id = countryDb.Id,
                SortName = countryDb.SortName,
                PhoneCode = countryDb.PhoneCode
            };
        }

        public static City Build(CitiesDbEntity citiesDb)
        {
            return new City()
            {
                Name = citiesDb.Name,
                Id = citiesDb.Id,
                State = Build(citiesDb.State)
            };
        }
    }
}
