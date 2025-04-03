
using Application.Domain.Entities;
using Application.Domain.Interfaces;
using AutoMapper;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Application.Application.Services
{
    public class Services<T> : IServices<T> where T : class
    {
        private readonly IFlightRepository<T> _repository;

        public Services(IFlightRepository<T> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<T>> GetAllAsync() => await _repository.GetAllAsync();
        //public async Task<IEnumerable<T>> GetAllActiveAsync() => await _repository.GetAllActiveAsync();

        public async Task<T> GetByIdAsync(int id) => await _repository.GetByIdAsync(id);

        public async Task<IEnumerable<T>> GetAllWithIncludesAsync(params string[] includes)
        {
            return await _repository.GetAllWithIncludesAsync(includes);
        }

        public async Task<T> GetByIdWithIncludesAsync(int id, params string[] includes)
        {
            return await _repository.GetByIdWithIncludesAsync(id, includes);
        }




        public async Task CreateAsync(T entity) => await _repository.CreateAsync(entity);

        public async Task UpdateAsync(int id, T entity) => await _repository.UpdateAsync(entity);
        public async Task DeleteAsync(int id, T entity) => await _repository.DeleteAsync(entity);


        //public async Task DeleteAsync(int id)
        //{
        //    //await _repository.UpdateAsync(entity);
        //    var entity = await _repository.GetByIdAsync(id);
        //    if (entity != null)
        //    {
        //        await _repository.DeleteAsync(entity);
        //    }
        //}
        //public async Task<IEnumerable<T>> GetAllAsync()
        //{
        //    return await _repository.GetAllAsync();
        //}

        //public async Task<T> GetByIdAsync(int id)
        //{
        //    return await _repository.GetByIdAsync(id);
        //}

        //public async Task CreateAsync(T entity)
        //{
        //    return await _repository.CreateAsync(entity);
        //}

        //public async Task UpdateAsync( T entity)
        //{
        //    return await _repository.UpdateAsync( entity);
        //}

        //public async Task DeleteAsync(int id)
        //{
        //    return await _repository.DeleteAsync(id);
        //}
    }
    //private readonly IFilgthInfo _flgthInfo;
    //private readonly IAirportInfo _airportInfo;
    //private readonly IBooking _booking;
    //private readonly IMapper _mapper;
    //public FlightServices(IFilgthInfo filgthInfo, IAirportInfo airportInfo,IBooking booking,IMapper mapper)
    //{
    //    _flgthInfo = filgthInfo;
    //    _airportInfo = airportInfo;
    //    _booking = booking;
    //    _mapper = mapper;

    //}
    //flightInfo
    // public async Task<List<FlightDto.FlightInfoDto>> GetAllFltInfoAsync()
    // {
    //        var fltlist= await _flgthInfo.GetAllFltInfoAsync();
    //    return _mapper.Map<List<FlightDto.FlightInfoDto>>(fltlist);

    //}
    //public async Task<FlightDto.FlightInfoDto> GetFltInfoByIdAsync(int id)
    //{
    //    var fltById= await _flgthInfo.GetFltInfoByIdAsync(id);
    //    return _mapper.Map<FlightDto.FlightInfoDto>(fltById);
    //}
    //public async Task<int> CreateFltInfoAsync(FlightDto.FlightInfoDto finfo)
    //{
    //    var addfinfo=_mapper.Map<FlightInfo.FlightInfo>(finfo);
    //   return await _flgthInfo.CreateFltInfoAsync(addfinfo);
    //}
    //public async Task<int> UpdateFltInfoAsync(int id,FlightInfo.FlightInfo finfo)
    //{
    //    var fltinfo = await _flgthInfo.GetFltInfoByIdAsync(id);
    //    if(fltinfo == null)
    //    {
    //        throw new KeyNotFoundException($"FlightInfo with Id {id} not found");
    //    }
    //     _mapper.Map(fltinfo,finfo);
    //    return await _flgthInfo.UpdateFltInfoAsync(id, fltinfo);
    //}

    //public async Task<int> DeleteFlightinfoAsync(int id, FlightInfo.FlightInfo finfo)
    //{
    //    var flighhtinfo = await _flgthInfo.GetFltInfoByIdAsync(id);
    //    if (flighhtinfo == null)
    //    {
    //        throw new KeyNotFoundException($"Booking details with Id {id} not found");
    //    }
    //    _mapper.Map(flighhtinfo, finfo);
    //    return await _flgthInfo.DeleteFltInfoAsync(id, flighhtinfo);
    //}



    ////airportInfo
    //public async Task<List<FlightDto.AirportInfoDto>> GetAllAiportInfoAsync()
    //{
    //    var AirportList=await _airportInfo.GetAllAiportInfoAsync();
    //    return _mapper.Map<List<FlightDto.AirportInfoDto>>(AirportList);
    //}
    //public async Task<FlightDto.AirportInfoDto> GetAiportInfoByIdAsync(int id)
    //{
    //    var airpotById = await _airportInfo.GetAiportInfoByIdAsync(id);
    //    return  _mapper.Map<FlightDto.AirportInfoDto>(airpotById);
    //}
    //public async Task<int> CreateAiportInfoAsync(FlightInfo.AirportInfo airinfo)
    //{
    //    var addairinfo=_mapper.Map<FlightInfo.AirportInfo>(airinfo);
    //    return await _airportInfo.CreateAiportInfoAsync(addairinfo);
    //}
    //public async Task<int> UpdateAiportInfoAsync(int id, FlightInfo.AirportInfo airinfo)
    //{
    //    var AirInfo = await _airportInfo.GetAiportInfoByIdAsync(id);
    //    if (AirInfo == null)
    //    {
    //        throw new KeyNotFoundException($"AirportInfo with Id {id} not found");
    //    }
    //   _mapper.Map(AirInfo,airinfo);
    //    return await _airportInfo.UpdateAiportInfoAsync(id, AirInfo);
    //}

    //public async Task<int> DeleteAirportAsync(int id, FlightInfo.AirportInfo airinfo)
    //{
    //    var airport = await _airportInfo.GetAiportInfoByIdAsync(id);
    //    if (airport == null)
    //    {
    //        throw new KeyNotFoundException($"Booking details with Id {id} not found");
    //    }
    //    _mapper.Map(airport, airinfo);
    //    return await _airportInfo.DeleteAiportInfoAsync(id, airport);
    //}

    ////booking details
    //public async Task<List<FlightDto.BookingDto>> GetAllBookingAsync()
    //{
    //    var bookingList= await _booking.GetAllBookingAsync();
    //    return _mapper.Map<List<FlightDto.BookingDto>>(bookingList);
    //}
    //public async Task<FlightDto.BookingDto> GetBookingBYIdAsync(int id)
    //{
    //    var bookingById = await _booking.GetBookingBYIdAsync(id);
    //    return _mapper.Map<FlightDto.BookingDto>(bookingById);
    //}
    //public async Task<int> CreateBookingAsync(FlightInfo.Booking booking)
    //{
    //    var addbooking = _mapper.Map<FlightInfo.Booking>(booking);
    //    return await _booking.CreateBookingAsync(addbooking);
    //}
    //public async Task<int> UpdateBookingAsync(int id,FlightInfo.Booking booking)
    //{
    //    var Booking = await _booking.GetBookingBYIdAsync(id);
    //    if(Booking == null)
    //    {
    //        throw new KeyNotFoundException($"Booking details with Id {id} not found");
    //    }
    //     _mapper.Map(Booking,booking);
    //    return await _booking.UpdateBookingAsync(id, Booking);
    //}
    //public async Task<int> DeleteBookingAsync(int id,FlightInfo.Booking booking)
    //{
    //    var Booking =await _booking.GetBookingBYIdAsync(id);
    //    if (Booking == null)
    //    {
    //        throw new KeyNotFoundException($"Booking details with Id {id} not found");
    //    }
    //    _mapper.Map(Booking, booking);
    //    return await _booking.DeleteBookingAsync(id, Booking);
    //}

}

