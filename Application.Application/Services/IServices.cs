
using Application.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Application.Services
{
    public interface IServices<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        //Task<IEnumerable<T>> GetAllActiveAsync();
        Task<T> GetByIdAsync(int id);


        Task<IEnumerable<T>> GetAllWithIncludesAsync(params string[] includes);
        Task<T> GetByIdWithIncludesAsync(int id, params string[] includes);
        Task CreateAsync(T entity);
        Task UpdateAsync(int id, T entity);
        Task DeleteAsync(int id,T entity);

        //public interface IAirportInfo
        //{
        //    Task<List<FlightDto.AirportInfoDto>> GetAllAiportInfoAsync();
        //    Task<FlightDto.AirportInfoDto> GetAiportInfoByIdAsync(int id);
        //    Task<int> CreateAiportInfoAsync(FlightDto.AirportInfoDto Airportinfo);
        //    Task<int> UpdateAiportInfoAsync(int id, FlightDto.AirportInfoDto Airportinfo);
        //    Task<int> DeleteAiportInfoAsync(int id, FlightDto.AirportInfoDto Airportinfo);

        //}
        //public interface IFilgthInfo
        //{
        //    Task<List<FlightDto.FlightInfoDto>> GetAllFltInfoAsync();
        //    Task<Flights.FlightInfo> GetFltInfoByIdAsync(int id);
        //    Task<int> CreateFltInfoAsync(FlightDto.FlightInfoDto finfo);
        //    Task<int> UpdateFltInfoAsync(int id, FlightDto.FlightInfoDto finfo);
        //    Task<int> DeleteFltInfoAsync(int id, FlightDto.FlightInfoDto finfo);

        //}
        //public interface IBooking
        //{
        //    Task<List<FlightDto.BookingDto>> GetAllBookingAsync();
        //    Task<FlightDto.BookingDto> GetBookingBYIdAsync(int id);
        //    Task<int> CreateBookingAsync(FlightDto.BookingDto booking);
        //    Task<int> UpdateBookingAsync(int id, FlightDto.BookingDto booking);
        //    Task<int> DeleteBookingAsync(int id, FlightDto.BookingDto booking);
        //}


    }
}
