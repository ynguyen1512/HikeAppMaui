using HikeApp.Views;

namespace HikeApp
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(AddUpdateHikeDetail), typeof(AddUpdateHikeDetail));
        }
    }
}