namespace FEBookStoreManagement.Models.ResponseModels;

public class DeleteBookResponse
{
    public DeleteBookData data { get; set; }
}

public class DeleteBookData
{
    public bool deleteBook { get; set; }
}