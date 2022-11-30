using UnityEngine;

public class PassangerController : MonoBehaviour
{
    Passanger passanger;

    [SerializeField] private TicketSettings ticketSettings;

    public void Initialize () {
        passanger = new Passanger(Passanger.PassangerStates.goingToSit, ticketSettings);
    }


    public void ExitFromTrain()
    {
        passanger.PassangerState = Passanger.PassangerStates.goingToExit;
        //TODO: Exit Logic
    }
}