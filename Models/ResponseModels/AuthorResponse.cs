using FEBookStoreManagement.DTO;

namespace FEBookStoreManagement.Models.ResponseModels;

public class AuthorResponse
{
    public List<AuthorDto> Authors { get; set; }
}