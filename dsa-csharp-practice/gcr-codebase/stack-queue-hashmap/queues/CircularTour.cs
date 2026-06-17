using System;
using System.Collections.Generic;

    public class CircularTour
    {
        public class Pump
        {
            public int fuel;
            public int dist;

            public Pump(int f,int d)
            {
                fuel=f;
                dist=d;
            }
        }

        public static int FindStart(Pump[] pumps)
        {
            if(pumps.Length==0)
                return -1;

            int start=0;
            int balance=0;

            for(int i=0;i<pumps.Length;i++)
            {
                balance+=pumps[i].fuel-pumps[i].dist;
                if(balance<0)
                {
                    balance=0;
                    start=i+1;
                }
            }

            balance=0;
            for(int i=0;i<pumps.Length;i++)
            {
                balance+=pumps[i].fuel-pumps[i].dist;
                if(balance<0)
                    return -1;
            }

            return start;
        }
    }

