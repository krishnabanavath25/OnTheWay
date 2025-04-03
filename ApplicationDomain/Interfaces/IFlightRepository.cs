using Application.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Application.Domain.Interfaces
{
    public interface IFlightRepository<T> where T : class
    {
        
        Task<IEnumerable<T>> GetAllAsync();
        //Task<IEnumerable<T>> GetAllActiveAsync();

        Task<IEnumerable<T>> GetAllWithIncludesAsync(params string[] includes);
        Task<T> GetByIdWithIncludesAsync(int id, params string[] includes);
        Task<T> GetByIdAsync(int id);
        Task CreateAsync(T entity);
        Task UpdateAsync( T entity);
        Task DeleteAsync( T entity );

        //public interface IAirportInfo
        //{
        //    Task<List<Flights.AirportInfo>> GetAllAiportInfoAsync();
        //    Task<Flights.AirportInfo> GetAiportInfoByIdAsync(int id);
        //    Task<int> CreateAiportInfoAsync(Flights.AirportInfo Airportinfo);
        //    Task<int> UpdateAiportInfoAsync(int id, Flights.AirportInfo Airportinfo);
        //    Task<int> DeleteAiportInfoAsync(int id, Flights.AirportInfo Airportinfo);

        //}
        //public interface IFilgthInfo
        //{
        //    Task<List<Flights.FlightInfo>> GetAllFltInfoAsync();
        //    Task<Flights.FlightInfo> GetFltInfoByIdAsync(int id);
        //    Task<int> CreateFltInfoAsync(Flights.FlightInfo finfo);
        //    Task<int> UpdateFltInfoAsync(int id, Flights.FlightInfo finfo);
        //    Task<int> DeleteFltInfoAsync(int id, Flights.FlightInfo finfo);

        //}
        //public interface IBooking
        //{
        //    Task<List<Flights.Booking>> GetAllBookingAsync();
        //    Task<Flights.Booking> GetBookingBYIdAsync(int id);
        //    Task<int> CreateBookingAsync(Flights.Booking booking);
        //    Task<int> UpdateBookingAsync(int id,Flights.Booking booking);
        //    Task<int> DeleteBookingAsync(int id, Flights.Booking booking);
        //}





    }
}
