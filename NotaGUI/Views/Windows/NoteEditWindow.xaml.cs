using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace NotaGUI.Views.Windows
{
    /// <summary>
    /// Interaction logic for NoteEditWindow.xaml
    /// </summary>
    public partial class NoteEditWindow : Window
    {
        public NoteEditWindow()
        {
            InitializeComponent();
        }

        //ID of edited note
        private int id = 0;

        //Event that triggered when save button pressed
        public static event EventHandler dataSaved; 

        public NoteEditWindow(int Id)
        {
            InitializeComponent();
            this.id = Id;

            //Load text from the database to the text field of the editor
            using (NotaDataLibrary.DataAccess.NoteContext nc = new NotaDataLibrary.DataAccess.NoteContext())
            {
                this.TextField.Text = nc.Notes.Where(n => n.id == Id).First().text;
                this.SubjectField.Text = nc.Notes.Where(n => n.id == Id).First().subject;

            }
        }
        /// <summary>
        /// Event that triggered when save button pressed 
        /// </summary>
        private void SaveNoteTextButton_Click(object sender, RoutedEventArgs e)
        {
            SaveTextToDatabase();
        }

        /// <summary>
        /// Save data from note editor to the database and update list in mainwindow
        /// </summary>
        private void SaveTextToDatabase()
        {
            using (NotaDataLibrary.DataAccess.NoteContext nc = new NotaDataLibrary.DataAccess.NoteContext())
            {
                var note = nc.Notes.Where(n => n.id == this.id).First();
                note.text = this.TextField.Text;
                note.subject = this.SubjectField.Text;

                nc.SaveChanges();

                dataSaved?.Invoke(this, new EventArgs());

            }

        }
    }
}
