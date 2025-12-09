namespace Application.DTOs;

public class CreatePaymentRequest
{
    public decimal Amount { get; set; }
    public int ReservationId { get; set; }
}

public class UpdatePaymentRequest
{
    public int Id { get; set; }
    public decimal Amount { get; set; }
    public int ReservationId { get; set; }
}

public class PaymentResponse
{
    public int Id { get; set; }
    public decimal Amount { get; set; }
    public int ReservationId { get; set; }
}
