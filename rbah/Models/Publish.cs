namespace rbah.Models
{
    public class Publish
    {
        public string autorName { get; set; }
        public string title { get; set; }
        public int postId { get; set; }
        public Publish(string a,string b,int c)
        {
            autorName = a;
            title = b;
            postId = c;
        }

        public Publish()
        {
        }
    }
}