using HikeApp.ViewModels;

namespace HikeApp.Views;

public partial class HikeListPage : ContentPage
{
	private HikeListPageViewModel _viewModel;
	public HikeListPage(HikeListPageViewModel viewModel)
	{
		InitializeComponent();
        _viewModel = viewModel;
        this.BindingContext = viewModel;
	}
    protected override void OnAppearing()
    {
        base.OnAppearing();
        _viewModel.GetHikeListCommand.Execute(null);
    }
}