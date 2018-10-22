using System;
using GalaSoft.MvvmLight;
using Notepad.Model;
using PostSharp.Patterns.Model;
using System.Collections.Generic;
using Notepad.EF;
using System.Net.Http;
using System.Net;
using System.IO;
using System.Text;
using Newtonsoft.Json.Linq;
using RestSharp;
using RestSharp.Authenticators;
using System.Windows;
using System.Data.Entity;
using Notepad.PostSharp;
using GalaSoft.MvvmLight.Messaging;
using Notepad.Messages;
using System.ComponentModel;
using System.Linq;
using System.Configuration;


namespace Notepad.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    [NotifyPropertyChanged]
    public class MainViewModel : ViewModelBase
    {
        public NoteViewModel SelectedNote { get; set; }
        public BindingList<NoteViewModel> Notes { get; set; }
        public System.Windows.Threading.DispatcherTimer _dispatcherTimer { get; set; }
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        [PostSharpException]
        public MainViewModel()
        {
            Notes = new BindingList<NoteViewModel>();

            //no matter what request i make StatusCode is always System.Net.HttpStatusCode.OK, but content is 
            //"\r\n\r\n<html>\r\n<head id=\"head\"><title>\r\n\tError\r\n</title></head>\r\n<body>\r\n    <div>\r\n        An error occurred while processing your request. Please contact <a href=\"mailto:support@anotepad.com?subject=Error-https://anotepad.com/api/notes\">Support@Anotepad.com</a> for help.\r\n    </div>\r\n</body>\r\n</html>"
            //so i couldn't use this api to store notes and didn't find any other notepad api online
            //that's why i will only make local storage using sqlite
            var client = new RestClient("https://anotepad.com/api/notes");
            client.Authenticator = new SimpleAuthenticator("user", "asd@gmail.com", "password", "asd");
            var request1 = new RestRequest(Method.POST);
            request1.AddParameter("content", "321dyval");
            request1.AddParameter("title", "123dasdasd");
            IRestResponse response1 = client.Execute(request1);

            GetNotesFromDB();
            SelectedNote = Notes[0];

            Messenger.Default.Register<AddNewNote>(this, AddNewNote);
            Messenger.Default.Register<SaveNote>(this, SaveNote);

            string interval = ConfigurationManager.AppSettings.Get("interval");
            int intervalInt = 5; //defaultvalue
            int.TryParse(interval, out intervalInt);

            _dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            _dispatcherTimer.Tick += new EventHandler(SyncData);
            _dispatcherTimer.Interval = new TimeSpan(0, intervalInt, 0);
            _dispatcherTimer.Start();
        }

        [PostSharpException]
        private void GetNotesFromDB()
        {
            using (var db = new MyDbContext())
            {
                foreach (var note in db.Notes)
                {
                    Notes.Add(new NoteViewModel(note));
                }
            }
        }

        [PostSharpException]
        private void AddNewNote(AddNewNote message)
        {
            Note note = new Note();
            note.Title = "Title";
            using (var db = new MyDbContext())
            {
                db.Notes.Add(note);
                db.SaveChanges();
            }
            NoteViewModel noteVM = new NoteViewModel(note);
            Notes.Add(noteVM);
            SelectedNote = noteVM;
        }

        [PostSharpException]
        private void SaveNote(SaveNote message)
        {
            using (var db = new MyDbContext())
            {
                Note note = db.Notes.FirstOrDefault(x => x.ID == SelectedNote.ID);
                note.Title = SelectedNote.Title;
                note.Content = SelectedNote.Content;
                db.SaveChanges();
            }
            MessageBox.Show("Note has been saved successfully!");
        }
        
        private void SyncData(object sender, EventArgs e)
        {
            try
            {
                List<Note> newNotes = new List<Note>();
                using (var db = new MyDbContext())
                {
                    foreach (NoteViewModel noteVM in Notes)
                    {
                        Note note = db.Notes.FirstOrDefault(x => x.ID == noteVM.ID);
                        if (note == null)
                        {
                            newNotes.Add(noteVM.Note);
                        }
                        else
                        {
                            note.Title = noteVM.Title;
                            note.Content = noteVM.Content;
                        }
                    }
                    foreach(Note newNote in newNotes)
                    {
                        db.Notes.Add(newNote);
                    }
                    db.SaveChanges();
                }
            }
            catch
            {
                _dispatcherTimer.Tick -= new EventHandler(SyncData);
                _dispatcherTimer.Stop();
            }
        }
    }
}