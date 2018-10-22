using Notepad.Model;
using PostSharp.Patterns.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notepad.ViewModel
{
    [NotifyPropertyChanged]
    public class NoteViewModel
    {
        public NoteViewModel(Note note)
        {
            Note = note;
        }

        public Note Note
        {
            get; set;
        }

        public int ID
        {
            get { return Note.ID; }
            set { Note.ID = value; }
        }

        public string Title
        {
            get { return Note.Title; }
            set { Note.Title = value; }
        }

        public string Content
        {
            get { return Note.Content; }
            set { Note.Content = value; }
        }
    }
}
