using System;
using Npgsql;
class Program {
    static void Main() {
        try {
            // First connect and change the password
            using var conn = new NpgsqlConnection($"Host=localhost;Port=5433;Database=postgres;Username=postgres;Password=postgres");
            conn.Open();
            using var cmd1 = new NpgsqlCommand("ALTER USER postgres WITH PASSWORD 'Diya@1234';", conn);
            cmd1.ExecuteNonQuery();
            Console.WriteLine("PASSWORD ON 5433 CHANGED SUCCESSFULLY TO Diya@1234");
            
            // Reconnect using new password
            using var conn2 = new NpgsqlConnection($"Host=localhost;Port=5433;Database=postgres;Username=postgres;Password=Diya@1234");
            conn2.Open();
            // Drop it if exists just to be safe, but actually it might not exist yet
            using var cmd3 = new NpgsqlCommand("CREATE DATABASE sspms;", conn2);
            cmd3.ExecuteNonQuery();
            Console.WriteLine("CREATE DATABASE sspms SUCCESS ON PORT 5433");

        } catch (Exception ex) { 
            Console.WriteLine("ERROR: " + ex.Message);
        }
    }
}
