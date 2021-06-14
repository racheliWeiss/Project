using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Services
{
    public class AnchorCreditServicecs
    {
        public DateTime dateNow { get => dateNow; set => dateNow = DateTime.UtcNow.Date; }


       // public DateTime DateOfMaturity { get => DateOfMaturity; set => DateOfMaturity = new DateTime(2021, 06, 30, 5, 10, 20, (int)DateTimeKind.Utc; }
        // public DateTime dateNow = DateTime.UtcNow.Date;
        public string CustomerType { get; set; }
        public int dayOfchek = 3;//to api of shabat and chag
                                 //  DateTime dt2 = new DateTime();




        /*public double caculateDaysOfCardit()
        {
                double dateOfCardit = (this.DateOfMaturity - this.dateNow).TotalDays;

                return dateOfCardit;
       }
    
        public double

    }*/
    }
}
