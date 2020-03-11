namespace ToDoList.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ToDoList.Entities.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ToDoList.Entities.ApplicationDbContext context)
        {
            string[] labels = new string[]
            {
                "Drink Coffee",
                "Make Awesome App",
                "Have a lunch"
            };
            for (int i = 0; i < 3; i++)
            {
                context.ToDo.AddOrUpdate(u => u.Id,
                    new Entities.ToDo
                    {
                        Id = i + 1,
                        Done = false,
                        Important = false,
                        Label = labels[i]
                    });
            }
        }
    }
}
