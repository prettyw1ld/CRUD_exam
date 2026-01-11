using Demo2.Models;
using Microsoft.EntityFrameworkCore;
using System.Windows;

namespace Demo2.Classes
{
    public class DbConnection: DbContext
    {
        public DbSet<Number> Numbers { get; set; }
        public DbSet<Hostel> Hostels { get; set; }
        public DbConnection()
        {
            try
            {
                Database.EnsureCreated();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("server=127.0.0.1;port=3306;uid=root;database=hostels;", new MySqlServerVersion(new Version(8,0,11)));
        }
    }
}
