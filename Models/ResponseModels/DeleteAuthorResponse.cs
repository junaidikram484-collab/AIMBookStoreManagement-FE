namespace FEBookStoreManagement.Models.ResponseModels;

public class DeleteAuthorResponse
{
    public DeleteAuthorData data { get; set; }
}

public class DeleteAuthorData
{
    public bool deleteAuthor { get; set; }
}