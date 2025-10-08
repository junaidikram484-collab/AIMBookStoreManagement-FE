namespace FEBookStoreManagement.DTO
{
    public class BookDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public int Pages { get; set; }
        public AuthorDto Author { get; set; }
    }
}
