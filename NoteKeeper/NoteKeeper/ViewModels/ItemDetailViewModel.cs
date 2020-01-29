using System;
using System.Collections.Generic;
using NoteKeeper.Models;

namespace NoteKeeper.ViewModels
{
    public class ItemDetailViewModel : BaseViewModel
    {
        public Note Note { get; set; }
        public List<String> courseList { get; set; }

        public String NoteHeading
        {
            get
            {
                return Note.Heading;
            }
            set
            {
                Note.Heading = value;
                OnPropertyChanged();
            }
        }

        public ItemDetailViewModel(Note note = null)
        {
            Title = "Edit Note"; 
            InitializeCourseList();
            Note = note ?? new Note();

        }

        public async void InitializeCourseList()
        {
            courseList = await NotesDataStore.GetCourseAsync();
        }
    }
}
