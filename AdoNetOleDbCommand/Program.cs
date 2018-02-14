using System;
using System.Data.OleDb;

namespace AdoNetOleDbCommand
{
    class Program
    {
        static string _connectionString =
            @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\Amankeldi Kairbay\source\repos\AdoNetOleDbCommand\AdoNetOleDbCommand\bin\Debug\accessDb_00.mdb";


        static void Main(string[] args)
        {
            //CreateTaablesModel();
            //CreateTablesManufacturer();
            //CreateTablesStopReason();
            InsertMethod();
        }

        static void CreateTaablesModel()
        {
            string createTablesModel = "CREATE TABLE [TablesModel] " +
                                "([intModelID] INT PRIMARY KEY NOT NULL, " +
                                "[strName] VARCHAR(20), " +
                                "[intManufacturerID] INT, " +
                                "[intSMCSFamilyID] INT, " +
                                "[strImage] VARCHAR(20))";

            using (OleDbConnection connection = new OleDbConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    OleDbCommand cmd = new OleDbCommand(createTablesModel, connection);
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Таблицa успешно созданa");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }


            }
        }

        static void CreateTablesManufacturer()
        {
            string createTablesManufacturer = "CREATE TABLE [TablesManufacturer] " +
                                        "([intManufacturerID] INT PRIMARY KEY NOT NULL, " +
                                        "[strName] VARCHAR(20))";

            using (OleDbConnection connection = new OleDbConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    OleDbCommand cmd = new OleDbCommand(createTablesManufacturer, connection);
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Таблицы успешно созданы!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }


            }
        }

        static void CreateTablesStopReason()
        {
            string createTablesStopReason = "CREATE TABLE [TablesStopReason] " +
                                            "([intStopReasonId] INT PRIMARY KEY NOT NULL, " +
                                            "[strReason] VARCHAR(30), " +
                                            "[bitDowntime] BIT, " +
                                            "[bitUnscheduled] BIT, " +
                                            "[bitPMStoppages] BIT, " +
                                            "[bitScheduledRepairsAndOther] BIT, " +
                                            "[intLocationId] INT)";

            using (OleDbConnection connection = new OleDbConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    OleDbCommand cmd = new OleDbCommand(createTablesStopReason, connection);
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Таблицы успешно созданы!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        static void InsertMethod()
        {
            Console.Write("Введите intModelID: ");
            int intModelID = Int32.Parse(Console.ReadLine());

            Console.Write("Введите strName: ");
            string strName = Console.ReadLine();

            Console.Write("Введите intManufacturerID: ");
            int intManufacturerID = Int32.Parse(Console.ReadLine());

            Console.Write("Введите intSMCSFamilyID: ");
            int intSMCSFamilyID = Int32.Parse(Console.ReadLine());

            Console.Write("Введите strImage: ");
            string strImage = Console.ReadLine();

            string query = String.Format("INSERT INTO [TablesModel] " +
                                                "(intModelID, strName, intManufacturerID, intSMCSFamilyID, strImage) " +
                                                "VALUES ({0}, '{1}', {2}, {3}, '{4}')",
                intModelID, strName, intManufacturerID, intSMCSFamilyID, strImage);



            using (OleDbConnection connection = new OleDbConnection(_connectionString))
            {
                connection.Open();
                OleDbCommand cmd = new OleDbCommand(query, connection);
                int number = cmd.ExecuteNonQuery();
                Console.WriteLine("\nДобавлено объектов: {0}", number);
                Console.WriteLine();

                Console.WriteLine("----------------------------");
                Console.WriteLine("Добавленные объекты:\n");
                query = "SELECT * FROM [TablesModel]";
                cmd.CommandText = query;
                OleDbDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        object objIntModelID = reader.GetValue(0);
                        object objStrName = reader.GetValue(1);
                        object objIntManufacturerID = reader.GetValue(2);
                        object objIntSMCSFamilyID = reader.GetValue(3);
                        object objStrImage = reader.GetValue(4);

                        Console.WriteLine(reader.GetName(0) + " : " + objIntModelID);
                        Console.WriteLine(reader.GetName(1) + " : " + objStrName);
                        Console.WriteLine(reader.GetName(2) + " : " + objIntManufacturerID);
                        Console.WriteLine(reader.GetName(3) + " : " + objStrName);
                        Console.WriteLine(reader.GetName(4) + " : " + objStrImage);
                        Console.WriteLine();
                    }
                }
            }


        }
    }
}
