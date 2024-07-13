using MediatR;

public class DeleteBikeCommand : IRequest
{
    public string EncodedName { get; set; }

    public DeleteBikeCommand() { }

    public DeleteBikeCommand(string encodedName)
    {
        EncodedName = encodedName;
    }
}
