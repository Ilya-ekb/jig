using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] public GameObject TicketPrefab { get; private set; }
    [SerializeField] public Transform TicketPosition { get; private set; }

    private Player player;
    /*
     * передвижение
    */

    private void Start () {
        player = new Player (this.gameObject);
    }

    private void OnTriggerEnter2D (Collider2D collider) {
        // TODO Проверка на пассажира
        player.SetInTicket (true);
    }
    private void OnTriggerExit2D (Collider2D collision) {
        // TODO Проверка на пассажира
        player.SetInTicket (false);
    }

    public GameObject CreateTicket (GameObject ticketPrefab, Transform ticketPosition) {
        var ticket = Instantiate (ticketPrefab, ticketPosition.transform);
        return ticket;
    }
    public void DestroyTicket (GameObject ticket) {
        Destroy (ticket);
    }
}