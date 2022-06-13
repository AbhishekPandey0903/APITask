using Microsoft.EntityFrameworkCore;

namespace BellurbisRestroApi.Models
{
    public class TaskContaxt:DbContext
    {
        public TaskContaxt(DbContextOptions<TaskContaxt> options) : base(options)
        {

        }
        public DbSet<RestroMod> Restrotab { get; set; }
        public DbSet<PlayersMod> PlayersTab { get; set; }
        public DbSet<LinkMod> LinkRAP { get; set; }


    }
}
