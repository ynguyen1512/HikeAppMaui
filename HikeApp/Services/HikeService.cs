using HikeApp.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HikeApp.Services
{
    public class HikeService : IHikeService
    {
        private SQLiteAsyncConnection _dbConnection;
        private TableMapping hikeModel;

        public HikeService()
        {
            setUpDb();
        }

        private async void setUpDb()
        {
            if (_dbConnection == null)
            {
                string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Hike.db3");
                _dbConnection = new SQLiteAsyncConnection(dbPath);
                await _dbConnection.CreateTableAsync<HikeModel>();
            }
        }
        public Task<int> AddHike(HikeModel hikeModel)
        {
            return _dbConnection.InsertAsync(hikeModel);
        }

        public Task<int> DeleteHike(HikeModel hikeModel)
        {
            return _dbConnection.DeleteAsync(hikeModel);
        }

        public async Task<List<HikeModel>> GetHikeList()
        {
            var hikeList = await _dbConnection.Table<HikeModel>().ToListAsync();
            return hikeList;
        }

        public Task<int> UpdateHike(HikeModel hikeModel)
        {
            return _dbConnection.UpdateAsync(hikeModel);
        }

        public Task<int> DeleteAllHikes()
        {
            return _dbConnection.DeleteAllAsync<HikeModel>();
        }



    }
}
