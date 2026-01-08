public class RoundRobinScheduler
{
    private QueueNode front;
    private int quantum;

    public RoundRobinScheduler(int quantum)
    {
        front=null;
        this.quantum=quantum;
    }

    public void enqueue(int id,int duration,int rank)
    {
        QueueNode node=new QueueNode(id,duration,rank);
        if(front==null)
        {
            front=node;
            front.nextNode=front;
            Console.WriteLine("process added");
            return;
        }
        QueueNode last=front;
        while(last.nextNode!=front)
            last=last.nextNode;
        last.nextNode=node;
        node.nextNode=front;
        Console.WriteLine("process added to queue");
    }

    public void dequeue(int id)
    {
        if(front==null)
        {
            Console.WriteLine("queue is empty");
            return;
        }
        if(front.id==id)
        {
            if(front.nextNode==front)
            {
                front=null;
                Console.WriteLine("process removed");
                return;
            }
            QueueNode last=front;
            while(last.nextNode!=front)
                last=last.nextNode;
            last.nextNode=front.nextNode;
            front=front.nextNode;
            Console.WriteLine("process removed");
            return;
        }
        QueueNode pointer=front;
        do
        {
            if(pointer.nextNode.id==id)
            {
                pointer.nextNode=pointer.nextNode.nextNode;
                Console.WriteLine("process removed");
                return;
            }
            pointer=pointer.nextNode;
        }while(pointer.nextNode!=front);
        Console.WriteLine("process not found");
    }

    public void simulate()
    {
        if(front==null)
        {
            Console.WriteLine("queue is empty");
            return;
        }
        double waitSum=0;
        double turnaroundSum=0;
        int total=0;
        int elapsed=0;
        QueueNode pointer=front;

        do
        {
            total++;
            pointer=pointer.nextNode;
        }while(pointer!=front);

        pointer=front;
        int[] waitArray=new int[total];
        int[] turnaroundArray=new int[total];
        int idx=0;

        Console.WriteLine("\nround robin simulation");
        while(front!=null)
        {
            int execute=System.Math.Min(quantum,front.remaining);
            Console.WriteLine("process "+front.id+" executed for "+execute+" units");
            elapsed+=execute;
            front.remaining-=execute;

            if(front.remaining==0)
            {
                waitArray[idx]=elapsed-front.duration;
                turnaroundArray[idx]=elapsed;
                waitSum+=waitArray[idx];
                turnaroundSum+=turnaroundArray[idx];
                Console.WriteLine("process "+front.id+" completed at time "+elapsed);
                idx++;

                if(front.nextNode==front)
                {
                    front=null;
                    break;
                }
                QueueNode temp=front;
                QueueNode last=front;
                while(last.nextNode!=front)
                    last=last.nextNode;
                last.nextNode=front.nextNode;
                front=front.nextNode;
            }
            else
            {
                front=front.nextNode;
            }
        }

        Console.WriteLine("\naverage waiting time: "+(waitSum/total));
        Console.WriteLine("average turnaround time: "+(turnaroundSum/total));
    }

    public void display()
    {
        if(front==null)
        {
            Console.WriteLine("queue is empty");
            return;
        }
        QueueNode pointer=front;
        Console.WriteLine("\nprocesses in queue");
        do
        {
            Console.WriteLine("id: "+pointer.id+" | duration: "+pointer.duration+" | rank: "+pointer.rank+" | remaining: "+pointer.remaining);
            pointer=pointer.nextNode;
        }while(pointer!=front);
        Console.WriteLine();
    }
}
