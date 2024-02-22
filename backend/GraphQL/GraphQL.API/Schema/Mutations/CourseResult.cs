using static GraphQL.API.Schema.Query.Query.CourseType;

namespace GraphQL.API.Schema.Mutations
{
    public class CourseResult
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public Subject subject { get; set; }

        public Guid InstructorID { get; set; }
    }
}
