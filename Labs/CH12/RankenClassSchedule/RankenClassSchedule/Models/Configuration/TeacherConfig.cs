using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RankenClassSchedule.Models.DomainModels;

namespace RankenClassSchedule.Models.Configuration
{
    public class TeacherConfig : IEntityTypeConfiguration<Teacher>
    {
        public void Configure(EntityTypeBuilder<Teacher> entity)
        {
            entity.HasData(
               new Teacher
               {
                   TeacherId = 1,
                   FirstName = "Evan",
                   LastName = "Gudmestad",

               },
                  new Teacher
                  {
                      TeacherId = 2,
                      FirstName = "Billy",
                      LastName = "Bob",

                  },
                   new Teacher
                   {
                       TeacherId = 3,
                       FirstName = "Alicia",
                       LastName = "Jones",

                   },
               new Teacher
               {
                   TeacherId = 4,
                   FirstName = "Tim",
                   LastName = "Thompson",

               },
               new Teacher
               {
                   TeacherId = 5,
                   FirstName = "Sandy",
                   LastName = "Suns",

               });
        }


    }
}

