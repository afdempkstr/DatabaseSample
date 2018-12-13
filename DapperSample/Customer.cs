using System;

namespace DapperSample
{
    public class Customer
    {
        public Customer()
        {
        }

        public int cid { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string city { get; set; }
        public DateTime? birthday { get; set; }
    }
}
