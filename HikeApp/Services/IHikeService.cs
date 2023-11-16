using HikeApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HikeApp.Services
{
    public interface IHikeService
    {
        Task<List<HikeModel>> GetHikeList();
        Task<int> AddHike(HikeModel hikeModel);
        Task<int> DeleteHike(HikeModel hikeModel);
        Task<int> UpdateHike(HikeModel hikeModel);

        Task<int> DeleteAllHikes();
    }
}
