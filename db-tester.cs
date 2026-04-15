using System;
using Npgsql;
class Program {
    static void Main() {
        string[] passwords = { "postgres", "admin", "password", "Diya", "Diya@123", "1234", "sspms", "" };
        int[] ports = { 5432, 5433 };
        foreach(var port in ports) {
            foreach(var pwd in passwords) {
                try {
                    using var conn = new NpgsqlConnection($"Host=localhost;Port={port};Database=postgres;Username=postgres;Password={pwd}");
                    conn.Open();
                    Console.WriteLine($"SUCCESS: Port={port}, Password={pwd}");
                    return;
                } catch { }
            }
        }
        Console.WriteLine("ALL FAILED");
    }
}
