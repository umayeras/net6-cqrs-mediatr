using WebApp.Data.Entities.Base;

namespace WebApp.Data.Entities
{
    public class Sample : Entity
    {
        public new int Id { get; set; }
        public string Title { get; set; }
        public string Detail { get; set; }

        public Sample(string title, string detail)
        {
            Title = title;
            Detail = detail;
            CreatedDate = DateTime.Now;
        }
    }
}
