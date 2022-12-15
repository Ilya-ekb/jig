using System;

public class Passanger
{
    private Ticket MyTicket;

    /// <summary>
    /// Состояния пассажира
    /// </summary>
    public enum PassangerStates {Sitting, GoingToSit, GoingToExit, IdleWalking};
    public PassangerStates PassangerState;

    public int GetStateCount() => Enum.GetNames(typeof(PassangerStates)).Length;

    public Passanger(PassangerStates state, TicketSettings TSs)
    {
        MyTicket = TicketMaster.CreateTicket(TSs);
        PassangerState = state;
    }

    /// <summary>
    /// Получить билет пассажира
    /// </summary>
    public Ticket GetTicket() => MyTicket;
}