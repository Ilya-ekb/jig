using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Passanger closestPassanger;

    //TODO:MOVEMENT
    private void Move()
    {
        
    }

    public bool checkTicket()
    {
        return closestPassanger.GetTicket().ticketDate == System.DateTime.Now;
    }
}