using CRUDMVC_Sqlite.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDMVC_Sqlite.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly Contexto _contexto;

        public UsuarioController(Contexto contexto)
        {
            _contexto = contexto;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _contexto.Usuario.ToArrayAsync());
        }

        [HttpGet]
        public IActionResult NovoUsuario()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> NovoUsuario(Usuarios usuario)
        {
            await _contexto.Usuario.AddAsync(usuario);
            await _contexto.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> AtualizarUsuario(int Id)
        {
            Usuarios usuarios = await _contexto.Usuario.FindAsync(Id);
            return View(usuarios);
        }

        [HttpPost]
        public async Task<IActionResult> AtualizarUsuario(Usuarios usuario)
        {
            _contexto.Usuario.Update(usuario);
            await _contexto.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> ExcluirUsuario(int Id)
        {
            Usuarios usuarios = await _contexto.Usuario.FindAsync(Id);
            _contexto.Usuario.Remove(usuarios);
            await _contexto.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
