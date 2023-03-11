using CSV_File_Editor;


Console.Write("Please enter a .csv filepath: ");

string filePathInput = GetFilePath();
string fileName = Path.GetFileName(filePathInput).Replace(".csv", "");
string baseFilePath = Path.GetDirectoryName(filePathInput);
string filePathOutput = @$"{baseFilePath}\{fileName}_Formatted.csv";

List<Loan> loans = ReadCSVFile(filePathInput);
WriteCSVFile(filePathOutput, loans);

static string GetFilePath()
{
    string filePath;
    while (true)
    {
        filePath = Console.ReadLine().Replace("\"", "");
        if (filePath == "" || filePath == null)
        {
            Console.Write("Filepath cannot be empty, please enter a valid .csv filepath: ");
        }
        else
        {
            try
            {
                StreamReader reader = new StreamReader(filePath);
                break;
            }
            catch (Exception ex)
            {
                Console.Write("File not found, please enter a valid .csv filepath: ");
            }
        }
    }
    return filePath;
}
static List<Loan> ReadCSVFile(string InputPath)
{
    StreamReader reader = new StreamReader(InputPath);
    List<Loan> loans = new List<Loan>();
    string header = reader.ReadLine();
    while (true)
    {
        string line = reader.ReadLine();
        if (line == null)
        {
            break;
        }
        else
        {
            string[] values = line.Split(',');
            Loan newLoan = new Loan(values[0], values[1], values[2], values[3], Convert.ToDecimal(values[4].Insert(values[4].Length -2, ".")), values[5], values[6]);
            loans.Add(newLoan);
        }
    }
    reader.Close();
    return loans;
}
static void WriteCSVFile(string OutputPath, List<Loan> loans)
{
    StreamWriter writer = new StreamWriter(OutputPath);

    writer.WriteLine("AccountNumber,LoanId,Name,AmountDue,DateDue,SocialLastFour");
    foreach (Loan loan in loans)
    {
        if(loan.AmountDue < 1000)
        {
            writer.WriteLine($"{loan.AccountNumber},{loan.LoanId},{loan.FirstName} {loan.LastName},{string.Format("{0:C}", loan.AmountDue)},{loan.DateDue},{loan.SocialLastFour}");
        }
        else
        {
            writer.WriteLine($"{loan.AccountNumber},{loan.LoanId},{loan.FirstName} {loan.LastName},\"{string.Format("{0:C}", loan.AmountDue)}\",{loan.DateDue},{loan.SocialLastFour}");
        } 
    }
    writer.Close();
    Console.WriteLine();
    Console.WriteLine("File has been Formatted!");
}