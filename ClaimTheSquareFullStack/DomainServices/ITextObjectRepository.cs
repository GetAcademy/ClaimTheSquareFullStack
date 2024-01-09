using ClaimTheSquareFullStack.DbModels;

namespace ClaimTheSquareFullStack.DomainServices
{
    public interface ITextObjectRepository
    {
        Task<IEnumerable<TextObject>> ReadAll();
        Task<TextObject> ReadOne(int index);
        Task<bool> Create(TextObjectInt textObject);
    }
}
