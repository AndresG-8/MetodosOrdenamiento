# MetodosOrdenamiento
Diferentes métodos de ordenamiento con base en entrada random de datos tipo entero

Bubble sort: También conocido como Ordenamiento burbuja, recorre una lista intercambiando las veces que sea necesaria la posición de un elemento por uno de menor categoría, de esta manera, se ubica justo después de una menor categoría y antes de una mayor.

Insertion sort: Toma cada elemento de una lista y realiza comparaciones a su izquierda y a su derecha, hasta encontrar su posición definitiva, guardando siempre la anterior posición yla siguiente posición para no quedarse sin asignar.

Selection sort: Consiste en encontrar el menor elemento de la lista y ubicarlo en la primera posición, luego el segundo y así sucesivamente, todo intercambiando un elemento a la vez.

Quicksort: Se basa en el antiguo lema de “divide y vencerás”, y que separa los elementos de una lista en 3 partes con base en un elemento de la misma, es decir, se elije un elemento de la lista y con base en este se sacan las otras dos listas, dicho elemento contendrá en su lista solo los elementos iguales a el, la primera lista, contendrá los elementos menores, y la tercera lista, contendrá los elementos mayores. De esta manera, se obtiene una separación de datos y cada lista aplicará el mismo procedimiento recursivamente hasta que cada sub-lista no tenga más de un elemento.

Shellsort: Es una mejora del algoritmo de ordenación por inserción ya que compara los elementos por un espacio más grande y no solo de una posición, esto permite que un elemento se acerque más a su posición final de manera mas pronta, y a medida que avanza, los espacios de comparación se van haciendo más pequeños, y al final, se hace el ordenamiento por inserción, pero dado que prácticamente se ha garantizado que los datos están ordenados, es poco lo que “trabaja” este último algoritmo.

Merge sort: al igual que el Quicksort, se basa en dividir la lista de elementos en dos listas mas pequeñas, en lo posible, del mismo tamaño, y si la longitud de la lista es 0 o 1, la ista ya quedaría ordenada, y allí se mezclaría con las demás listas y se aplicaría nuevamente el algortimo.
Conceptualmente, el algoritmo funciona de la siguiente manera:
1.	Si la longitud de la lista es 0 ó 1, entonces ya está ordenada. En otro caso:
2.	Dividir la lista desordenada en dos sublistas de aproximadamente la mitad del tamaño.
3.	Ordenar cada sublista recursivamente aplicando el ordenamiento por mezcla.
4.	Mezclar las dos sublistas en una sola lista ordenada.
