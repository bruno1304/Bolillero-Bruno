using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolillero
{
    class Simulacion
    {
        public Simulacion(Bolillero)
        {
        Bolillero bolillero = new Bolillero();
        
        }

        public bool Jugar (List<byte> jugadas, Bolillero bolillero)
        {
            var comparar = 0;
            bolillero.reingresar();
            foreach (var bolillaJugada in jugadas)
            {
                comparar = bolillero.SacarBolilla();
                if (comparar != bolillaJugada)
                {
                    return false;
                }
            }
            return true;
        }
        public long jugarNveces (List<byte> jugadas, long cantJugadas, Bolillero bolillero)
        {
            long cantGanados = 0;
            for (int i = 0; i < cantGanados; i++)
            {
             
                if (this.Jugar(jugadas, bolillero) == true)
                {
                    cantGanados++;
                }
            }
            return cantGanados;
        }
        public long simularSinHilos(List<byte> jugadas, long cantJugadas)
        {
            return jugarNveces(jugadas, cantJugadas, bolillero);
        }
        public long simularConHilos(List<byte> jugadas, long cantJugadas, Bolillero bolillero, long cantHilos)
        {
            var vectorTarea = new Task<long>[cantHilos];
            long resto = cantJugadas % cantHilos;

            for (int i = 0; i < cantHilos; i++)
            {
                Bolillero clon = (Bolillero)bolillero.Clone();
                vectorTarea[i] = Task.Run(() => jugarNveces(jugadas, cantJugadas / cantHilos, clon));

            }
            Bolillero clon1 = (Bolillero)bolillero.Clone();
            vectorTarea[0] = Task.Run(() => jugarNveces(jugadas, cantJugadas / cantHilos + resto, clon1));
            Task.WaitAll(vectorTarea);
            return vectorTarea.Sum(T => T.Result);
        }
    }
}
