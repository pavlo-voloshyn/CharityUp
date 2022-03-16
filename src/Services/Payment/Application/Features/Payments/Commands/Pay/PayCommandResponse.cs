namespace PaymentService.Application.Features.Payments.Commands.Pay;

/// <summary>
/// Response on pay command is request was successfull
/// </summary>
public class PayCommandResponse
{
    /// <summary>
    /// Message of success
    /// </summary>
    public string Message { get; set; }
}
