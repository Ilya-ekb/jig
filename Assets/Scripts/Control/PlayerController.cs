using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public TriggerProxy TriggerScript;

    List<GameObject> passengers = new List<GameObject>();


    private void Start()
    {
        // временное решение
        Initialize();
    }

    private void Initialize()
    {
        TriggerScript.TriggerEntered.AddListener(TicketTriggerEntered);
        TriggerScript.TriggerExited.AddListener(TicketTriggerExited);
    }

    //TODO:MOVEMENT
    private void Move()
    {

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            //заменить на действия при проверке билета
            print(checkPassengers());
        }
    }

    public bool checkPassengers()
    {
        GameObject closestPassenger = null;
        float closestDistance = Mathf.Infinity;

        for (int i = 0; i < passengers.Count; i++)
        {
            if (Vector3.Distance(transform.position, passengers[i].transform.position) < closestDistance)
            {
                if (!passengers[i].GetComponent<PassangerController>())
                {
                    continue;
                }
                if (passengers[i].GetComponent<PassangerController>().MyPassanger == null)
                {
                    continue;
                }

                closestPassenger = passengers[i];
                closestDistance = Vector3.Distance(transform.position, passengers[i].transform.position);
            }
        }

        if (closestPassenger == null)
        {
            return false;
        }

        return checkTicket(closestPassenger.GetComponent<PassangerController>().MyPassanger);
    }

    public void TicketTriggerEntered(Collider collider)
    {

        if (!collider.gameObject.CompareTag("Passenger"))
        {
            return;
        }

        if (collider.gameObject == null)
        {
            return;
        }


        bool found = false;

        for (int i = 0; i < passengers.Count; i++)
        {
            if (collider.gameObject == passengers[i])
            {
                found = true;
                break;
            }
        }

        if (found)
        {
            return;
        }

        passengers.Add(collider.gameObject);
    }
    public void TicketTriggerExited(Collider collider)
    {
        if (!collider.gameObject.CompareTag("Passenger"))
        {
            return;
        }

        if (!collider.GetComponent<PassangerController>())
        {
            return;
        }

        Passanger passengerTemp = collider.GetComponent<PassangerController>().MyPassanger;

        if (passengerTemp == null)
        {
            return;
        }


        bool found = false;

        for (int i = 0; i < passengers.Count; i++)
        {
            if (collider.gameObject == passengers[i])
            {
                found = true;
                break;
            }
        }

        if (!found)
        {
            return;
        }

        passengers.Remove(collider.gameObject);
    }

    public bool checkTicket(Passanger passengerToCheck)
    {
        return passengerToCheck.GetTicket().ticketDate.Date == System.DateTime.Today;
    }
}