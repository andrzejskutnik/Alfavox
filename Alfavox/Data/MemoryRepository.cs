using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Alfavox
{
    public class MemoryRepository : IRepository
    {
        readonly IDictionary<int, string> keyValuePairs = new Dictionary<int, string>
        {
            {1, "value1" },
            {2, "value2" },
            {3, "value3" },
            {4, "value4" },
            {5, "value5" },
            {6, "value6" },
            {7, "value7" },
            {8, "value8" },



        };

        public string GetValuesForKey(int dataKey)
        {

            return keyValuePairs.FirstOrDefault(k => k.Key == dataKey).Value;
        }

        public IDictionary<int, string> GetValuesForKeys(IEnumerable<int> dataKey)
        {
            var result = new Dictionary<int, string>();
            foreach (var item in dataKey)
            {
                result.Add(item, keyValuePairs[item]);
            }
            return result;
        }
    }

    public class ValueModelRepository : IRepository
    {
        private ValueModelContext _context;
        public ValueModelRepository(ValueModelContext context)
        {
            _context = context;
        }

        public string GetValuesForKey(int dataKey)
        {
            return _context.KeyValueModels.FirstOrDefault(k => k.Key == dataKey).Value;
        }

        public IDictionary<int, string> GetValuesForKeys(IEnumerable<int> dataKey)
        {
            var result = new Dictionary<int, string>();
            foreach (var item in dataKey)
            {
                result.Add(item, _context.KeyValueModels.FirstOrDefault(d => d.Key==item)?.Value);
            }
            return result;
        }
    }

    public partial class ValueModelContext : DbContext
    {
        public ValueModelContext(DbContextOptions<ValueModelContext> options)
        : base(options)
        {
        }

        public DbSet<KeyValueModel> KeyValueModels { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
       
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Data Source={Path.Combine(Directory.GetParent(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)).ToString(), "DB.db")}");
        }

    }

    public class KeyValueModel
    {
        [Key]
        public int Key { get; set; }
        public string Value { get; set; }
    }
}
