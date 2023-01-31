using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassengerMaster : MonoBehaviour
{
    [SerializeField] GameObject passenger;

    [SerializeField] Transform passengerCreationPoint;

    private static List<GameObject> passengers = new List<GameObject>();

    //Проверка на работоспособность
    private void Start()
    {
        CreatePassengers(5, Passanger.PassangerStates.GoingToSit);
    }


    public void CreatePassengers(int amount, Passanger.PassangerStates startingState)
    {
        for (int i = 0; i < amount; i++)
        {
            GameObject passengerTemp = Instantiate(passenger, passengerCreationPoint.position, Quaternion.identity);
            passengerTemp.GetComponent<PassangerController>().Initialize();
            passengerTemp.GetComponent<PassangerController>().ChangePassangerState(startingState);
            passengers.Add(passengerTemp);
        }
    }
}
