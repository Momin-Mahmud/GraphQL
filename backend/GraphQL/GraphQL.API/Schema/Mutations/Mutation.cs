using GraphQL.API.Schema.Query.Query;
using static GraphQL.API.Schema.Query.Query.CourseType;

namespace GraphQL.API.Schema.Mutations
{
    public class Mutation
    {

        private List<CourseResult> _courses;

        public Mutation()
        {
            _courses = new List<CourseResult>();
        }

        public CourseResult CreatedCourse(string name, Subject subject, Guid instructorID)
        {
            CourseResult courseType = new CourseResult()
            {
                Id =  Guid.NewGuid(), 
                Name = name,
                subject = subject,
                InstructorID = instructorID
            };

            _courses.Add(courseType);

            return courseType;
        }

        public CourseResult UpdateCourse (Guid id, string name,  Subject subject, Guid instructorID) {

            var course = _courses.FirstOrDefault(c => c.Id == id);

            if(course == null)
            {
                throw new  GraphQLException(new Error("Course not Found", "404"));
            }
            course.Name = name;
            course.subject = subject;
            course.InstructorID = instructorID;

            return course;
        
        }

        public bool DeleteCourse (Guid id)
        {
            var course = _courses.FirstOrDefault(c=>c.Id == id);

            if(course == null)
            {
                throw new GraphQLException( new Error("Not Found", "404"));
            }

            _courses.Remove(course);

            return true;
        }
    }
}
