using Bogus;
using static GraphQL.API.Schema.Query.Query.CourseType;

namespace GraphQL.API.Schema.Query.Query
{
    public class Query
    {
        private readonly Faker<InstructorType> _instructorFaker;
        private readonly Faker<StudentType> _studentFaker;
        private readonly Faker<CourseType> _courseFaker;

        public Query()
        {

            _instructorFaker = new Faker<InstructorType>()
                   .RuleFor(c => c.Id, f => Guid.NewGuid())
                   .RuleFor(c => c.FirstName, f => f.Name.FirstName())
                   .RuleFor(c => c.LastName, f => f.Name.LastName())
                   .RuleFor(c => c.Email, f => f.Internet.Email())
                   .RuleFor(c => c.Salary, f => f.Random.Int(0, 50000));


            _studentFaker = new Faker<StudentType>()
                   .RuleFor(c => c.Id, f => Guid.NewGuid())
                   .RuleFor(c => c.FirstName, f => f.Name.FirstName())
                   .RuleFor(c => c.LastName, f => f.Name.LastName())
                   .RuleFor(c => c.CGPA, f => f.Random.Double(0, 4));

            _courseFaker = new Faker<CourseType>()
                   .RuleFor(c => c.Id, f => Guid.NewGuid())
                   .RuleFor(c => c.Name, f => f.Name.JobTitle())
                   .RuleFor(c => c.SubjectName, f => f.PickRandom<Subject>())
                   .RuleFor(c => c.Instructor, f => _instructorFaker.Generate())
                   .RuleFor(c => c.Students, f => _studentFaker.Generate(3));

        }
        public IEnumerable<CourseType> GetCourses()
        {
            return _courseFaker.Generate(5);
        }

        public async Task<CourseType> GetCourseById(Guid Id)
        {
            await Task.Delay(1000);
            CourseType course = _courseFaker.Generate();
            course.Id = Id;
            return course;

        }

        [GraphQLDeprecated("This query is not in use anymore, Please use the updated query")]
        public string Instructions => "Hello this is MOmin here";
    }
}
