using AppNotes.Views;

namespace AppNotes
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            //Se tiene que registrar esta ruta ya que no se encuentra en ShellContent de AppShell, es decir es una ruta secundaria
            Routing.RegisterRoute(nameof(NotesPage), typeof(NotesPage));
        }
    }
}
