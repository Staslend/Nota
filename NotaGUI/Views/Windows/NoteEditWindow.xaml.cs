using NotaDataLibrary.Models;
using NotaGUI.ViewModels;
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
        /// <summary>
        /// Open empty note window
        /// </summary>
        public NoteEditWindow()
        {
            InitializeComponent();
            NoteEditWindowViewModel noteEditViewModel = new();
            DataContext = noteEditViewModel;

        }


        /// <summary>
        /// Open edit window with Id. 
        /// ---NOT TO USE--- 
        /// </summary>
        /// <param name="Id">Id of note that should be opened</param>
        public NoteEditWindow(int Id)
        {
            InitializeComponent();
            NoteEditWindowViewModel noteEditViewModel = new(Id);
            DataContext = noteEditViewModel;
        }

        /// <summary>
        /// Open edit window with already fetched note
        /// </summary>
        /// <param name="note">Note to edit</param>
        public NoteEditWindow(Note note)
        {
            InitializeComponent();
            NoteEditWindowViewModel noteEditViewModel = new(note);
            DataContext = noteEditViewModel;

        }

    }
}
