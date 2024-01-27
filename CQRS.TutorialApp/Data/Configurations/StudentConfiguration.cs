using CQRS.TutorialApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CQRS.TutorialApp.Data.Configurations
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasData(new Student[]
            {
                new()
                {
                    Id = 1,
                    Name = "Arif",
                    Age =32,
                    Surname = "asdasdasd"
                },
                new()
                {
                    Id = 2,
                    Name = "Kübra",
                    Age=32,
                    Surname = "asdklşasdkşlaskd"
                }
            });
        }
    }
}
