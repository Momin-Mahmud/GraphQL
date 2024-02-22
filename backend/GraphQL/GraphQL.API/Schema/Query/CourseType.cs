namespace GraphQL.API.Schema.Query.Query
{
    public class CourseType
    {

        public enum Subject
        {
            Maths,
            Science,
            English,
            History,
            Coding
        }
        public Guid Id { get; set; }
        public string Name { get; set; }

        public Subject SubjectName { get; set; }

        public InstructorType Instructor { get; set; }
        public IEnumerable<StudentType> Students { get; set; }
    }
}
