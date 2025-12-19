namespace Application.DTOs;

public class CreatePaymentRequest
{
    public decimal Amount { get; set; }
    public int ReservationId { get; set; }
    public string PaymentMethod { get; set; } = string.Empty;
}

public class UpdatePaymentRequest
{
    public int Id { get; set; }
    public decimal Amount { get; set; }
    public int ReservationId { get; set; }
    public string Status { get; set; } = "Pending";
    public string PaymentMethod { get; set; } = string.Empty;
}

public class PaymentResponse
{
    public int Id { get; set; }
    public decimal Amount { get; set; }
    public DateTime PaymentDate { get; set; }
    public string Status { get; set; } = string.Empty;
    public int ReservationId { get; set; }
    public string PaymentMethod { get; set; } = string.Empty;
}
