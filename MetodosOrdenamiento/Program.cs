using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MetodosOrdenamiento
{
    class Program
    {
        /*
                
    
*/
        static void Main(string[] args)
        {
            List<int> unsorted = new List<int>();
            List<int> sorted = new List<int>();

            Program pv = new Program();

            //se carga la ista desordenada
            unsorted = pv.Cargar();

            //se llaman los métodos de ordenamiento
            sorted = pv.BubbleSort(unsorted);
            pv.Imprimir(sorted, "Lista ordenada BubbleSort: ");

            sorted = pv.InsertionSort(unsorted);
            pv.Imprimir(sorted, "Lista ordenada InsertionSort: ");

            sorted = pv.SelectionSort(unsorted);
            pv.Imprimir(sorted, "Lista ordenada SelectionSort: ");

            sorted = pv.QuickSort(unsorted, 0, unsorted.Count()-1 );
            pv.Imprimir(sorted, "Lista ordenada QuickSort: ");

            sorted = pv.ShellSort(unsorted);
            pv.Imprimir(sorted, "Lista ordenada ShellSort: ");


        }

        public List<int> Cargar()
        {
            List<int> unsorted = new List<int>();
            Random random = new Random();

            Console.WriteLine("Original array elements:");
            for (int i = 0; i < 10; i++)
            {
                unsorted.Add(random.Next(0, 10000));
                Console.Write(unsorted[i] + " ");
            }
            Console.WriteLine();
            Console.Write("\n");

            return unsorted;            
        }

        public void Imprimir(List<int> sorted, string msg)
        {
            Console.WriteLine(msg);
            foreach (var item in sorted)
            {
                Console.Write(item + ", ");
            }
            Console.WriteLine("\n");
            Console.ReadKey();
        }

        //<Summary><c>Bubble sort</c>
        //recorre una lista intercambiando las veces que sea necesaria la posición de un elemento por uno de menor categoría, de esta manera,
        //se ubica justo después de una menor categoría y antes de una mayor. <Summary>
        //<returns>A list ordered by this method</returns>
        public List<int> BubbleSort(List<int> unsorted)
        {
            int t;
            for (int a = 1; a < unsorted.Count; a++)
                for (int b = unsorted.Count - 1; b >= a; b--)
                {
                    if (unsorted[b - 1] > unsorted[b])
                    {
                        t = unsorted[b - 1];
                        unsorted[b - 1] = unsorted[b];
                        unsorted[b] = t;
                    }
                }
            return unsorted;
        }

        //<Summary><c>Insertion sort</c>
        //Toma cada elemento de una lista y realiza comparaciones a su izquierda y a su derecha, hasta encontrar su posición definitiva,
        //guardando siempre la anterior posición y la siguiente posición para no quedarse sin asignar.</Summary>
        //<returns>A list ordered by this method</returns>
        public List<int> InsertionSort(List<int> unsorted)
        {
            int auxili;
            int j;
            for (int i = 0; i < unsorted.Count; i++)
            {
                auxili = unsorted[i];
                j = i - 1;
                while (j >= 0 && unsorted[j] > auxili)
                {
                    unsorted[j + 1] = unsorted[j];
                    j--;
                }
                unsorted[j + 1] = auxili;
            }

            return unsorted;
        }

        //<summary><c>Selection sort</c>
        //Consiste en encontrar el menor elemento de la lista y ubicarlo en la primera posición, luego el segundo y así sucesivamente,
        //todo intercambiando un elemento a la vez.
        //</summary>
        //<returns>A list ordered by this method</returns>
        //<param>List<int> unsorted</param>
        public List<int> SelectionSort(List<int> unsorted)
        {
            //pos_min is short for position of min
            int pos_min, temp;

            for (int i = 0; i < unsorted.Count - 1; i++)
            {
                pos_min = i;//set pos_min to the current index of array

                for (int j = i + 1; j < unsorted.Count; j++)
                {
                    if (unsorted[j] < unsorted[pos_min])
                    {
                        //pos_min will keep track of the index that min is in, this is needed when a swap happens
                        pos_min = j;
                    }
                }

                //if pos_min no longer equals i than a smaller value must have been found, so a swap must occur
                if (pos_min != i)
                {
                    temp = unsorted[i];
                    unsorted[i] = unsorted[pos_min];
                    unsorted[pos_min] = temp;
                }
            }
            return unsorted;
        }

        //<Summary><c>Quicksort</c>
        //Se basa en el antiguo lema de “divide y vencerás”, y que separa los elementos de una lista en 3 partes con base en un elemento
        //de la misma, es decir, se elije un elemento de la lista y con base en este se sacan las otras dos listas, dicho elemento contendrá en su
        //lista solo los elementos iguales a el, la primera lista, contendrá los elementos menores, y la tercera lista, contendrá los elementos mayores.
        //De esta manera, se obtiene una separación de datos y cada lista aplicará el mismo procedimiento recursivamente hasta que cada sub-lista
        //no tenga más de un elemento.</Summary>
        //<returns>A list ordered by this method</returns>
        private List<int> QuickSort(List<int> unsorted, int primero, int ultimo)
        {
            int i, j, central;
            double pivote;
            central = (primero + ultimo) / 2;
            pivote = unsorted[central];
            i = primero;
            j = ultimo;
            do
            {
                while (unsorted[i] < pivote) i++;
                while (unsorted[j] > pivote) j--;
                if (i <= j)
                {
                    int temp;
                    temp = unsorted[i];
                    unsorted[i] = unsorted[j];
                    unsorted[j] = temp;
                    i++;
                    j--;
                }
            } while (i <= j);

            if (primero < j)
            {
                QuickSort(unsorted, primero, j);
            }
            if (i < ultimo)
            {
                QuickSort(unsorted, i, ultimo);
            }

            return unsorted;
        }

        //<Summary><c>Shellsort</c>
        //Es una mejora del algoritmo de ordenación por inserción ya que compara los elementos por un espacio más grande y no solo de
        //una posición, esto permite que un elemento se acerque más a su posición final de manera mas pronta, y a medida que avanza, los espacios de
        //comparación se van haciendo más pequeños, y al final, se hace el ordenamiento por inserción, pero dado que prácticamente se ha garantizado
        //que los datos están ordenados, es poco lo que “trabaja” este último algoritmo.</Summary>
        //<returns>A list ordered by this method</returns>
        public List<int> ShellSort(List<int> unsorted)
        {
            int salto = 0;
            int sw = 0;
            int auxi = 0;
            int e = 0;
            salto = unsorted.Count / 2;
            while (salto > 0)
            {
                sw = 1;
                while (sw != 0)
                {
                    sw = 0;
                    e = 1;
                    while (e <= (unsorted.Count - salto))
                    {
                        if (unsorted[e - 1] > unsorted[(e - 1) + salto])
                        {
                            auxi = unsorted[(e - 1) + salto];
                            unsorted[(e - 1) + salto] = unsorted[e - 1];
                            unsorted[(e - 1)] = auxi;
                            sw = 1;
                        }
                        e++;
                    }
                }
                salto = salto / 2;
            }

            return unsorted;
        }

        //<Summary><c>Merge sort</c>
        //al igual que el Quicksort, se basa en dividir la lista de elementos en dos listas mas pequeñas, en lo posible, del mismo tamaño, 
        //y si la longitud de la lista es 0 o 1, la ista ya quedaría ordenada, y allí se mezclaría con las demás listas y se aplicaría nuevamente el algortimo.
        //Conceptualmente, el algoritmo funciona de la siguiente manera:
        //1. Si la longitud de la lista es 0 ó 1, entonces ya está ordenada. En otro caso:
        //2. Dividir la lista desordenada en dos sublistas de aproximadamente la mitad del tamaño.
        //3. Ordenar cada sublista recursivamente aplicando el ordenamiento por mezcla.
        //4. Mezclarlas dos sublistas en una sola lista ordenada.
        //</Summary>
        //<returns>A list ordered by this method</returns>


    }
}
