namespace PokemonAPI.WebService.Models.Interfaces
{
    public interface IEFModel
    {
    }

    public interface IEFId : IEFModel
    {
        int Id { get; }
    }

    public interface IEFIdentifier : IEFId
    {
        string Identifier { get; }
    }
}