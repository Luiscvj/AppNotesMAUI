using System.Threading.Tasks;

namespace AppNotes.Views;
//Los query string se ponen a nivel de clase


public partial class AllNotesPage : ContentPage
{
    
    public AllNotesPage()
    {
        InitializeComponent();

        BindingContext = new Models.AllNotes();
    }
    //eL METODO SE LLAMA SIEMPRE QUE SE CARGUE LA PAGINA
    protected override void OnAppearing()
    {
        ((Models.AllNotes)BindingContext).LoadNotes();
    }
    private async  void Add_Clicked(object sender, EventArgs e)
    {
        //Vamos hacia la pagina  donde agregamos una nota
        await Shell.Current.GoToAsync(nameof(NotesPage));
    }

    public async void  NotesCollection_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if(e.CurrentSelection.Count != 0)
        {
            var note = (Models.Note)e.CurrentSelection[0];
            //NotePage?ItemId=path.notes.txt
            //Vamos a ir a NotePage y le pasamos el Id para que vaya y lo busque
            //Query String interno
            await Shell.Current.GoToAsync($"{nameof(NotesPage)}?{nameof(NotesPage.ItemId)}={note.FilenName}");
            notesCollection.SelectedItem = null;
        }
    }
}