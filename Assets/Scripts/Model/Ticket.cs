using System;

/// <summary>
/// Бэкэнд логика Билета. Содержит дату и подлиность билета
/// </summary>
public class Ticket
{
    /// <summary>
    /// Дата билета для вывода в UI
    /// </summary>
    public DateTime ticketDate { get; private set; }

    /// <summary>
    /// Инициализирует билет (случайная и настоящие даты)
    /// Принимает DateTime
    /// </summary>    
    public Ticket (DateTime ticketTempDate) {
        ticketDate = ticketTempDate;
    }
}