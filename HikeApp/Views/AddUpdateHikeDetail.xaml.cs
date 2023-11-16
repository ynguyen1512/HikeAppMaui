using HikeApp.ViewModels;

namespace HikeApp.Views;

public partial class AddUpdateHikeDetail : ContentPage
{
	public AddUpdateHikeDetail(AddUpdateHikeDetailViewModel viewModel)
	{
		InitializeComponent();
		this.BindingContext = viewModel;
	}
}