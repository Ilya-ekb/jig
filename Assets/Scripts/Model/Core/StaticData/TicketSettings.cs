using UnityEngine;

public class TicketSettings : ScriptableObject
{
    /// <summary>
    /// Вероятность того, что билет будет фальшивым
    /// </summary>
    [SerializeField] private double incorrectDateProb;

    /// <summary>
    /// Если билет фальшивый, его дата будет случайной и отличной от настоящей
    /// на случайное количество дней от -maxDateDev до maxDateDev
    /// </summary>
    [SerializeField] private int maxDateDev;

    public double IncorrectDateProb
    {
        get
        {
            return incorrectDateProb;
        }
    }
    public int MaxDateDev
    {
        get
        {
            return maxDateDev;
        }
    }
}