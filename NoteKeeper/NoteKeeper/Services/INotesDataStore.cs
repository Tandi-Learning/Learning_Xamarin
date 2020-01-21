using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NoteKeeper.Models;

namespace NoteKeeper.Services
{
    public interface INotesDataStore : IDataStore<Note>
    {
        Task<List<String>> GetCourseAsync();
    }
}
