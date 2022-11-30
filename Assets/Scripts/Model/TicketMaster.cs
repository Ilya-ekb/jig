using System;
using System.Collections.Generic;

public static class TicketMaster
{
    private static List<Ticket> Tickets = new List<Ticket>();


    public static Ticket CreateTicket(TicketSettings TSs)
    {
        Ticket ticketTemp = new Ticket(randomDate(TSs.IncorrectDateProb, TSs.MaxDateDev));
        Tickets.Add(ticketTemp);
        return ticketTemp;
    }


    private static DateTime randomDate(double incorrectProb, int maxDateDev)
    {
        Random rnd = new Random();
        DateTime output;

        if (rnd.NextDouble() < incorrectProb)
            output = DateTime.Now.AddDays(rnd.Next(-maxDateDev, maxDateDev));
        else
            output = DateTime.Now;

        return output.Date;
    }
}
