using CrudUsuarios.Data;
using CrudUsuarios.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CrudUsuarios.Controllers;

public class UsuariosController : Controller
{
    private readonly AppDbContext _context;

    public UsuariosController(AppDbContext context)
    {
        _context = context;
    }

    // READ: lista de usuarios
    public async Task<IActionResult> Index()
    {
        return View(await _context.Usuarios.OrderBy(u => u.Id).ToListAsync());
    }

    // CREATE
    public IActionResult Create() => View(new Usuario { Activo = true });

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Perfil,Email,Edad,Activo,Balance")] Usuario usuario)
    {
        if (await _context.Usuarios.AnyAsync(u => u.Email == usuario.Email))
            ModelState.AddModelError("Email", "Ya existe un usuario con ese correo");

        if (!ModelState.IsValid) return View(usuario);

        usuario.FechaRegistro = DateTime.Now;
        _context.Add(usuario);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    // UPDATE
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null) return NotFound();
        var usuario = await _context.Usuarios.FindAsync(id);
        return usuario == null ? NotFound() : View(usuario);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id,Perfil,Email,Edad,Activo,Balance")] Usuario datos)
    {
        if (id != datos.Id) return NotFound();

        if (await _context.Usuarios.AnyAsync(u => u.Email == datos.Email && u.Id != id))
            ModelState.AddModelError("Email", "Ya existe otro usuario con ese correo");

        if (!ModelState.IsValid) return View(datos);

        var usuario = await _context.Usuarios.FindAsync(id);
        if (usuario == null) return NotFound();

        usuario.Perfil = datos.Perfil;
        usuario.Email = datos.Email;
        usuario.Edad = datos.Edad;
        usuario.Activo = datos.Activo;
        usuario.Balance = datos.Balance;

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    // DELETE
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null) return NotFound();
        var usuario = await _context.Usuarios.FindAsync(id);
        return usuario == null ? NotFound() : View(usuario);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var usuario = await _context.Usuarios.FindAsync(id);
        if (usuario != null)
        {
            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();
        }
        return RedirectToAction(nameof(Index));
    }
}
