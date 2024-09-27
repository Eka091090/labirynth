using System.Collections;

namespace lesson3;

class Program
{
    static void Main(string[] args)
    {
        Stack<Tuple<int,int>> path = new Stack<Tuple<int,int>>();
        
        int[,] labirynth1 = new int[,]
        {
        {1, 1, 1, 1, 1, 1, 1 },
        {1, 0, 0, 0, 0, 0, 1 },
        {1, 0, 1, 1, 1, 0, 1 },
        {2, 0, 0, 0, 1, 0, 2 },
        {1, 1, 0, 0, 1, 1, 1 },
        {1, 1, 1, 0, 1, 1, 1 },
        {1, 1, 1, 2, 1, 1, 1 }
        };

        HasExit(3, 3, labirynth1);

        int HasExit(int i, int j, int[,] l)
        {
            int exit = 0;
            if(labirynth1[i, j] == 0)
                path.Push(new (i, j));

            while(path.Count > 0)
            {   

                var current = path.Pop();

                if(labirynth1[current.Item1,current.Item2] == 2)
                        exit++;

                labirynth1[current.Item1, current.Item2] = 1;

                if( current.Item1 + 1 < labirynth1.GetLength(0) && labirynth1[current.Item1 + 1, current.Item2] != 1) 
                    path.Push(new(current.Item1 + 1, current.Item2));
                    
                if( current.Item2 + 1 < labirynth1.GetLength(1) && labirynth1[current.Item1, current.Item2 + 1] != 1)
                    path.Push(new(current.Item1, current.Item2 + 1));

                if( current.Item1 > 0 && labirynth1[current.Item1 - 1, current.Item2] != 1 ) 
                    path.Push(new(current.Item1 - 1, current.Item2));

                if( current.Item2 > 0 && labirynth1[current.Item1, current.Item2 - 1] != 1 )
                    path.Push(new(current.Item1, current.Item2 - 1));    
            }

            System.Console.WriteLine($"Из лабиринта всего {exit} выхода.");
            return exit;
        }
    }
}

