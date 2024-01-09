namespace ClaimTheSquareFullStack.ViewModel
{
    public class Something
    {
        public Guid Id { get; set; }

        public Something()
        {
            Id = Guid.NewGuid();
        }
    }
}
