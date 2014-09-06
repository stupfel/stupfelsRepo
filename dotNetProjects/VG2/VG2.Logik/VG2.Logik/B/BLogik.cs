using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VG2.Logik.B.Vierer;

namespace VG2.Logik.B
{
    class BLogik
    {
        internal static IEnumerable<IVierer> AlleVierer(this int[,] feld)
        {
            // Horizontale Vierer
            for (var x = 0; x <= feld.GetLength(0) - 4; x++)
            {
                for (var y = 0; y < feld.GetLength(1); y++)
                {
                    yield return new HorizontalerVierer(x, y);
                }
            }

            // Vertikale Vierer
            for (var x = 0; x <= feld.GetLength(0) - 4; x++)
            {
                for (var y = 0; y < feld.GetLength(1); y++)
                {
                    yield return new VertikalerVierer(x, y);
                }
            }

            // DiagonalHoch Vierer
            for (var x = 0; x <= feld.GetLength(0) - 4; x++)
            {
                for (var y = 0; y < feld.GetLength(1); y++)
                {
                    yield return new DiagonallHochVierer(x, y);
                }
            }

            // DiagonalRunter Vierer
            for (var x = 0; x <= feld.GetLength(0) - 4; x++)
            {
                for (var y = 0; y < feld.GetLength(1); y++)
                {
                    yield return new DiagonallRunterVierer(x, y);
                }
            }
        }
    
        internal static IEnumerable<IVierer> SelbeFarbe(this IEnumerable<IVierer> vierer, int[,] feld)
        {
            foreach(var vier in vierer)
            {
                if ((feld[vier.Eins.X, vier.Eins.Y] != 0) &&
                    (feld[vier.Eins.X, vier.Eins.Y] == feld[vier.Zwei.X, vier.Zwei.Y]) &&
                    (feld[vier.Eins.X, vier.Eins.Y] == feld[vier.Drei.X, vier.Drei.Y]) &&
                    (feld[vier.Eins.X, vier.Eins.Y] == feld[vier.Vier.X, vier.Vier.Y]))
                {
                    yield return vier;
                }
            }
        }
    }
}
