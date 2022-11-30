using System;

public class Passanger
{
    private Ticket _passangerTicket;

    /// <summary>
    /// Состояния пассажира
    /// </summary>
    public enum PassangerStates {sitting, goingToSit, goingToExit, idleWalking};

    public PassangerStates PassangerState;

    private int GetStateCount()
    {
        return Enum.GetNames(typeof(PassangerStates)).Length;
    }

    public Passanger(PassangerStates state, TicketSettings TSs)
    {
        _passangerTicket = TicketMaster.CreateTicket(TSs);
        PassangerState = state;
    }

    /// <summary>
    /// Получить билет пассажира
    /// </summary>
    public Ticket GetTicket()
    {
        return _passangerTicket;
    }
}
