namespace ContactsFS.Data.Models
{
    public class ContactDb : BaseDbModel
    {
        public string Name { get; set; }
        public string MobilePhone { get; set; }
        public string JobTitle { get; set; }
        public string BirthDate { get; set; }
    }
}
