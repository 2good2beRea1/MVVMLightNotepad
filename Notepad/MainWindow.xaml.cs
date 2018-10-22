using GalaSoft.MvvmLight.Messaging;
using Notepad.Messages;
using Notepad.Model;
using Notepad.ViewModel;
using RestSharp;
using RestSharp.Authenticators;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Notepad
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
        }

        private void AddNoteButton_Click(object sender, RoutedEventArgs e)
        {
            Messenger.Default.Send(new AddNewNote());
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            Messenger.Default.Send(new SaveNote());
        }
    }
}
