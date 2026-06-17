class Controller
{
    private int[] priceData;
    private CutSolver solver;

    public Controller()
    {
        priceData=new int[]{1,5,8,9,10,17,17,20};
        solver=new CutSolver(priceData);
    }

    public void executeA()
    {
        int length=8;
        int value=solver.calculate(length);
        Console.WriteLine("scenario a");
        Console.WriteLine($"rod length:{length}");
        Console.WriteLine($"maximum revenue:{value}");
        solver.display(length);
        Console.WriteLine();
    }

    public void executeB()
    {
        int[] updated=new int[priceData.Length+3];
        for(int i=0;i<priceData.Length;i++)
        {
            updated[i]=priceData[i];
        }
        updated[8]=24;
        updated[9]=26;
        updated[10]=28;

        CutSolver newSolver=new CutSolver(updated);

        int oldValue=solver.calculate(8);
        int newValue=newSolver.calculate(8);

        Console.WriteLine("scenario b");
        Console.WriteLine($"old revenue:{oldValue}");
        Console.WriteLine($"new revenue:{newValue}");
        Console.WriteLine($"difference:{(newValue-oldValue)}");
        newSolver.display(8);
        Console.WriteLine();
    }
    public void executeC()
    {
        int length=8;
        int optimal=solver.calculate(length);

        Console.WriteLine("scenario c");
        Console.WriteLine("optimal revenue:"+optimal);

        int case1=priceData[3]+priceData[3];
        Console.WriteLine($"cut 4+4 revenue:{case1}");
        Console.WriteLine($"loss:{(optimal-case1)}");

        int case2=priceData[4]+priceData[2];
        Console.WriteLine($"cut 5+3 revenue:{case2}");
        Console.WriteLine($"loss:{(optimal-case2)}");

        int case3=0;
        for(int i=0;i<length;i++)
        {
            case3=case3+priceData[0];
        }
        Console.WriteLine($"all single cuts revenue:{case3}");
        Console.WriteLine($"loss:{(optimal-case3)}");
        Console.WriteLine();
    }
}