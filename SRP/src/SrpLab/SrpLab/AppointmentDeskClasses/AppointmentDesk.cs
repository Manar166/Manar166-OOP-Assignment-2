namespace SrpLab;

/// <summary>
/// Appointment desk: opening-hours rules, slot search, and ICS calendar blob generation.
/// </summary>
public sealed class AppointmentDesk
{
    public TimeOnly Open { get; }
    public TimeOnly Close { get; }
    public int SlotMinutes { get; }

    public AppointmentDesk(TimeOnly open, TimeOnly close, int slotMinutes)
    {
        Open = open;
        Close = close;
        SlotMinutes = slotMinutes;
    }

 
   

    public DateTimeOffset Align(DateTimeOffset from)
    {
        var minutes = from.Minute - (from.Minute % SlotMinutes);
        return new DateTimeOffset(from.Year, from.Month, from.Day, from.Hour, minutes, 0, from.Offset);
    }
}
