using MediatR;

public class DeactivateTpaMasterCommand : IRequest<bool>
{
    public int TPAId { get; set; }
}
