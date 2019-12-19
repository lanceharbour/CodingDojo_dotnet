using System;
using System.Collections.Generic;

namespace IronNinja
{

    class Program
    {
        static void Main(string[] args)
        {
            Buffet mybuffet = new Buffet();
            SweetTooth N1 = new SweetTooth();
            SpiceHound N2 = new SpiceHound();
            N1.Consume(mybuffet.Serve());
            N1.Consume(mybuffet.Serve());
            // while (!N1.IsFull)
            // {
            //     N1.Consume(mybuffet.Serve());
            // }
            // while (!N2.IsFull)
            // {
            //     N2.Consume(mybuffet.Serve());
            // }
        }
    }
}
