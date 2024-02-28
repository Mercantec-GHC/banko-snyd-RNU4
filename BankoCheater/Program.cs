using System;

public struct Plade
{
    public int[,] bankoplade;
    public bool[,] bankoplade_bool;

    public Plade(int[,] bankoplade)
    {
        this.bankoplade = bankoplade;
        this.bankoplade_bool = new bool[,]
        {
            {false, false, false, false, false, false, false, false},
            {false, false, false, false, false, false, false, false},
            {false, false, false, false, false, false, false, false}
        };
    }

    public void called_number(int x)
    {
        for (int i = 0; i < this.bankoplade.GetLength(0); i++)
        {
            for (int j = 0; j < this.bankoplade.GetLength(1); j++)
            {
                if (this.bankoplade[i, j] == x)
                    this.bankoplade_bool[i, j] = true;
            }
        }
    }

}


class Program
{
    static void Main(string[] args)
    {
        Plade plade = new Plade(new int[,]
        {
            {1, 20, 33, 43, 53, 69, 71, 87},
            {5, 23, 37, 48, 59, 67, 73, 88},
            {9, 29, 31, 46, 52, 64, 76, 90}
        });
        plade.called_number(20);
        Console.WriteLine("bankoplade array:");
        for (int i = 0; i < plade.bankoplade.GetLength(0); i++)
        {
            for (int j = 0; j < plade.bankoplade.GetLength(1); j++)
            {
                Console.Write(plade.bankoplade[i, j] + ":" + plade.bankoplade_bool[i, j] + " ");
            }
            Console.WriteLine();
        }

        Console.WriteLine("Hello, World!");
    }
}
