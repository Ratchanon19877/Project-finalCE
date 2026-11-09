using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
class Program //ค็อป
    {
        static string[] stationNames = new string[20];
        static int[,] productionData = new int[20,2];
        static int stationCount = 0;
        static void Main()
        {
            int choice = 0;
            while(choice !=5)
            {
                Console.Clear();
                   
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("========================================");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("          FACTORY DETECTIVE");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("       ProductionData Analysis Sytem");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("========================================"); 

                Console.WriteLine();

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("1. Add Production Data");

                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("2. Show All Stations");

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("3. Analyze Production");

                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("4. Save Report to File");

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("5. Exit");

                Console.WriteLine();

                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Select menu ");
                
                Console.ResetColor();

                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Please enter a number.");
                    choice = 0;
                    continue;
                }
                switch(choice)
                {
                    case 1:
                    AddData();
                    break;

                    case 2:
                    ShowData();
                    break;

                    case 3:
                    AnalyzeData();
                    break;

                    case 4:
                    SaveReport();
                    break;

                    case 5:
                    Console.WriteLine("Program ended.");
                    break;

                    default:
                    Console.WriteLine("Invalid menu.");
                    break;
                }
            }
        }
    

    //ไก่
    // 1. เพิ่มข้อมูลการผลิต
    static void AddData()
    {
        if (stationCount >= 20)
        {
            Console.WriteLine("Station limit reached.");
            return;
        }

        Console.WriteLine("Enter station name : ");
        string name = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(name))
        {
            Console.WriteLine("Station name cannot be empty.");
            return;
        }

        Console.WriteLine("Enter Total production : ");
        int produced;

        if (!int.TryParse(Console.ReadLine(), out produced) || produced <= 0)
        {
            Console.WriteLine("Invalid product amount.");
            return;
        }

        Console.WriteLine("Enter defective product: ");
        int defective;

        if (!int.TryParse(Console.ReadLine(), out defective) ||
            defective < 0 || defective > produced)
        {
            Console.WriteLine("Invalid defective amount.");
            return;
        }

        stationNames[stationCount] = name;
        productionData[stationCount, 0] = produced;
        productionData[stationCount, 1] = defective;

        stationCount++;
    }

    // 2. แสดงข้อมูลการผลิต
    static void ShowData()
    {
        if (stationCount == 0)
        {
            Console.WriteLine("No production data.");
            return;
        }

        Console.WriteLine("\n===== PRODUCTION DATA =====");

        for (int i = 0; i < stationCount; i++)
        {
            Console.WriteLine("Station: " + stationNames[i]);
            Console.WriteLine("Produced: " + productionData[i, 0]);
            Console.WriteLine("Defective: " + productionData[i, 1]);
            Console.WriteLine("-------------------------");
        }
    }

    // คำนวณเปอร์เซ็นต์ของเสีย
    static double CalculateRate(int produced, int defective)
    {
        return (double)defective / produced * 100;
    }

    // ตรวจสอบสถานะ
    static string CheckStatus(double rate)
    {
        if (rate > 5)
        {
            return "Needs Inspection";
        }
        else
        {
            return "Normal";
        }
    }
    

    //ภูริ
    // 3. Analyze Production Data
    static void AnalyzeData()
    {
        
    }
    

    //เฟิร์ส
    // 4. บันทึกข้อมูลลงไฟล์
        static void SaveReport()
    {
        if (stationCount == 0)
        {
            Console.WriteLine("No data to save.");
            return;
        }

        try
        {
            using (StreamWriter file =
            new StreamWriter("FactoryReport.csv"))
            {
                file.WriteLine(
                    "\"FACTORY DETECTIVE - PRODUCTION REPORT\",,,,");

                file.WriteLine(
                    "Generated At," +
                    DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") +
                    ",,,");

                file.WriteLine(
                    "Total Stations," + stationCount + ",,,");

                file.WriteLine();

                file.WriteLine("Station,Produced,Defective,Defect Rate (%),Status");


                for (int i = 0; i < stationCount; i++)
                {
                    int produced = productionData[i, 0];
                    int defective = productionData[i, 1];

                    double rate = CalculateRate(
                        produced, defective);

                    string status = CheckStatus(rate);

                    file.WriteLine("\"" + stationNames[i].Replace("\"", "\"\"") + "\"," +
                        produced + "," +
                        defective + "," +
                        rate.ToString("F2",
                        System.Globalization.CultureInfo.InvariantCulture) + "," +
                        status);
                }
            }

            Console.WriteLine("======================================");
            Console.WriteLine("       REPORT SAVED SUCCESSFULLY");
            Console.WriteLine("======================================");
            Console.WriteLine("File Name : FactoryReport.csv");
            Console.WriteLine("Stations  : " + stationCount);
            Console.WriteLine("======================================");
        }
        catch (IOException)
        {
            Console.WriteLine("Cannot save the report.");
        }
    }
}