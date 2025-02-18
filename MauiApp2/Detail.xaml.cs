using MauiApp2.ViewModel;
namespace MauiApp2;

public partial class Detail : ContentPage
{
	public Detail(DetailViewModel vm)
	{
		InitializeComponent();
        BindingContext = vm;
    }
}