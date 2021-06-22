using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Services
{
    public class AnchorCreditServicecs
    {
        // private int DayOfchek = 3;

        private static int _additionValueDate = 3;
        //ימי ערך להוספה
        [JsonProperty("fc_addition_value_date")]
        public int AdditionValueDate
        {
            get { return _additionValueDate; }
            set { _additionValueDate = value; }
        }//
        [JsonProperty("fc_due_date")]
        public DateTime DueDate { get; set; }//,תאריך פירעון
        //{ get => DateOfMaturity; set => DateOfMaturity = new DateTime(2021, 06, 30, 5, 10, 20, (int)DateTimeKind.Utc; }

        public double NumberOfCreditDays { get; set; }//מספר ימי אשראי

        public double AmountPaidCustomer { get; set; }//סכום ששילם הלקוח מאיזה מסך

        public double CalculateAdditionalCost { get; set; }//חישוב עלות נוספת בהתאם לתקנות לשאול מזה  

        public double CalculateAdditionalCostOverTen { get; set; }//מאיפה אני מקבלת את המשתנה הזה?

        [JsonProperty("fc_limit_addition_long_over_10k")]
        public double limitAdditionLongOover10k { get; set; }

        [JsonProperty("fc_rate_addition_to_10k")]
        public double RateAdditionTo10k { get; set; }

        [JsonProperty("fc_limit_addition_long_over_10k")]
        public double  LimitAdditionLongOver10k { get; set; }

        [JsonProperty("fc_rate_addition_short_over_10k")]
        public double rateAdditionShortOver10k { get; set; }

        public int CustomerType { get; set; }//סוג לקוח

        [JsonProperty("fc_nominal_value")]
        public int NominalValue { get; set; }//סכום הצק
        [JsonProperty("fc_max_rate_business")]
        public double MaxRrateBbusiness { get; set; }//תקרה לעוסק

        [JsonProperty("fc_rate_addition_over_90")]
        public double RateAdditionOver90 { get; set; }//תקרה לפרטי מעל 90 יום

        [JsonProperty("rate_addition_to_90")]
        public double RateAdditionTo90 { get; set; }//תקרה לפרטי למתחת 90 יום

        [JsonProperty("fc_boi_rate")]
        public double BoiRate { get; set; }//+להתחבר api ריבית בנק ישראל


        public double ActualCostRateIn { get; set; }//שיעור העלות הממשית בחישוב שנתי

        public AnchorCreditServicecs(double interestBankIsreal, double ceilingToPrivateUnderDays,
            double ceilingToPrivateOverDays, double ceilingToLicensedDealer)
        {
            this.BoiRate = interestBankIsreal;
            this.RateAdditionTo90 = ceilingToPrivateUnderDays;
            this.RateAdditionOver90 = ceilingToPrivateOverDays;
            this.MaxRrateBbusiness = ceilingToLicensedDealer;
        }
        public AnchorCreditServicecs()
        {

        }
        
        public double Maincardit()
        {
            NumberOfCreditDays = AddWorkdays(DueDate, AdditionValueDate);
            NumberOfCreditDays += CaculateDaysOfCardit();//ימי אשראי

            CalculateAdditionalCostOverTen = CalculateAdditionalCostOver();
            CalculateAdditionalCost = CalculateAdditionalCostInAccordance();//מעל 10 יום
                                                                          
            ActualCostRateIn = ActualCostRateInAnnual();
            double ckeck = Integritycheck();
            if (ckeck >= 0)
            {
                return 0;
            }
            return -1;

        }

        // caculat the (Date of maturity -Date now)+Value days for addition of check
        public double CaculateDaysOfCardit()
        {
            DateTime dateNow = DateTime.UtcNow.Date;
            double dateOfCardit = (this.DueDate - dateNow).TotalDays;
            if (dateOfCardit < 0)
            {
                dateOfCardit = 0;
            }

            return dateOfCardit;
        }

        //to add holiday as shabat and chag
        public static int AddWorkdays(DateTime originalDate, int workDays)
        {
            DateTime tmpDate = originalDate;
            int tempDateNum = workDays;
            while (workDays > 0)
            {
                tempDateNum++;
                tmpDate = tmpDate.AddDays(1);

                if (tmpDate.DayOfWeek < DayOfWeek.Friday)
                    //  tmpDate.DayOfWeek > DayOfWeek.Sunday &&
                    //&& !tmpDate.IsHoliday())
                    workDays--;
            }
            return tempDateNum;
        }

        //=IF((AND(B49=1,B24>90)),B36-B23,IF(B49=1,B34-B23,IF(B49=2,B38-B23,1)))+0.001 ואם זה עוסק , מזה 0.001
        public double Integritycheck()
        {
            if (CustomerType == 1)
            {
                if (NumberOfCreditDays > 90)
                {
                    RateAdditionOver90 = RateAdditionOver90 + BoiRate;
                    return RateAdditionOver90 - ActualCostRateIn;
                }
                else
                {
                    RateAdditionTo90 = RateAdditionTo90 + BoiRate;
                    return RateAdditionTo90 - ActualCostRateIn;
                }
            }
            else
            {
                if (CustomerType == 2)
                {
                    return (MaxRrateBbusiness - ActualCostRateIn);
                }
            }
            return 1;
        }
        /* public double MaximumForCollectionWithoutFees()
         {
             if (CustomerType == 2)
             {

                 if (NumberOfCreditDays < 10)
                 {
                     this.CeilingToLicensedDealer = this.CeilingToLicensedDealer + this.InterestBankIsreal;
                 }
                 return 0;
             }
             return 0;
         }
         public double CeilingtoLicens()
         {
             CeilingToLicensedDealer = this.CeilingToLicensedDealer + this.InterestBankIsreal;
             double DealsWithUpToTen = (CeilingToLicensedDealer * (SumOfCheck - CalculateAdditionalCostInAccordance())) * caculateDaysOfCardit() / 365;
             //double maximumForPayment= CeilingToLicensedDealer()

             return 0;
         }
        */

        //חישוב עלות נוספת בהתאם לתקנות עד 10 יום
        //Calculate additional cost In accordance with regulations  

        public double Caculate()
        {
            if(NumberOfCreditDays>365&&NominalValue >= 100000)
            {
                return 0;
            }
            if (NominalValue < 10000)
            {
                double val = Math.Min(100, 0.15 * NominalValue);
                val = Math.Max(val, 30);
                return val;
            }
            if(NominalValue>10000&& NominalValue < 100000)
            {
                if (NumberOfCreditDays <= 10)
                {
                    return Math.Max(30, 0.1 * NominalValue);
                }
                if (NumberOfCreditDays > 10)
                {
                    double val = Math.Min(500, 0.1 * NominalValue);
                    return Math.Max(30, val);
                }
               
            }
            return 0;
        }
        public double CalculateAdditionalCostInAccordance()
        {
            if (NominalValue < 2000)
            {
                return CalculateAdditionalCostOverTen;
            }
            else
            {
                if (NominalValue < 6667)
                {
                    return NominalValue* 0.015;
                }
                else
                {
                    if (NominalValue > 6667 && NominalValue < 10000)
                    {
                        return 100;
                    }
                    else
                    {
                        return NominalValue * 0.01;
                    }
                }
            }
        }

        //חישוב עלות נוספת בהתאם לתקנות מעל 10 יום
        // Cost calculation add more to regulations over 10 days
        public double CalculateAdditionalCostOver()
        {
            return Math.Min(NominalValue * 0.01, LimitAdditionLongOver10k);
        }

        //סכום לצורך עלות האשראי המרבית
        // Amount for the maximum cost of credit
        public double CostOfCreditActual()
        {
            if (NumberOfCreditDays <= 10)
            {
                return AmountPaidCustomer - CalculateAdditionalCost;
            }

            return AmountPaidCustomer - CalculateAdditionalCostOverTen;
        }

        //שיעור ריבית לעסקה
        // Interest rate per transaction
        public double InterestRatePerTransaction()
        {
            double costOfCredit = CostOfCreditActual();
            double caculateY = AmountPaidCustomer - costOfCredit;
            double caculateX = (NominalValue - caculateY);
            double interest = costOfCredit / caculateX;
            return interest * 100;
        }

        //שיעור העלות הממשית בחישוב שנתי (חזקות)
        // Actual cost rate in annual calculation (power)
        public double ActualCostRateInAnnual()
        {
            double interestRatePerTransaction = InterestRatePerTransaction();//שעור ריבית לעסקה
            double calculationPeriods = (365 / NumberOfCreditDays);
            double InterestForCalculation = 1 + interestRatePerTransaction;
            double efactive = (Math.Pow(InterestForCalculation, calculationPeriods) - 1);
            double actualCostRateInAnnualCalculation = (interestRatePerTransaction / NumberOfCreditDays) * 365;

            return actualCostRateInAnnualCalculation;
        }
    }




    /*public double caculateDaysOfCardit()
    {
            double dateOfCardit = (this.DateOfMaturity - this.dateNow).TotalDays;

            return dateOfCardit;
   }

    public double

}*/
}

