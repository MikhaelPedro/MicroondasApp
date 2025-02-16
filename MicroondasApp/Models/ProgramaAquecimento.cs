// Models/ProgramaAquecimento.cs
namespace MicroondasApp.Models
{
    public class ProgramaAquecimento
    {
        public string Nome { get; set; }
        public string Alimento { get; set; }
        public int Tempo { get; set; }
        public int Potencia { get; set; }
        public string CaracterAquecimento { get; set; }
        public string Instrucoes { get; set; }
    }
}
