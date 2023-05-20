using Microsoft.EntityFrameworkCore.Update.Internal;
using NotaDataLibrary.Models;
using NotaGUI.MVVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace NotaGUI.ViewModels
{
    internal class NoteEditWindowViewModel : BaseViewModel
    {
        /// <summary>
        /// Basic edit window constructor
        /// </summary>
        public NoteEditWindowViewModel() 
        { 
        }

        /// <summary>
        /// Edit window constructor that use Id to fill forms and fetch data from Database 
        /// --- NOT TO USE ---
        /// </summary>
        /// <param name="id">Id of note to open</param>
        public NoteEditWindowViewModel(int id)
        {
            Id=id;
            EditWindowLoadData();
        }

        /// <summary>
        /// Edit window constructor that use already created\fetched data to fill forms
        /// </summary>
        /// <param name="note">Note to edit</param>
        public NoteEditWindowViewModel(Note note)
        {
            Id = note.id;
            TextFieldText = note.text;
            SubjectFieldText = note.subject;
        }


        /// <summary>
        /// Action that update ListView on Main Window.
        /// I still find this solution pretty weird, it can create problems in bigger perspective
        /// </summary>
        /// TODO: Find a better solution for this
        public static event Action dataSavedEvent;

        
        private int _id;

        /// <summary>
        /// Id of an edited note
        /// </summary>
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }


        private string _textFieldText;

        /// <summary>
        /// Text field of note form
        /// </summary>
        public string TextFieldText
        {
            get { return _textFieldText; }
            set { 
                _textFieldText = value;
                OnPropertyChanged();
            }
        }

        private string _subjectFieldText;

        /// <summary>
        /// Subject field of note form
        /// </summary>
        public string SubjectFieldText
        {
            get { return _subjectFieldText; }
            set { 
                _subjectFieldText = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Fetch data from database and fill forms
        /// </summary>
        public void EditWindowLoadData()
        {
            using (NotaDataLibrary.DataAccess.NoteContext nc = new NotaDataLibrary.DataAccess.NoteContext())
            {
                TextFieldText = nc.Notes.Where(n => n.id == Id).First().text;
                SubjectFieldText = nc.Notes.Where(n => n.id == Id).First().subject;

            }
        }

        private RelayCommand _saveNote;
        /// <summary>
        /// Command that save data from note to database
        /// </summary>
        public RelayCommand SaveNote
        {
            get
            {
                return _saveNote ??
                    (_saveNote = new RelayCommand(obj =>
                    {
                        using (NotaDataLibrary.DataAccess.NoteContext nc = new NotaDataLibrary.DataAccess.NoteContext())
                        {
                            var note = nc.Notes.Where(n => n.id == Id).First();
                            note.text = TextFieldText;
                            note.subject = SubjectFieldText;

                            nc.SaveChanges();

                            dataSavedEvent?.Invoke();
                        }
                    }));
            }
        }
    }
}
