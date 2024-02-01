namespace ShopOfPryaniks.Application.Common.Exceptions;
public class EntityNotFoundException : Exception
{
    public EntityNotFoundException() : base() { }
    public EntityNotFoundException(string? message) : base(message) { }
}
