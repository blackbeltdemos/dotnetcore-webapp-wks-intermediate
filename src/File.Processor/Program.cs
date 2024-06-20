

// See https://aka.ms/new-console-template for more information
// Source:https://data.ny.gov/
//https://data.ny.gov/Public-Safety/Index-Crimes-by-County-and-Agency-Beginning-1990/ca8h-8gjq/about_data



// Ler o arquivo Index_Crimes_by_County_and_Agency__Beginning_1990_20240620.csv , linhar a linha e escrever o valor na tela.

class Program
{
    static void Main(string[] args)
    {

        string filePath = "Index_Crimes_by_County_and_Agency__Beginning_1990_20240620.csv";
        int totalLines = 0;
        DateTime startTime = DateTime.Now;

        using (StreamReader reader = new StreamReader(filePath))
        {
           // Ler Linha a Linha e apresentar o resultado na tela
           while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                Console.WriteLine(line);
                totalLines++;
            }
       
        }

        DateTime endTime = DateTime.Now;
        TimeSpan totalTime = endTime - startTime;

        Console.WriteLine($"Total lines read: {totalLines}");
        Console.WriteLine($"Total time taken: {totalTime}");
        Console.ReadLine();
    }
}

