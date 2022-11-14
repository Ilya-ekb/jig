using UnityEngine;

/// <summary>
/// Класс игрок с логикой поведения
/// </summary>
public class PlayerData
{
    private GameObject ticket; // Ссылка на созданый объект билета
    private GameObject playerObject;
    private PlayerController playerController; // Ссылка на контроллер игрока

    /// <summary>
    /// Конструктор класса для получения ссылки на контроллер
    /// </summary>
    /// <param name="_playerObject"></param>
    public PlayerData () {
        
    }
    public void CreatePlayer (GameObject _playerObject) {
        playerObject = _playerObject;
        playerController = _playerObject.GetComponent<PlayerController> ();
    }

    /// <summary>
    /// Состояние игрока (около пассажира/нет) true, если игрок стоит у пассажира, false, если нет. Проверить в UI перед вызовом OnTicketButtoClick
    /// </summary>
    public bool InTicket { get; private set; }
    /// <summary>
    /// Метод для смены состояния игрока (около пассажира/нет)
    /// </summary>
    /// <param name="_inTicket"></param>
    public void SetInTicket (bool _inTicket) {
        InTicket = _inTicket;
        if (InTicket)
            return;
        playerController.DestroyTicket (ticket);
    }
    /// <summary>
    /// Метод нажатия кнопки начала проверки билета. Вызывается из UI при нажатии кнопки проверки билета. (Перед вызовом проверить inTicket!)
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