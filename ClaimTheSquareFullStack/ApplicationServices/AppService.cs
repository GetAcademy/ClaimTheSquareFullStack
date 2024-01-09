using ClaimTheSquareFullStack.DomainServices;
using ClaimTheSquareFullStack.ViewModel;

namespace ClaimTheSquareFullStack.ApplicationServices
{
    public class AppService
    {
        private ITextObjectRepository _textObjectRepository;

        public AppService(ITextObjectRepository textObjectRepository)
        {
            _textObjectRepository = textObjectRepository;
        }

        public async Task<bool> Create(TextObject textObject)
        {
            //var dbTextObject = new TextObjectInt(textObject.Index, textObject.Text, textObject.ForeColor, textObject.BackColor);
            ///*
            // * if(farge og tekst begynner på samme bokstav)
            // */
            //return textObjectRepository.Create(dbTextObject);
            return true;
        }
    }
}
