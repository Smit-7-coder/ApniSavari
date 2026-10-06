using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApniSavari.Application.Interfaces;
using ApniSavari.Application.DTOs;
using ApniSavari.Infrastructure.Persistence.Context.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace ApniSavari.Infrastructure.Services
{
    public class StopService : IStopService
    {
        private readonly ApniSavariDbContext _context;

        public StopService(ApniSavariDbContext context)
        {
            _context = context;
        }

        public async Task<List<StopSearchResponseDto>> SearchStopsAsync(string query)
        {
            if (string.IsNullOrWhiteSpace(query))
            {
                return new List<StopSearchResponseDto>();
            }
            query = query.Trim();

            return await _context.Stops
                .AsNoTracking()
                .Where(s =>
                s.Status == "Active" &&
                (
                    s.Name.Contains(query) ||
                    s.City.Contains(query)
                ))
                .OrderBy(s => s.City)
                .ThenBy(s => s.Name)
                .Take(10)
                .Select(s => new StopSearchResponseDto
                {
                    StopId = s.StopId,
                    Name = s.Name,
                    City = s.City,
                    StateCode = s.StateCode
                })
                .ToListAsync();
        }
    }
}
