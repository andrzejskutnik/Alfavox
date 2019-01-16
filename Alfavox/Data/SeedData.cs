using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace Alfavox
{
    public static class SeedData
    {
        public static void Populate(IApplicationBuilder app)
        {
            var context = app.ApplicationServices.GetRequiredService<ValueModelContext>();
            context.Database.Migrate();
            if (!context.KeyValueModels.Any())
            {
                context.KeyValueModels.AddRange(
                    new KeyValueModel { Key = 1, Value = "Value 1" },
                    new KeyValueModel { Key = 2, Value = "Value 2" },
                    new KeyValueModel { Key = 3, Value = "Value 3" },
                    new KeyValueModel { Key = 4, Value = "Value 4" },
                    new KeyValueModel { Key = 5, Value = "Value 5" },
                    new KeyValueModel { Key = 6, Value = "Value 6" },
                    new KeyValueModel { Key = 7, Value = "Value 7" },
                    new KeyValueModel { Key = 8, Value = "Value 8" },
                    new KeyValueModel { Key = 9, Value = "Value 9" },
                    new KeyValueModel { Key = 10, Value = "Value 10" },
                    new KeyValueModel { Key = 11, Value = "Value 11" },
                    new KeyValueModel { Key = 12, Value = "Value 12" },
                    new KeyValueModel { Key = 13, Value = "Value 13" },
                    new KeyValueModel { Key = 14, Value = "Value 14" },
                    new KeyValueModel { Key = 15, Value = "Value 15" }
                    );
                context.SaveChanges();
            }
        }
    }
}