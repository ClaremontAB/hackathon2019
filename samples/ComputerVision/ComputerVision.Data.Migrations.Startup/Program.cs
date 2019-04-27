using ComputerVision.Data2;
using Microsoft.EntityFrameworkCore;
using System;

namespace ComputerVision.Data.Migrations.Startup
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new ComputerVisionContext())
            {
                db.Database.Migrate();
            }
        }
    }
}
