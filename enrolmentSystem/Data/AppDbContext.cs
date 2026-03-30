using System.Collections.Generic;
using System.Reflection.Emit;
<<<<<<< HEAD
using enrolmentSystem.Models;
using Microsoft.EntityFrameworkCore;
=======
using Microsoft.EntityFrameworkCore;
using enrolmentSystem.Model;
>>>>>>> origin/wy


namespace enrolmentSystem.Data
{
<<<<<<< HEAD
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) { }

        // DbSet properties for each entity
        public DbSet<Student> Students { get; set; }
        public DbSet<Enrolment> Enrolments { get; set; }
        public DbSet<subjectOffered> SubjectsOffered { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<Lecturer> Lecturers { get; set; }
        public DbSet<Evaluation> Evaluations { get; set; }
        public DbSet<Inquiry> Inquiries { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<addDropRequest> AddDropRequests { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Timetable> Timetables { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Student to Enrolment (One-to-Many)
            modelBuilder.Entity<Student>()
                .HasMany(s => s.Enrolments)
                .WithOne(e => e.Student)
                .HasForeignKey(e => e.studentID)
                .OnDelete(DeleteBehavior.Restrict);

            // Payment to Enrolment (One-to-Many, Optional)
            modelBuilder.Entity<Payment>()
                .HasMany(p => p.Enrolments)
                .WithOne(e => e.Payment)
                .HasForeignKey(e => e.paymentID)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Enrolment>()
                .HasOne(e => e.SubjectOffered)
                .WithOne(so => so.Enrolment) // One-to-One relationship
                .HasForeignKey<Enrolment>(e => e.subjectOfferedID)
                .OnDelete(DeleteBehavior.Restrict);



            // Session to SubjectsOffered (One-to-Many)
            modelBuilder.Entity<Session>()
                .HasMany(s => s.SubjectsOffered)
                .WithOne(so => so.Session)
                .HasForeignKey(so => so.sessionID)
                .OnDelete(DeleteBehavior.Restrict);

            // SubjectOffered to Timetables (One-to-Many)
            modelBuilder.Entity<subjectOffered>()
                .HasMany(so => so.Timetables)
                .WithOne(t => t.SubjectOffered)
                .HasForeignKey(t => t.subjectOfferedID)
                .OnDelete(DeleteBehavior.Restrict);

            // Lecturer to SubjectsOffered (One-to-Many)
            modelBuilder.Entity<Lecturer>()
                .HasMany(l => l.SubjectsOffered)
                .WithOne(so => so.Lecturer)
                .HasForeignKey(so => so.lecturerID)
                .OnDelete(DeleteBehavior.Restrict);

            // Subject to SubjectsOffered (One-to-Many)
            modelBuilder.Entity<Subject>()
                .HasMany(s => s.SubjectsOffered)
                .WithOne(so => so.Subject)
                .HasForeignKey(so => so.subjectID)
                .OnDelete(DeleteBehavior.Restrict);

            // Student to Evaluation (One-to-Many)
            modelBuilder.Entity<Student>()
                .HasMany(s => s.Evaluations)
                .WithOne(e => e.Student)
                .HasForeignKey(e => e.StudentID)
                .OnDelete(DeleteBehavior.Restrict);

            // SubjectOffered to Evaluation (One-to-Many)
            modelBuilder.Entity<subjectOffered>()
                .HasMany(so => so.Evaluations)
                .WithOne(e => e.SubjectOffered)
                .HasForeignKey(e => e.SubjectOfferedID)
                .OnDelete(DeleteBehavior.Restrict);

            // Student to Inquiries (One-to-Many)
            modelBuilder.Entity<Student>()
                .HasMany(s => s.Inquiries)
                .WithOne(i => i.Student)
                .HasForeignKey(i => i.studentID)
                .OnDelete(DeleteBehavior.Restrict);

            // Course to Students (One-to-Many)
            modelBuilder.Entity<Course>()
                .HasMany(c => c.Students)
                .WithOne(s => s.Course)
                .HasForeignKey(s => s.courseID)
                .OnDelete(DeleteBehavior.Restrict);

            // Student to AddDropRequests (One-to-Many)
            modelBuilder.Entity<Student>()
                .HasMany(s => s.AddDropRequests)
                .WithOne(ad => ad.Student)
                .HasForeignKey(ad => ad.studentID)
                .OnDelete(DeleteBehavior.Restrict);

            // Admin to AddDropRequests (One-to-Many, Optional)
            modelBuilder.Entity<Admin>()
                .HasMany(a => a.AddDropRequests)
                .WithOne(ad => ad.Admin)
                .HasForeignKey(ad => ad.adminID)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);

            // Course to Subjects (One-to-Many)
            modelBuilder.Entity<Course>()
                .HasMany(c => c.Subjects)
                .WithOne(s => s.Course)
                .HasForeignKey(s => s.courseID)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
=======
	public class AppDbContext : DbContext
	{
		public AppDbContext()
		{

		}

		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
		public DbSet<Admin> Admin { get; set; }
		public DbSet<Student> Student { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Admin>().HasData(
				new Admin { adminID = "A001", adminName = "Chong Pui Lin", adminEmail = "cpl@gmail.com", adminPassword = "chongpuilin" },
				new Admin { adminID = "A002", adminName = "Chong Fong Kim", adminEmail = "cfk@gmail.com", adminPassword = "chongfongkim" }
			);

			modelBuilder.Entity<Student>().HasData(
				new Student
				{
					studentID = "I22023292",
					courseID = "BCSI",
					studentEmail = "student@example.com",
					studentPassword = "hashedpassword123",
					studentName = "John Doe",
					primaryEmail = "johndoe@example.com",
					alternativeEmail = "john.alternate@example.com",
					TelNum = "+601234567890",
					HPNum = "+609876543210",
					permanantAddress = "123 Main Street",
					permanantPostalCode = 12345,
					permanantArea = "City Center",
					permanantState = "State A",
					permanantCountry = "Malaysia",
					currentAddress = "456 Elm Street",
					currentPostalCode = 67890,
					currentArea = "Downtown",
					currentState = "State B",
					currentCountry = "Malaysia",
					emergencyContactRelationship = "Father",
					emergencyContactName = "James Doe",
					emergencyHPNum = "+601122334455",
					bankName = "ABB: Affin Bank Berhad",
					bankAccountNumber = 1234567890,
					bankHolderName = "John Doe",
				}
			); 

            modelBuilder.Entity<Course>().HasData(
                new Course { courseID = "BCSI", courseName = "Bachelor in Computer Science" },
                new Course { courseID = "BITI", courseName = "Bachelor in Information Technology" }
            );
        }
	}
>>>>>>> origin/wy
}
