 using System;

using Xamarin.Forms;

namespace NoteKeeper.Models
{
    public class Note
    {
        public Int32 Id { get; set; }
        public String Heading { get; set; }
        public String Text { get; set; }
        public String Course { get; set; }
    }
}

