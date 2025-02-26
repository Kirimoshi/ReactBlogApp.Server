using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReactBlogApp.Server.Models;

namespace ReactBlogApp.Server.Configurations
{
    public class UserTypeConfigurations : IEntityTypeConfiguration<UserModel>
    {
        public void Configure(EntityTypeBuilder<UserModel> builder)
        {
            builder.ToTable("Users");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder.Property(b => b.Email).IsRequired();
            builder.Property(b => b.Password).IsRequired();

            builder.HasData(
                new UserModel
                {
                    Id = Guid.NewGuid(),
                    Email = "tom@gmail.com",
                    Password = "12345"
                },
                new UserModel
                {
                    Id = Guid.NewGuid(),
                    Email = "bob@gmail.com",
                    Password = "55555"
                });
        }
    }
}
