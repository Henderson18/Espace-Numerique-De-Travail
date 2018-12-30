using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ENAapp.Models;
using ENAapp.Models.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ENAapp.Controllers
{
    [Route("api/[controller]")]
    
    public class NoteApiController : Controller
    {
        private INoteRepository noteRepository;

        public NoteApiController(INoteRepository noteRepository)
        {
            this.noteRepository = noteRepository;
        }

        [HttpPost]
        public IQueryable noteEtudiant([FromBody] Notes notes)
        {
            return this.noteRepository.NotesEtudiant(notes.Matricule,notes.Idsemestre);
        }

    }
}