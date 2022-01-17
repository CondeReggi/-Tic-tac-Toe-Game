using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    internal class Program
    {
        //Creamos el tablero 3x3

        static int[,] tablero = new int[3, 3]; // Con la , creamos un array bidimencional

        //Creamos los simbolos del tablero (Espacios en blanco, 0, X)

        static char[] simbolo = { ' ', 'O', 'X' };
        static void Main(string[] args)
        {
            DibujarTablero();

            Console.WriteLine("Jugador 1 = 0 | Jugador 2 = X");

            do
            {
                asignarPosicion(1);
                DibujarTablero();

                if ( comprobarGanador())
                {
                    Console.WriteLine("El jugador 1 ha GANADO!");
                }
                else
                {
                    if( comprobarEmpate())
                    {
                        Console.WriteLine("Ha empatado");
                    }
                    else
                    {
                        asignarPosicion(2);
                        DibujarTablero();

                        if (comprobarGanador())
                        {
                            Console.WriteLine("El jugador 2 ha GANADO!");
                        }
                    }
                }
                     
            } while (comprobarEmpate() || !comprobarGanador());
        }

        static void DibujarTablero ()
        {
            Console.Clear();    
            Console.WriteLine();
            // *---*---*---*
            // |   |   |   |
            // *---*---*---*
            // |   |   |   |
            // *---*---*---*
            // |   |   |   |
            // *---*---*---*
            Console.WriteLine("*---*---*---*");    

            for (int i = 0; i < 3; i++) //Filas *---*---*---*
            {
                Console.Write("|");
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(" {0} |", simbolo[tablero[i, j]]);
                }
                Console.WriteLine("");
                Console.WriteLine("*---*---*---*");
            }
            
        }

        static void asignarPosicion( int jugador )
        {
            try
            {
                int fila, columna;

                do
                {
                    do
                    {
                        Console.WriteLine("Ingrese la fila");
                        fila = Convert.ToInt32(Console.ReadLine());

                    } while ((fila > 3 || fila < 1));

                    do
                    {
                        Console.WriteLine("Ingrese la columna");
                        columna = Convert.ToInt32(Console.ReadLine());

                    } while ((columna > 3 || columna < 0));

                    if (tablero[fila - 1, columna - 1] != 0)
                    {
                        Console.WriteLine("Casilla Ocupada!");
                    }
                } while (tablero[fila - 1, columna - 1] != 0);

                tablero[fila - 1, columna - 1] = jugador;
            } catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());   
            }
        }

        static bool comprobarGanador()
        {
            int fila = 0, columna = 0;
            bool tateti = false;    

            for (fila = 0; fila < 3; fila++)
            {
                if (tablero[fila, 0] != 0 && tablero[fila, 0] == tablero[fila, 1] && tablero[fila, 1] == tablero[fila, 2]) {
                    tateti = true;
                }
            }

            for (columna = 0; columna < 3; columna++)
            {
                if (tablero[0, columna] != 0 && tablero[0, columna] == tablero[1, columna] && tablero[1, columna] == tablero[2, columna])
                {
                    tateti = true;
                }
            }

            if ( tablero[0,0] == tablero[1,1] && tablero[1,1] == tablero[2,2] && tablero[0, 0] != 0)
            {
                tateti = true;
            }

            if ( tablero[0,2] == tablero[1,1] && tablero[0,2] == tablero[2,0] && tablero[0, 2] != 0)
            {
                tateti = true;
            }

            return tateti;
        }

        static bool comprobarEmpate() {
            bool hayEspacio = false;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if ( tablero[i,j] == 0)
                    {
                        hayEspacio = true;
                    }
                }
            }

            return !hayEspacio;
        }        
    }
}
