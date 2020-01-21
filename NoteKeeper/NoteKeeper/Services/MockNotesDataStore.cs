using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NoteKeeper.Models;

namespace NoteKeeper.Services
{
    public class MockNotesDataStore : INotesDataStore
    {
        private static readonly List<string> mockCourses;
        private static readonly List<Note> mockNotes;
        private static int nextNoteId { get; set; }

        static MockNotesDataStore()
        {
            mockCourses = new List<string>
            {
                "Introduction to Xamarin.Forms",
                "What’s New in C# 8.0 and .NET Core 3.0",
                "Using the Xamarin.Forms Shell"
            };

            mockNotes = new List<Note>
            {
                new Note
                {
                    Id = 1,
                    Heading = "UI Code",
                    Text = "Xamarin.Forms allows UI Codes to be shared",
                    Course = ""
                },
                new Note
                {
                    Id = 2,
                    Heading = "Native App",
                    Text = "Xamarin.Forms produces native applications",
                    Course = ""
                },
                new Note
                {
                    Id = 3,
                    Heading = "Pattern Matching",
                    Text = "Could be used to replace switch statement   ",
                    Course = ""
                },
                new Note
                {
                    Id = 4,
                    Heading = "JSON",
                    Text = "JSON has been integrated into System.Text",
                    Course = ""
                },
                new Note
                {
                    Id = 5,
                    Heading = "Shell",
                    Text = "A new way to create Xamarin.Forms",
                    Course = ""
                }
            };
        }

        public Task<bool> AddItemAsync(Note item)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteItemAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<List<string>> GetCourseAsync()
        {
            return Task.FromResult(mockCourses);
        }

        public Task<Note> GetItemAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Note>> GetItemsAsync(bool forceRefresh = false)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateItemAsync(Note item)
        {
            throw new NotImplementedException();
        }
    }
}
