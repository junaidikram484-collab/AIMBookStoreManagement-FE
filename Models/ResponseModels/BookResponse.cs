using FEBookStoreManagement.DTO;
using FEBookStoreManagement.Utilities;
using Newtonsoft.Json;

namespace FEBookStoreManagement.Models.ResponseModels;

public class BookResponse
{
    //[JsonConverter(typeof(MultiNameListConverter<BookDto>), "books", "bookByAuthor")]
    public List<BookDto>? Books { get; set; }
    public List<BookDto>? BookByAuthor { get; set; }

    [JsonIgnore]
    public List<BookDto> AllBooks =>
        (Books ?? new()).Concat(BookByAuthor ?? new()).ToList();
}