// Models/Microondas.cs
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MicroondasApp.Models
{
    public class Microondas
    {
        [Required]
        [Range(1, 120, ErrorMessage = "O tempo deve estar entre 1 segundo e 2 minutos.")]
        public int TempoSegundos { get; set; } = 30;

        [Required]
        [Range(1, 10, ErrorMessage = "A potência deve estar entre 1 e 10.")]
        public int Potencia { get; set; } = 10;

        public string Aquecimento { get; set; }
        public bool EmExecucao { get; set; }
        public bool EmPausa { get; set; }
        public List<ProgramaAquecimento> Programas { get; set; } = new List<ProgramaAquecimento>();

        public void IniciarAquecimento()
        {
            if (TempoSegundos < 1 || TempoSegundos > 120)
                throw new ArgumentException("Tempo inválido");

            EmExecucao = true;
            EmPausa = false;
            Aquecimento = GerarStringAquecimento();
        }

        public void PausarOuCancelar()
        {

        }

        public void AdicionarTempo()
        {
            if (EmExecucao)
                TempoSegundos = Math.Min(TempoSegundos + 30, 120);
        }

        private string GerarStringAquecimento()
        {
            return new string('.', Potencia) + " Aquecimento concluído";
        }

        internal Task PausarOuCancelarAsync()
        {
            try
            {
                if (EmExecucao)
                {
                    EmPausa = !EmPausa;
                    if (!EmPausa) EmExecucao = false;
                }
                else
                {
                    TempoSegundos = 30;
                    Potencia = 10;
                    Aquecimento = "";
                }

            }
            catch (Exception ex)
            {

            }
        }
    }
}
