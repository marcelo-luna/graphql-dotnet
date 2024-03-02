namespace GraphQL.Demo.API.Schema
{
    public class CourseType
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Subject Subject { get; set; }

        [GraphQLNonNullType]
        public InstructorType Instructor { get; set; }
        public IEnumerable<StudentType> Students { get; set; }
        public string Description => $"This is the course of {Name} presented by {Instructor.FirstName } of Subject {Subject}";
    }

    public enum Subject
    {
        Mathematics,
        Science,
        History
    }
}
