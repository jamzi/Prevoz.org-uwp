namespace Prevozi.Models
{
    public class CarshareSearch
    {
        public string From { get; set; }
        public string To { get; set; }
        public string Year { get; set; }
        public string Month { get; set; }
        public string Day { get; set; }
        public CarshareSearch(string from, string to, string year, string month, string day)
        {
            From = from;
            To = to;
            Year = year;
            Month = month;
            Day = day;
        }
    }
}