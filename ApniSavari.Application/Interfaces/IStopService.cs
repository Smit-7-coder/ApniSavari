using ApniSavari.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApniSavari.Application.Interfaces
{
    public interface IStopService
    {
        Task<List<StopSearchResponseDto>> SearchStopsAsync(string query);
    }
}
