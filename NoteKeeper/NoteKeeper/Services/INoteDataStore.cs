using System;

using Xamarin.Forms;

namespace NoteKeeper.Services
{
    public class INoteDataStore : ContentPage
    {
        public INoteDataStore()
        {
            Content = new StackLayout
            {
                Children = {
                    new Label { Text = "Hello ContentPage" }
                }
            };
        }
    }
}

