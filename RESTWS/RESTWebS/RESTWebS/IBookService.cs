using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace RESTWebS
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IBookService" in both code and config file together.
    [ServiceContract]
    public interface IBookService
    {
        [OperationContract]
        [WebInvoke(Method = "GET",
                    RequestFormat = WebMessageFormat.Json,
                    ResponseFormat = WebMessageFormat.Json,
                    UriTemplate = "Books/")]
        List<Book> GetBookList();

        [OperationContract]
        [WebInvoke(Method = "GET",
                    RequestFormat = WebMessageFormat.Json,
                    ResponseFormat = WebMessageFormat.Json,
                    UriTemplate = "BookById/{id}")]
        Book GetBookById(string id);

        [OperationContract]
        [WebInvoke(Method = "PUT",
                    RequestFormat = WebMessageFormat.Json,
                    ResponseFormat = WebMessageFormat.Json,
                    UriTemplate = "AddBook/{id}")]
        string AddBook(Book book, string id);

        [OperationContract]
        [WebInvoke(Method = "PUT",
                    RequestFormat = WebMessageFormat.Json,
                    ResponseFormat = WebMessageFormat.Json,
                    UriTemplate = "UpdateBook/{id}")]
        string UpdateBook(Book book, string id);

        [OperationContract]
        [WebInvoke(Method = "DELETE",
                    RequestFormat = WebMessageFormat.Json,
                    ResponseFormat = WebMessageFormat.Json,
                    UriTemplate = "DeleteBook/{id}")]
        string DeleteBook(string id);
    }

    public class BookService : IBookService
    {
        static IBookRepository repository = new BookRepository();

        public List<Book> GetBookList()
        {
            return repository.GetAllBooks();
        }

        public Book GetBookById(string id)
        {
            return repository.GetBookById(int.Parse(id));
        }

        public string AddBook(Book book, string id)
        {
            Book newBook = repository.AddNewBook(book);
            return "id=" + newBook.BookId;
        }

        public string UpdateBook(Book book, string id)
        {
            bool updated = repository.UpdateABook(book);
            if (updated)
                return "Book with id = " + id + " updated successfully";
            else
                return "Unable to update book with id = " + id;

        }

        public string DeleteBook(string id)
        {
            bool deleted = repository.DeleteABook(int.Parse(id));
            if (deleted)
                return "Book with id = " + id + " deleted successfully.";
            else
                return "Unable to delete book with id = " + id;
        }
    }
}
