using Microsoft.Data.SqlClient;
using Microsoft.Data.Sqlite;

string connectionString = "Server=DESKTOP-PF0T13E\\SQLEXPRESS;Database=SoftUni;Trusted_Connection=True;TrustServerCertificate=True;";
using (SqlConnection sqlConnection = new SqlConnection(connectionString)) 
{
    sqlConnection.Open();
    string query = "SELECT COUNT (*) FROM Employees";
    using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection)) 
    {
        int count = (int)sqlCommand.ExecuteScalar();
        Console.WriteLine(count);
    }
}