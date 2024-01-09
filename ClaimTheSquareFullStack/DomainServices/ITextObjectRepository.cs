using ClaimTheSquareFullStack.DbModels;

namespace ClaimTheSquareFullStack.DomainServices
{
    public interface ITextObjectRepository
    {
        IEnumerable<TextObject> ReadAll();
        TextObject ReadOne(int index);
        bool Create(TextObject textObject);
    }
}
