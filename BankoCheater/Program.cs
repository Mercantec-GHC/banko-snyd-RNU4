using System;

public struct Plade
{
    public bool plade_banko = false;
    public string name = "none";
    public bool[] bingo_list = new bool[3]{false,false,false};

    public int[,] bankoplade;
    public bool[,] bankoplade_bool;

    
    public Plade(int[,] bankoplade,string name)
    {
        this.bankoplade = bankoplade;
        this.name = name;
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

    public void check_plate()
    {
        if (this.plade_banko==true) return; // already banko no need to check again

        bool banko = true;
        for (int i = 0; i < this.bankoplade.GetLength(0); i++)
        {
            if (bingo_list[i] == false){
                bingo_list[i] = true;
                for (int j = 0; j < this.bankoplade.GetLength(1); j++)
                {
                    if (this.bankoplade_bool[i, j] == false){
                        bingo_list[i] = false;
                        banko = false;
                    }
                }
                

                if (bingo_list[i] == true){ // full line
                    Console.WriteLine("BINGO! på plade "+this.name+" På linje "+(i+1));
                }
            }
        }
        if (banko == true){
            Console.WriteLine("Banko! på plade "+this.name);
            this.plade_banko = true;
        }
    }

}


class Program
{
    static void Main(string[] args)
    {

        Plade[] plade_array = new Plade[2];

        plade_array[0] = new Plade(new int[,]
        {
            {1, 20, 33, 43, 53, 69, 71, 87},
            {5, 23, 37, 48, 59, 67, 73, 88},
            {9, 29, 31, 46, 52, 64, 76, 90}
        },"malthe1");

        plade_array[1] = new Plade(new int[,]
        {
            {1, 20, 33, 43, 53, 69, 71, 87},
            {5, 23, 37, 48, 59, 67, 73, 88},
            {9, 29, 31, 46, 52, 64, 76, 90}
        },"malthe2");
        

        // get a number from the user
        while(true){
        Console.WriteLine("Enter number:");
        string userstring = "";
        try {userstring = Console.ReadLine();} catch {
            Console.WriteLine("console error");
        }
        if (userstring=="exit") return;
        if (int.TryParse(userstring, out int number))
        {
            // give number and check plate
        for (int i = 0; i < plade_array.Length; i++){
            plade_array[i].called_number(number);
            plade_array[i].check_plate();
        }
        }
        else
        {
            Console.WriteLine("Not a number");
        }
        }
        
/*
        Console.WriteLine("bankoplade array:");
        for (int t = 0;  t < plade_array.Length; t++){
        for (int i = 0; i < plade_array[t].bankoplade.GetLength(0); i++)
        {
            for (int j = 0; j < plade_array[t].bankoplade.GetLength(1); j++)
            {
                Console.Write(plade_array[t].bankoplade[i, j] + ":" + plade_array[t].bankoplade_bool[i, j] + " ");
            }
            Console.WriteLine();
        }
        Console.WriteLine();

        }*/
    }
}
