//using CollegeApp.Data;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;
 
//namespace CollegeApp.Data.Config

//{

//    public class StudentConfig : IEntityTypeConfiguration<Student>

//    {

//        public void Configure(EntityTypeBuilder<Student> builder)

//        {

//            builder.ToTable("Student");

//            builder.HasKey(e => e.Id);

//            builder.Property(e => e.Id).UseIdentityColumn();

//            builder.Property(e => e.Name).IsRequired().HasMaxLength(250);

//            builder.Property(e => e.Email).IsRequired();

//            builder.HasData(new List<Student>

//                        {

//                            new Student {

//                                Id = 1,

//                                Name = "Chaitra",

//                                Email = "123@gmail.com",

//                                Age = 28 }

//                        });

//        }

//    }

//}


//DbContext: using Microsoft.EntityFrameworkCore;

//using StudentApp.Data.Config;
 
////using StudentApp.Data.Config;

//using StudentApp.Models;
 
//namespace StudentApp.Data

//{

//    public class CollegeDBContext : DbContext

//    {

//        public CollegeDBContext(DbContextOptions<CollegeDBContext> options) : base(options)

//        {

//        }

//        public DbSet<Student> Students { get; set; }

//        //public DbSet<Courses> Cour { get; set; }


//        protected override void OnModelCreating(ModelBuilder modelBuilder)

//        {

//            //            modelBuilder.Entity<Student>().HasData(new List<Student>

//            //{

//            //    new Student{

//            //Id=1, Name="Chaitra",Email="123@gmail.com",Age=28}

//            //});

//            //            modelBuilder.Entity<Student>(entity =>

//            //            {

//            //                entity.Property(e => e.Name).IsRequired().HasMaxLength(50);

//            //                entity.Property(e => e.Email).IsRequired();

//            //            });

//            //OR

//            modelBuilder.ApplyConfiguration(new StudentConfig());


//        }

//    }

//}

