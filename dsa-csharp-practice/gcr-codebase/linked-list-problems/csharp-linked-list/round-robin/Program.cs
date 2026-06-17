class Program
{
    static void Main()
    {
        RoundRobinScheduler sched=new RoundRobinScheduler(4);

        sched.enqueue(1,8,1);
        sched.enqueue(2,6,2);
        sched.enqueue(3,4,1);
        sched.enqueue(4,5,3);

        sched.display();
        sched.simulate();
    }
}
