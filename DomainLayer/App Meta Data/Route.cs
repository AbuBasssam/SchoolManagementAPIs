namespace DomainLayer.App_Meta_Data
{
    public static class Router
    {
        private const string _root = "api";
        private const string _version = "v1";

        // api/v1
        private const string _rule = _root + "/" + _version;

        // sub routes
        // api/v1/Student/{Id}
        private const string _ById = "/{Id}";

        // api/v1/<Controller>/query? key=value & key=value
        private const string _Query = "/query";

        public class ClassRouter()
        {

            public const string BASE = _rule + "/class";
            public const string ByClassName = BASE + "/Name/{ClassName}";
            public const string ById = BASE + _ById;
            public const string Filter = BASE + "/Filter";
            public const string Query = BASE + _Query;
        }


        public class MedicalConditionRouter()
        {

            public const string BASE = _rule + "/MedicalCondition";
            public const string ByMedicalConditionName = BASE + "Name/{MedicalConditionName}";
            public const string ById = BASE + _ById;
            public const string Query = BASE + _Query;
        }


        public class CourseRouter()
        {

            public const string BASE = _rule + "/Course";
            public const string ByCourseName = BASE + "/Name/{CourseName}";
            public const string ByCourseCode = BASE + "/Code/{CourseCode}";
            public const string Filter = BASE + "/Filter";

            public const string ById = BASE + _ById;
            public const string Query = BASE + _Query;
            public const string UpdatePrerequisite = BASE + "/Update/Prerequisite/{CourseCode},{PrerequisiteCourseCode}";
            public const string AddPrerequisite = BASE + "/Add/Prerequisite/{CourseCode},{PrerequisiteCourseCode}";

        }
        public class EmplymentDetailsRouter()
        {

            public const string BASE = _rule + "/EmplymentDetails";
            public const string ByTeacherNumber = BASE + "/Number/{TeacherNumber}";
            public const string ById = BASE + _ById;
            public const string Query = BASE + _Query;

        }
        public class SectionRouter()
        {

            public const string BASE = _rule + "/Section";
            public const string BySectionNumber = BASE + "/Number/{SectionNumber}";
            public const string ById = BASE + _ById;
            public const string Filter = BASE + "/Filter";
            public const string Query = BASE + _Query;
            public const string UpdateSchedule = BASE + "/Update/Schedule";
            public const string Close = BASE + "/Close/{SectionNumber}";
            public const string AssignSectionTeacher = BASE + "/assign-teacher";


        }
        public class StudentRouter()
        {

            public const string BASE = _rule + "/Student";
            public const string ByStudentNumber = BASE + "/Number/{StudentNumber}";
            public const string ById = BASE + _ById;
            public const string Filter = BASE + "/Filter";
            public const string Query = BASE + _Query;
            public const string ChangePassword = BASE + "/ChangePassword";

        }

        public class ScheduleRouter()
        {
            public const string BASE = _rule + "/Schedule";

            public const string Query = BASE + _Query;
            public const string AvailableSchedules = BASE + "/AvailableSchedules";

        }

        public class TeacherRouter()
        {

            public const string BASE = _rule + "/Teacher";
            public const string ByTeacherNumber = BASE + "/Number/{TeacherNumber}";
            public const string ById = BASE + _ById;
            public const string Filter = BASE + "/Filter";
            public const string ChangePassword = BASE + "/ChangePassword";
            public const string Query = BASE + _Query;
        }


        public class UserRouter()
        {
            public const string BASE = _rule + "/user";
            public const string ById = BASE + _ById;
            public const string ByUserName = BASE + "/Name/{UserName}";
            public const string Query = BASE + _Query;
            public const string ChangePassword = BASE + _ById + "/change-password";

            public class WithRoles()
            {
                public const string BASE = UserRouter.BASE + "/roles";
                public const string ById = BASE + _ById;
            }
        }
        public class AuthenticationRouter()
        {
            public const string BASE = _rule + "/authentication";
            public const string SignIn = BASE + "/signin";
            public const string RefreshToken = BASE + "/refresh-token";
            public const string ValidateRefreshToken = BASE + "/validate-refresh-token/{token}";
            public const string Logout = BASE + "logout";
        }

        public class AuthorizationRouter()
        {
            public const string BASE = _rule + "/authorization";
            public const string ById = BASE + _ById;
            public const string Query = BASE + _Query;
            public const string UpdateUserRole = BASE + "/UpdateUserRole";
            public const string ManageUserClaims = BASE + "/ManageUserClaims/{UserName}";
            public const string UpdateUserClaims = BASE + "/UpdateUserClaims";

            public class RoleRouter()
            {
                public const string BASE = _rule + "/role";
                public const string ById = BASE + _ById;
                public const string Query = BASE + _Query;
            }
        }

        public class EnrollmentRouter()
        {
            public const string BASE = _rule + "/Enrollment";

            public const string AvailableCourses = _rule + "/AvailableEnrollmentCourses";
            public const string Query = BASE + _Query;



        }
    }

}
