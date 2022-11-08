using System;

/// <summary>
/// Бэкэнд логика Билета. Содержит дату и подлиность билета
/// Для проверки подлиности - CheckDate ()
/// </summary>
public class Ticket
{
    /// <summary>
    /// Дата билета для вывода в UI
    /// </summary>
    public DateTime ticketDate { get; private set; }
    private DateTime nowDate;

    /// <summary>
    /// Инициализирует билет (случайная и настоящие даты)
    /// Принимает ScriptableObject TicketSettings
    /// </summary>
    public Ticket (TicketSettings _settings) {
        ticketDate = randomDate (_settings.IncorrectDateProb, _settings.MaxDateDev);
        nowDate = DateTime.Now;
    }

    private DateTime randomDate (double incorrectProb, int maxDateDev) {
        Random rnd = new Random ();
        DateTime output;

        if (rnd.NextDouble () < incorrectProb)
            output = nowDate.AddDays (rnd.Next (-maxDateDev, maxDateDev));
        else
            output = nowDate;

        return output.Date;
    }

    /// <summary>
    /// Возвращает true, если билет настоящий
    /// </summary>
    public bool CheckDate ()
    {
        return ticketDate == nowDate;
    }
}