//using Android.Database;
using HikeApp.Models;
using HikeApp.Services;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HikeApp.ViewModels
{
    [QueryProperty(nameof(HikeDetail),"HikeDetail")]
    public partial class AddUpdateHikeDetailViewModel : ObservableObject
    {

        [ObservableProperty]
        private HikeModel _hikeDetail = new HikeModel();

        private readonly IHikeService _hikeService;

        public AddUpdateHikeDetailViewModel(IHikeService hikeService)
        {
            _hikeService = hikeService;
        }

        


        [ICommand]
        public async void AddUpdateHike()
        {
            int response = -1;
            if(HikeDetail.HikeID > 0)
            {
                response = await _hikeService.UpdateHike(HikeDetail);
            }
            else
            {
                response = await _hikeService.AddHike(new Models.HikeModel
                {
                    NameOfHike = HikeDetail.NameOfHike,
                    Location = HikeDetail.Location,
                    ParkingAvailable = HikeDetail.ParkingAvailable,
                    Length = HikeDetail.Length,
                    Level = HikeDetail.Level,
                    Description = HikeDetail.Description

                });
            }
            
            if(response > 0)
            {
                await Shell.Current.DisplayAlert("Hike Added", "Record Added to Hike Table", "OK");
            }
            else
            {
                await Shell.Current.DisplayAlert("Failed", "Something went wrong", "OK");
            }
        }
    }
}
