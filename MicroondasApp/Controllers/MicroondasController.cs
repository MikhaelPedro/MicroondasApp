// Controllers/MicroondasController.cs
using Microsoft.AspNetCore.Mvc;
using MicroondasApp.Models;
using System.Collections.Generic;

namespace MicroondasApp.Controllers
{
    public class MicroondasController : Controller
    {
        private static Microondas _microondas = new Microondas();
        private static List<ProgramaAquecimento> _programas = new List<ProgramaAquecimento>
        {
            new ProgramaAquecimento { Nome = "Pipoca", Alimento = "Pipoca de micro-ondas", Tempo = 180, Potencia = 7, CaracterAquecimento = "*", Instrucoes = "Observar os estouros do milho." },
            new ProgramaAquecimento { Nome = "Leite", Alimento = "Leite", Tempo = 300, Potencia = 5, CaracterAquecimento = "#", Instrucoes = "Cuidado com choque térmico." },
            new ProgramaAquecimento { Nome = "Carnes", Alimento = "Carne", Tempo = 840, Potencia = 4, CaracterAquecimento = "@", Instrucoes = "Virar na metade do tempo." }
        };

        public IActionResult Index()
        {
            _microondas.Programas = _programas;
            return View(_microondas);
        }

        [HttpPost]
        public IActionResult Iniciar(int tempo, int potencia)
        {
            _microondas.TempoSegundos = tempo;
            _microondas.Potencia = potencia;
            _microondas.IniciarAquecimento();
            return RedirectToAction("Index");
        }

    [HttpPost]
    public async Task<IActionResult> PausarOuCancelar()
    {
        await _microondas.PausarOuCancelarAsync();
        return RedirectToAction("Index");
    }


        [HttpPost]
        public IActionResult AdicionarTempo()
        {
            _microondas.AdicionarTempo();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult SelecionarPrograma(string nome)
        {
            var programa = _programas.Find(p => p.Nome == nome);
            if (programa != null)
            {
                _microondas.TempoSegundos = programa.Tempo;
                _microondas.Potencia = programa.Potencia;
                _microondas.Aquecimento = new string(programa.CaracterAquecimento[0], programa.Tempo / 10) + " Aquecimento concluído";
            }
            return RedirectToAction("Index");
        }
    }
}
