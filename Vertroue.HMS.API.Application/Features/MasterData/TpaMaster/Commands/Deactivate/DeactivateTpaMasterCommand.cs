using MediatR;

public class DeactivateTpaMasterCommand : IRequest<string>
{
    public int TPA_Id { get; set; }
    public int UserId { get; set; }
}
