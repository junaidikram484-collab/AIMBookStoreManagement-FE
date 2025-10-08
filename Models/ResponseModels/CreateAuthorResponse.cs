using FEBookStoreManagement.DTO;

namespace FEBookStoreManagement.Models.ResponseModels;

public class CreateAuthorResponse
{
    public CreateAuthorData data { get; set; }
}


public class CreateAuthorData
{
    public CreateAuthorDto createAuthor { get; set; }
}