using System;
using System.Collections.Generic;
using NoteKeeper.Models;

namespace NoteKeeper.ViewModels
{
    public class ItemDetailViewModel : BaseViewModel
    {
        public Note note { get; set; }
        public List<String> courseList { get; set; }

        public String NoteHeading
        {
            get
            {
                return note.Heading;
            }
            set
            {
                note.Heading = value;
                OnPropertyChanged();
            }
        }

        public ItemDetailViewModel(Item item = null)
        {
            Title = item?.Text;
            note = new Note
            {
                Heading = "Test Heading",
                Text = "Text for Note in ViewModel"
            };
            InitializeCourseList();
        }

        public async void InitializeCourseList()
        {
            courseList = await NotesDataStore.GetCourseAsync();
        }
    }
}
