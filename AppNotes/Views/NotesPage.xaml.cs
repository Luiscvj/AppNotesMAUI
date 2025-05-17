namespace AppNotes.Views;

public partial class NotesPage : ContentPage
{
    //Search for the AppDataDirectory in whatever OS and create a textfile called AppNotes.txt
    string _fileName = Path.Combine(FileSystem.AppDataDirectory, "Appnotes.txt");
    public NotesPage()
    {
        InitializeComponent();

        if (File.Exists(_fileName))
        {
            TextEditor.Text = File.ReadAllText(_fileName);
        }
    }

    private void DeleteButton_Clicked(object sender, EventArgs e)
    {
        //Delete the file
        if (File.Exists(_fileName))
        {
            File.Delete(_fileName);
        }
        TextEditor.Text = String.Empty;
      
    }

    private void SaveButton_Clicked(object sender, EventArgs e)
    {
        File.WriteAllText(_fileName, TextEditor.Text);
    }
}