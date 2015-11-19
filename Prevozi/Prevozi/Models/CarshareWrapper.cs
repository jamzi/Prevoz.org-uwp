using System.Collections.Generic;

namespace Prevozi.Models
{
    public class CarshareList
    {
        public int id { get; set; }
        public string type { get; set; }
        public string from_id { get; set; }
        public string from_country { get; set; }
        public string from_country_name { get; set; }
        public string to_id { get; set; }
        public string to { get; set; }
        public string to_country { get; set; }
        public string to_country_name { get; set; }
        public string time { get; set; }
        public string date_iso8601 { get; set; }
        public string added { get; set; }
        public double price { get; set; }
        public double num_people { get; set; }
        public string author { get; set; }
        public string is_author { get; set; }
        public string comment { get; set; }
        public string contact { get; set; }
        public string date { get; set; }
        public string full { get; set; }
        public string insured { get; set; }
        public string share_type { get; set; }
        public string confirmed_contact { get; set; }
        public object bookmark { get; set; }
        public string from { get; set; }
    }

    public class CarshareWrapper
    {
        public string search_type { get; set; }
        public List<CarshareList> carshare_list { get; set; }
    }
}