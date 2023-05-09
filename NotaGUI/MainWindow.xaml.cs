using Microsoft.EntityFrameworkCore;
using NotaDataLibrary.Models;
using NotaGUI.Views.Windows;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace NotaGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        /// <summary>
        /// List of all notes that are available 
        /// </summary>
        public List<Note> NoteLis;
        NotaDataLibrary.DataAccess.NoteContext nc = new NotaDataLibrary.DataAccess.NoteContext();
        public MainWindow()
        {
            InitializeComponent();

            NoteEditWindow.dataSaved += new EventHandler(NoteEditWindow_DataSaved);
            DataContext = this;
            UpdateNoteList();
        }

        /// <summary>
        /// Event that called when user press Save button in Note editor
        /// </summary>
        void NoteEditWindow_DataSaved(object sender, EventArgs e)
        {
            UpdateNoteList();
        }

        /// <summary>
        /// Update list of notes taking data from database
        /// </summary>
        public void UpdateNoteList()
        {
                NoteLis = nc.Notes.ToList();
                this.NotesListBox.ItemsSource = NoteLis;
        }

        /// <summary>
        /// Add new note to database and to the list plus opening a new note editor
        /// </summary>
        private void AddNewNote_Click(object sender, RoutedEventArgs e)
        {
                Note n = new Note();

                nc.Notes.Add(n);
                nc.SaveChanges();

                nc.Entry(n).GetDatabaseValues();
                NoteEditWindow noteEditWindow = new NoteEditWindow(n.id);
                noteEditWindow.Show();

                UpdateNoteList();
        }
    }
}
