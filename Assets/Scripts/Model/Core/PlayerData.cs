using UnityEngine;

/// <summary>
/// ����� ����� � ������� ���������
/// </summary>
public class PlayerData
{
    private GameObject ticket; // ������ �� �������� ������ ������
    private GameObject playerObject;
    private PlayerController playerController; // ������ �� ���������� ������

    /// <summary>
    /// ����������� ������ ��� ��������� ������ �� ����������
    /// </summary>
    /// <param name="_playerObject"></param>
    public PlayerData () {
        
    }
    public void CreatePlayer (GameObject _playerObject) {
        playerObject = _playerObject;
        playerController = _playerObject.GetComponent<PlayerController> ();
    }

    /// <summary>
    /// ��������� ������ (����� ���������/���) true, ���� ����� ����� � ���������, false, ���� ���. ��������� � UI ����� ������� OnTicketButtoClick
    /// </summary>
    public bool InTicket { get; private set; }
    /// <summary>
    /// ����� ��� ����� ��������� ������ (����� ���������/���)
    /// </summary>
    /// <param name="_inTicket"></param>
    public void SetInTicket (bool _inTicket) {
        InTicket = _inTicket;
        if (InTicket)
            return;
        playerController.DestroyTicket (ticket);
    }
    /// <summary>
    /// ����� ������� ������ ������ �������� ������. ���������� �� UI ��� ������� ������ �������� ������. (����� ������� ��������� inTicket!)
    /// </summary>
    public void OnTicketButtonClick () {
        if (!InTicket)
            return;
        ticket = playerController.CreateTicket (playerController.TicketPrefab, playerController.TicketPosition);
    }

    public CameraFollower GetCameraFollower () {
        return playerObject.GetComponent<CameraFollower> ();
    } 
}