
namespace CSV_File_Editor
{
    internal class Loan
    {
        public string AccountNumber { get; set; }
        public string LoanId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public decimal AmountDue { get; set; }
        public string DateDue { get; set; }
        public string SocialLastFour { get; set; }
        public Loan(string _accountNumber, string _loadId, string _lastName, string _firstName, decimal _amountDue, string _dateDue, string _socialLastFour)
        {
            AccountNumber = _accountNumber;
            LoanId = _loadId;
            LastName = _lastName;
            FirstName = _firstName;
            AmountDue = _amountDue;
            DateDue = _dateDue;
            SocialLastFour = _socialLastFour;
        }
    }
}
