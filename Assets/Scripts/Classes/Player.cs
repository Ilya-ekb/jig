using UnityEngine;

/// <summary>
/// ����� ����� � ������� ���������
/// </summary>
public class Player
{
    private GameObject ticket; // ������ �� �������� ������ ������
    private PlayerController playerController; // ������ �� ���������� ������

    /// <summary>
    /// ����������� ������ ��� ��������� ������ �� ����������
    /// </summary>
    /// <param name="_playerObject"></param>
    public Player (GameObject _playerObject) {
        playerController = _playerObject.GetComponent<PlayerController> ();
    }

    /// <summary>
    /// ��������� ������ (����� ���������/���) true, ���� ����� ����� � ���������, false, ���� ���. ��������� � UI ����� ������� OnTicketButtoClick
    /// </summary>
    public bool inTicket { get; private set; }
    /// <summary>
    /// ����� ��� ����� ��������� ������ (����� ���������/���)
    /// </summary>
    /// <param name="_inTicket"></param>
    public void SetInTicket (bool _inTicket) {
        inTicket = _inTicket;
        if (inTicket)
            return;
        playerController.DestroyTicket (ticket);
    }

    /// <summary>
    /// ����� ������� ������ ������ �������� ������. ���������� �� UI ��� ������� ������ �������� ������. (����� ������� ��������� inTicket!)
    /// </summary>
    public void OnTicketButtonClick () {
        if (!inTicket)
            return;
        ticket = playerController.CreateTicket (playerController.TicketPrefab, playerController.TicketPosition);
    }
}