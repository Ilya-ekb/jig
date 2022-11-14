using UnityEngine;

public class TicketSettings : ScriptableObject
{
    /// <summary>
    /// ����������� ����, ��� ����� ����� ���������
    /// </summary>
    [SerializeField] private double incorrectDateProb;

    /// <summary>
    /// ���� ����� ���������, ��� ���� ����� ��������� � �������� �� ���������
    /// �� ��������� ���������� ���� �� -maxDateDev �� maxDateDev
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