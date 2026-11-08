using System;
using System.IO;

class Program //ค็อป
{

            }
        }
    }

    //ไก่
    // 1. เพิ่มข้อมูลการผลิต
    static void AddData()
    {
        
    }

    // 2. แสดงข้อมูลการผลิต
    static void ShowData()
    {
      
    }

    // คำนวณเปอร์เซ็นต์ของเสีย
    static double CalculateRate(int produced, int defective)
    {

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
