using NotaDataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NotaDataLibrary.DataAccess;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using NotaGUI.MVVM;
using NotaGUI.Views.Windows;
using System.Windows;

namespace NotaGUI.ViewModels
{

    public partial class MainWindowViewModel : BaseViewModel
    {
        /// <summary>
        /// Basic Main Window View Model constructor
        /// </summary>
        public MainWindowViewModel()
        {
            NoteEditWindowViewModel.dataSavedEvent += new Action(UpdateNoteListAction);
        }


        /// <summary>
        /// List that represent the list of all created notes
        /// Basically, its just an interface for database 
        /// </summary>
        public List<Note> NoteList
        {
            get { using (NoteContext nc = new NoteContext()) return nc.Notes.ToList(); }
        }

        /// <summary>
        /// Update forms that note list was changed 
        /// </summary>
        void UpdateNoteListAction()
        {
            OnPropertyChanged("NoteList");
        }

        private RelayCommand _addNewNoteCommand;
        /// <summary>
        /// Open empty note 
        /// </summary>
        public RelayCommand AddNewNoteCommand
        {
            get
            {
                return _addNewNoteCommand ??
                    (_addNewNoteCommand = new RelayCommand(obj =>
                    {
                        Note note = new Note();
                        using(NoteContext nc = new NoteContext())
                        {
                            nc.Notes.Add(note);
                            nc.SaveChanges();

                            nc.Entry(note).GetDatabaseValues();
                            NoteEditWindow noteEditWindow = new NoteEditWindow(note);
                            noteEditWindow.Show();

                            OnPropertyChanged("NoteList");
                        }
                    }, obj =>
                    {
                        return true;
                    }));

            }
        }

        private RelayCommand _deleteNoteCommand;
        /// <summary>
        /// Dele note from memory
        /// </summary>
        public RelayCommand DeleteNoteCommand
        {
            get
            {
                return _deleteNoteCommand ??
                    (_deleteNoteCommand = new RelayCommand(obj =>
                    {
                        MessageBoxResult result = MessageBox.Show("Do you really want to delete this note?", "Note deleting", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);

                        switch(result)
                        {
                            case MessageBoxResult.Yes:
                                {
                                    using (NoteContext nc = new NoteContext())
                                    {
                                        Note noteToDelete = new() { id = (int)obj };
                                        nc.Notes.Attach(noteToDelete);
                                        nc.Notes.Remove(noteToDelete);
                                        nc.SaveChanges();
                                        OnPropertyChanged("NoteList");
                                    }
                                    break;
                                }
                            case MessageBoxResult.No:
                                {
                                    break;
                                }
                        }
                    }));
            }
        }

        private RelayCommand _openEditWindowCommand;
        /// <summary>
        /// Open edit window 
        /// </summary>
        public RelayCommand OpenEditWindowCommand
        {
            get
            {
                return _openEditWindowCommand ??
                    (_openEditWindowCommand = new RelayCommand(obj => {

                        using (NotaDataLibrary.DataAccess.NoteContext nc = new NotaDataLibrary.DataAccess.NoteContext())
                        {
                            Note note = nc.Notes.Where(n => n.id == (int)obj).First();
                            NoteEditWindow noteEditWindow = new NoteEditWindow(note);
                            noteEditWindow.Show();
                        }
                    }));
            }
        }
    }
}
