namespace Practice_Books.Models
{
    public class Books
    {
        public int Id { get; set; }
        public int DepartmentId { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        //public Department Department { get; set; }
    }
}
