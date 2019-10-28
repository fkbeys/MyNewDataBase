using System;
using Xamarin.Forms;
using Notes.Models;
using System.Collections.Generic;

namespace Notes
{
    public partial class NotesPage : ContentPage
    {
        public NotesPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

     
            List<Note> StockLIST = new List<Note>();
            StockLIST.Add(new Note() {Text="bbbb",Gender="fame",Date= DateTime.UtcNow });
            StockLIST.Add(new Note() { Text = "bbbb1", Gender = "fame", Date = DateTime.UtcNow });
            StockLIST.Add(new Note() { Text = "bbbb2", Gender = "fame", Date = DateTime.UtcNow });
            StockLIST.Add(new Note() { Text = "bbbb3", Gender = "fame", Date = DateTime.UtcNow });

            foreach (var item in StockLIST)
            {
                await App.Database.SaveNoteAsync(item);
            }

           



            listView.ItemsSource = await App.Database.GetNotesAsync();
        }

        async void OnNoteAddedClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NoteEntryPage
            {
                BindingContext = new Note()
            });
        }

        async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new NoteEntryPage
                {
                    BindingContext = e.SelectedItem as Note
                });
            }
        }
    }
}
