using HikeApp.Models;
using HikeApp.Services;
using HikeApp.Views;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HikeApp.ViewModels
{
    public partial class HikeListPageViewModel : ObservableObject
    {
        public ObservableCollection<HikeModel> Hikes { get; set; } = new ObservableCollection<HikeModel>();

        private readonly IHikeService _hikeService;
        public HikeListPageViewModel(IHikeService hikeService)
        {
            _hikeService = hikeService;
        }

        [ICommand]
        public async void GetHikeList()
        {
            var hikeList = await _hikeService.GetHikeList();
            if(hikeList?.Count > 0)
            {
                Hikes.Clear();
                foreach(var hike in hikeList)
                {
                    Hikes.Add(hike);
                }
            }
        }
        [ICommand]
        public async void AddUpdateHike()
        {
            await AppShell.Current.GoToAsync(nameof(AddUpdateHikeDetail));
        }

        [ICommand]
        public async void DisplayAction(HikeModel hikeModel)
        {
            var response = await AppShell.Current.DisplayActionSheet("Select Option", "OK", null, "Edit","Delete");
            if(response == "Edit")
            {
                var navParam = new Dictionary<string, object>();
                navParam.Add("HikeDetail",hikeModel);

                await AppShell.Current.GoToAsync(nameof(AddUpdateHikeDetail),navParam);
            }
            else if(response == "Delete")
            {
                var delRespone = await _hikeService.DeleteHike(hikeModel);
                if(delRespone > 0)
                {
                    GetHikeList();
                }
            }
        }

        [ICommand]
        public async Task DeleteAllHikes()
        {
            await _hikeService.DeleteAllHikes();
            Hikes.Clear(); // Clear the observable collection
        }
    }
}

