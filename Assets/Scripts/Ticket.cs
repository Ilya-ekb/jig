using System.Collections; 
using System.Collections.Generic; 
using UnityEngine; 
 
public class Ticket : MonoBehaviour 
{
    private DateTime TicketDate;

    private DateTime RandomDate ()  
    { 
        DateTime start = new DateTime (2022, 10, 1); // Минимальная дата билета 
        int range = (DateTime.Today - start).Days + 1; 

        DateTime output = start.AddDays (0, range); 
        Console.WriteLine (output); 
        return output; 
    } 

    public bool CheckDate () //проверка совпадают ли даты 
    { 
        DateTime rd = RandomDay ().Date; 
        DateTime n = DateTime.Now.Date; 
        
        return rd == n;  
    }

    public void InitializeTicket (){
        TicketDate = RandomDay ();
    }
}