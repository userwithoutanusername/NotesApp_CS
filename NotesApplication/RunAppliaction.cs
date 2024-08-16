using NotesLibary;

namespace NotesApplication
{
    public static class RunAppliaction
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new AuthorisationForm());
        }
    }
}