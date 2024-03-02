using Bogus;
using System.Collections;

namespace GraphQL.Demo.API.Schema.Queries
{
    public class Query
    {
        private List<CourseType> _courses;
        public Query()
        {
            _courses = GenerateCourses();
        }

        public IEnumerable<CourseType> GetCourses() =>
            _courses;

        private List<CourseType> GenerateCourses()
        {
            var faker = new Faker();

            var courseList = new List<CourseType>();

            for (int i = 0; i < 20; i++)
            {
                var course = new CourseType
                {
                    Id = Guid.NewGuid(),
                    Name = faker.Random.Word(),
                    Subject = faker.PickRandom<Subject>(),
                    Instructor = new InstructorType
                    {
                        Id = Guid.NewGuid(),
                        FirstName = faker.Name.FirstName(),
                        LastName = faker.Name.LastName(),
                        Salary = faker.Random.Double(30000, 80000)
                    },
                    Students = GenerateFakeStudents()
                };

                courseList.Add(course);
            }

            return courseList;
        }

        [GraphQLDeprecated("This query is deprecated.")]
        public string Instructions { get; } = "Struction to be added in query";

        public CourseType GetCourseById(Guid courseId) =>
            _courses.FirstOrDefault(c => c.Id == courseId);


        private IEnumerable<StudentType> GenerateFakeStudents()
        {
            var faker = new Faker();
            var studentList = new List<StudentType>();

            for (int i = 0; i < 5; i++) // Assuming 5 students per course
            {
                var student = new StudentType
                {
                    Id = Guid.NewGuid(),
                    FirstName = faker.Name.FirstName(),
                    LastName = faker.Name.LastName(),
                    GPA = faker.Random.Double(2.0, 4.0)
                };

                studentList.Add(student);
            }

            return studentList;
        }
    }
}
