using static TelaCadastro.ViewsModel.ViewsModel;

namespace TelaCadastro
{
    public partial class MainPage : ContentPage
    {
      

        public MainPage()
        {
            InitializeComponent();
        

      
                // Aqui definimos o ViewModel como DataContext (em MAUI é BindingContext)
                BindingContext = new CadastroViewModel();
          
        }

    }
}
