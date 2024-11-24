using FishingEvents.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FishingEvents.Infrastructure.Data.Configuration
{
    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        private Comment[] initialComment =
        {
            new Comment()
            {
                Id=1,
                CommentText="Great fish!",
                CreatedOn = DateTime.Now,
                AuthorId="a7dded57-50b8-4c59-8148-619b8d2a1266",  //Dave Carraro
                FishingEventId=3
            },
             new Comment()
            {
                Id=2,
                CommentText="Thanks!!!",
                CreatedOn = DateTime.Now,
                AuthorId="8c148075-961f-4ddc-bdb2-416c5bfa1439",  //Dave Marciano
                FishingEventId=3
            },
              new Comment()
            {
                Id=3,
                CommentText="How much does it weigh?",
                CreatedOn = DateTime.Now,
                AuthorId="ef082de5-9f29-4f11-adb4-a337f90e3373",  //Tyler McLaughlin
                FishingEventId=3
            },
               new Comment()
            {
                Id=4,
                CommentText="1200 pounds(540 kg)",
                CreatedOn = DateTime.Now,
                AuthorId="8c148075-961f-4ddc-bdb2-416c5bfa1439",  //Dave Marciano
                FishingEventId=3
            },
                 new Comment()
            {
                Id=5,
                CommentText="Whoooa!",
                CreatedOn = DateTime.Now,
                AuthorId="ef082de5-9f29-4f11-adb4-a337f90e3373",  //Tyler McLaughlin
                FishingEventId=3
            },

        };

        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.HasData(initialComment);
        }
    }
}
