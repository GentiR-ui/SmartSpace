using System;

namespace Domain.Entities;

public class Payment
{
    public int Id { get; set; }
    public decimal Amount { get; set; }
    public DateTime PaymentDate { get; set; } = DateTime.UtcNow;
    public string Status { get; set; } = "Pending";
    public string PaymentMethod { get; set; } = string.Empty;

    public int ReservationId { get; set; }
    public Reservation? Reservation { get; set; }
}
