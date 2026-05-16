using Microsoft.Data.SqlClient;
using System;
using System.ComponentModel.Design;
using System.Data.SqlClient;

class Program
{ 
    static string connectionString = "Server=localhost\\SQLEXPRESS;Database=ExamDb;Trusted_Connection=True;TrustServerCertificate=True;";
    static void Main()
    {
        Menu();
    }
    static void Menu()
    {
        while (true)
        {
            Console.WriteLine("\n--- IMTANAN SISTEMI ---");
            Console.WriteLine("1. Telebe elave et");
            Console.WriteLine("2. Netice elave et");
            Console.WriteLine("3. Telebeleri goster");
            Console.WriteLine("4. Cixis");
            Console.Write("Secim: ");

            string choice = Console.ReadLine();

            if (choice == "1")
            {
                AddStudent();
            }
            else if (choice == "2")
            {
                AddResult();
            }
            else if (choice == "3")
            {
                ShowStudents();
            }
            else if (choice == "4")
            {
                break;
            }
        }
    }
    static void AddStudent()
    {
        Console.Write("Ad: ");
        string name = Console.ReadLine();

        Console.Write("Soyad: ");
        string surname = Console.ReadLine();

        SqlConnection conn = new SqlConnection(connectionString);
        conn.Open();

        string query = "INSERT INTO Studennts (Name, Surname) VALUES (@n, @s)";
        SqlCommand cmd = new SqlCommand(query, conn);

        cmd.Parameters.AddWithValue("@n", name);
        cmd.Parameters.AddWithValue("@s", surname);

        cmd.ExecuteNonQuery();
        conn.Close();

        Console.WriteLine("Telebe elave edildi!");
    }
    static void AddResult()
    {
        Console.Write("Telebe ID: ");
        int id = Convert.ToInt32(Console.ReadLine());

        Console.Write("Fenn: ");
        string subject = Console.ReadLine();

        Console.Write("Bal: ");
        int score = Convert.ToInt32(Console.ReadLine());

        SqlConnection conn = new SqlConnection(connectionString);
        conn.Open();

        string query = "INSERT INTO Results (StudentId, Subject, Score) VALUES (@id, @sub, @sc)";
        SqlCommand cmd = new SqlCommand(query, conn);

        cmd.Parameters.AddWithValue("@id", id);
        cmd.Parameters.AddWithValue("@sub", subject);
        cmd.Parameters.AddWithValue("@sc", score);

        cmd.ExecuteNonQuery();
        conn.Close();

        Console.WriteLine("Netice elave edildi!");
    }
    static void ShowStudents()
    {
        SqlConnection conn = new SqlConnection(connectionString);
        conn.Open();

        string query = "SELECT * FROM Studennts";
        SqlCommand cmd = new SqlCommand(query, conn);

        SqlDataReader reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            Console.WriteLine(
                $"ID: {reader["Id"]}, Ad: {reader["Name"]}, Soyad: {reader["Surname"]}"
            );
        }

        conn.Close();
    }
}

