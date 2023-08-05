﻿using Dentistry.Domain.Models;

namespace Dentistry.DAL.Repositories.NoteRepository
{
    public interface INoteRepository
    {
        Task<IEnumerable<Note>> GetNotesAsync();
        Task<Note> GetNoteByIdAsync(int id);
    }
}
