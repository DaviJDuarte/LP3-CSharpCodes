using Microsoft.AspNetCore.Mvc;
using Aula29MVCDB.Models;
namespace Aula29MVCDB.Controllers;
public class ClienteController : Controller
{
    private readonly MvcDBContext _context;

    public ClienteController(MvcDBContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        return View(_context.Cliente);
    }

    public IActionResult Show(int id)
    {
        Cliente? cliente = _context.Cliente.Find(id);

        if (cliente == null)
        {
            return NotFound();
        }
        return View(cliente);
    }

    // public IActionResult Create()
    // {
    //     return View();
    // }

    // public IActionResult CreateResult(int id, string ram, string processor)
    // {
    //     if (_context.Computers.Find(id) == null)
    //     {
    //         _context.Computers.Add(new Computer(id, ram, processor));
    //         _context.SaveChanges();
    //         return RedirectToAction("Create");
    //     }
    //     else
    //     {
    //         return Content("Já existe um computador com esse id.");
    //     }

    // }

    // public IActionResult Delete(int id)
    // {
    //     _context.Computers.Remove(_context.Computers.Find(id));
    //     _context.SaveChanges();
    //     return View();
    // }

    // public IActionResult Update(int id)
    // {
    //     Computer computer = _context.Computers.Find(id);
    //     if (computer == null)
    //     {
    //         return Content("Esse computador não existe.");
    //     }
    //     else
    //     {
    //         return View(computer);
    //     }
    // }

    // public IActionResult UpdateResult(int id, string ram, string processor)
    // {
    //     Computer computer = _context.Computers.Find(id);

    //     computer.Ram = ram;
    //     computer.Processor = processor;
    //     _context.SaveChanges();
    //     return RedirectToAction("Index");
    // }
}