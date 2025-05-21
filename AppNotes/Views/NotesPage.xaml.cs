using System.Threading.Tasks;

namespace AppNotes.Views;
[QueryProperty(nameof(ItemId), nameof(ItemId))]
public partial class NotesPage : ContentPage
{

    //Search for the AppDataDirectory in whatever OS and create a textfile called AppNotes.txt
    //string _fileName = Path.Combine(FileSystem.AppDataDirectory, "AppNotes.txt");
    public string ItemId{ set { LoadNote(value); } }
    public NotesPage()
    {
        InitializeComponent();

        string pathFile = FileSystem.AppDataDirectory;
        string randomFileName = $"{Path.GetRandomFileName()}.Notes.txt";

        LoadNote(Path.Combine(pathFile, randomFileName));
    }

    private async void  DeleteButton_Clicked(object sender, EventArgs e)
    {
        //Delete the file

        if(BindingContext is Models.Note note)
        {
            if (File.Exists(note.FilenName))
            {
                File.Delete(note.FilenName);
            }

        }
        //Nos vamos a la pagina  de la cual viene
        await Shell.Current.GoToAsync("..");

    }

    private async void SaveButton_Clicked(object sender, EventArgs e)
    {
        if(BindingContext is Models.Note note)
        {
            File.WriteAllText(note.FilenName, TextEditor.Text);
            await Shell.Current.GoToAsync("..");
        }
    }



    private void LoadNote(string fileName)
    {
        Models.Note note = new Models.Note();
        note.FilenName = fileName;

        if (File.Exists(fileName))
        {
            note.Date = File.GetCreationTime(fileName);
            note.Text = File.ReadAllText(fileName);
        }

        BindingContext = note;
    }

}