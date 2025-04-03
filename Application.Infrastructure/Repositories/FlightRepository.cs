using Application.Domain.Entities;
using Application.Domain.Interfaces;
using Application.Infrastructure.DataContext;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Infrastructure.Repositories
{
    public class FlightRepository<T> : IFlightRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<T> _dbSet;

        public FlightRepository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }
        
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.Where(entity => EF.Property<bool>(entity, "Status") == true).ToListAsync();
            //return await _dbSet.ToListAsync();
        }
        
        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }


        public async Task<IEnumerable<T>> GetAllWithIncludesAsync(params string[] includes)
        {
            IQueryable<T> query = _dbSet.Where(entity => EF.Property<bool>(entity, "Status") == true);

            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            return await query.ToListAsync();
        }

        public async Task<T> GetByIdWithIncludesAsync(int id, params string[] includes)
        {
            IQueryable<T> query = _dbSet;

            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            return await query.FirstOrDefaultAsync(e => EF.Property<int>(e, "Id") == id);
        }
        public async Task CreateAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync( T entity)
        {
            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        //public async Task<List<T>> GetAllAsync()
        //{
        //    return await _dbSet.ToListAsync();
        //}

        //public async Task<T> GetByIdAsync(int id)
        //{ 
        //        return await _dbSet.FindAsync(id);
        //}

        //public async Task<int> CreateAsync(T entity)
        //{
         
        //    await _dbSet.AddAsync(entity);
        //    return await _context.SaveChangesAsync();
        //}

        //public async Task<int> UpdateAsync(int id, T entity)
        //{
        //    var existingEntity = await _dbSet.FindAsync(id);
        //    if (existingEntity == null)
        //    {
        //        return 0;
        //    }

        //    _context.Entry(existingEntity).CurrentValues.SetValues(entity);
        //    return await _context.SaveChangesAsync();
        //}
      
        //public async Task<int> DeleteAsync(int id,T entity)
        //{
        //    var existingEntity = await _dbSet.FindAsync(id);
        //    if (existingEntity == null)
        //    {
        //        return 0;
        //    }

        //    _context.Entry(existingEntity).CurrentValues.SetValues(entity);
        //    return await _context.SaveChangesAsync();
        //    //var entityval = await _dbSet.FindAsync(id);
        //    //if (entity == null)
        //    //{
        //    //    return 0;
        //    //}

        //    //_dbSet.Remove(entity);
        //    //return await _context.SaveChangesAsync();
        //}
    }


    //public async Task<IEnumerable<T>> GetAllAsync()
    //{
    //    return await _dbSet.ToListAsync();
    //}

    //public async Task<T> GetByIdAsync(int id)
    //{
    //    return await _dbSet.FindAsync(id);
    //}

    //public async Task AddAsync(T entity)
    //{
    //    await _dbSet.AddAsync(entity);
    //    await _context.SaveChangesAsync();
    //}

    //public async Task UpdateAsync(T entity)
    //{
    //    _dbSet.Update(entity);
    //    await _context.SaveChangesAsync();
    //}

    //public async Task DeleteAsync(int id)
    //{
    //    var entity = await _dbSet.FindAsync(id);
    //    if (entity != null)
    //    {
    //        _dbSet.Update(entity);
    //        await _context.SaveChangesAsync();
    //    }

    //}

    //Task<T> IFlightRepository<T>.GetBookingBYIdAsync(int id)
    //{
    //    return  _dbSet.FindAsync(id);
    //}

    //Task<int> IFlightRepository<T>.CreateBookingAsync(T entity)
    //{
    //    throw new NotImplementedException();
    //}

    //Task<int> IFlightRepository<T>.UpdateBookingAsync(int id, T entity)
    //{
    //    throw new NotImplementedException();
    //}

    //Task<int> IFlightRepository<T>.DeleteBookingAsync(int id, T entity)
    //{
    //    throw new NotImplementedException();
    //}


    //private readonly ApplicationDbContext _context;
    //private readonly DbSet<T> _dbSet;
    //public FlightRepository( ApplicationDbContext contex)
    //{
    //    _context = contex;
    //    _dbSet = contex.Set<T>();
    //}
    ////Flight Information
    //public async Task<List<FlightInfo>> GetAllFltInfoAsync()
    //{

    //    return await _context.FlightInfos.Where(e=>e.Status==true).ToListAsync();


    //}
    //public async Task<FlightInfo> GetFltInfoByIdAsync(int id )
    //{

    //    return await _context.FlightInfos.FindAsync(id);
    //}
    //public async Task<int> CreateFltInfoAsync(FlightInfo finfo)
    //{   
    //    finfo.CreatedOn= DateTime.Now;
    //    finfo.Status = true;
    //    if(finfo!=null)
    //    {
    //        await _context.FlightInfos.AddAsync(finfo);
    //        return await _context.SaveChangesAsync();

    //    }
    //    else
    //    {
    //         throw new ArgumentNullException(nameof(finfo), "Invalid data");
    //    }
    //}
    //public async Task<int> UpdateFltInfoAsync(FlightInfo finfo)
    //{
    //    finfo.UpdatedOn= DateTime.Now;
    //    if(finfo!=null)
    //    {
    //         _context.FlightInfos.Update(finfo);
    //        return await _context.SaveChangesAsync();
    //    }
    //    else
    //    {
    //        throw new ArgumentNullException(nameof(finfo), "Invalid data");
    //    }

    //}
    //public async Task<int>DeleteFltInfoAsync(FlightInfo finfo)
    //{
    //    finfo.Status = false;
    //    _context.FlightInfos.Update(finfo);
    //    return await _context.SaveChangesAsync();
    //}

    ////Airport Information

    //public async Task<List<FlightInfo.AirportInfo>> GetAllAiportInfoAsync()
    //{

    //    return await _context.airportInfos.Where(e=>e.Status==true).ToListAsync();


    //}
    //public async Task<FlightInfo.AirportInfo> GetAiportInfoByIdAsync(int id)
    //{

    //    return await _context.airportInfos.FindAsync(id);
    //}
    //public async Task<int> CreateAiportInfoAsync(FlightInfo.AirportInfo airinfo)
    //{
    //    airinfo.CreatedOn = DateTime.Now;
    //    airinfo.Status = true;
    //    if (airinfo != null)
    //    {
    //        await _context.airportInfos.AddAsync(airinfo);
    //        return await _context.SaveChangesAsync();

    //    }
    //    else
    //    {
    //        throw new ArgumentNullException(nameof(airinfo), "Invalid data");
    //    }
    //}
    //public async Task<int> UpdateAiportInfoAsync(FlightInfo.AirportInfo airinfo)
    //{
    //    airinfo.UpdatedOn = DateTime.Now;
    //    if (airinfo != null)
    //    {
    //        _context.airportInfos.Update(airinfo);
    //        return await _context.SaveChangesAsync();
    //    }
    //    else
    //    {
    //        throw new ArgumentNullException(nameof(airinfo), "Invalid data");
    //    }

    //}
    //public async Task<int> DeleteAiportInfoAsync(FlightInfo.AirportInfo airinfo)
    //{
    //    airinfo.Status = false;
    //    _context.airportInfos.Update(airinfo);
    //    return await _context.SaveChangesAsync();
    //}


    ////Booking 
    //public async Task<List<FlightInfo.Booking>> GetAllBookingAsync()
    //{

    //    return await _context.bookings.Where(e => e.Status == true).ToListAsync();


    //}
    //public async Task<FlightInfo.Booking> GetBookingBYIdAsync(int id)
    //{

    //    return await _context.bookings.FindAsync(id);
    //}
    //public async Task<int> CreateBookingAsync(FlightInfo.Booking booking)
    //{
    //    booking.CreatedOn = DateTime.Now;
    //    booking.Status = true;
    //    if (booking != null)
    //    {
    //        await _context.bookings.AddAsync(booking);
    //        return await _context.SaveChangesAsync();

    //    }
    //    else
    //    {
    //        throw new ArgumentNullException(nameof(booking), "Invalid data");
    //    }
    //}
    //public async Task<int> UpdateBookingAsync(FlightInfo.Booking booking)
    //{
    //    booking.UpdatedOn = DateTime.Now;
    //    if (booking != null)
    //    {
    //        _context.bookings.Update(booking);
    //        return await _context.SaveChangesAsync();
    //    }
    //    else
    //    {
    //        throw new ArgumentNullException(nameof(booking), "Invalid data");
    //    }

    //}
    //public async Task<int> DeleteBookingAsync(FlightInfo.Booking booking)
    //{
    //    booking.Status = false;
    //    _context.bookings.Update(booking);
    //    return await _context.SaveChangesAsync();
    //}

}

