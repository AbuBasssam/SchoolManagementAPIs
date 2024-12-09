Create PROCEDURE SP_Available_Enrolled_Section
    @StudentNumber NVARCHAR(10),
	@CourseCode NVARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;

    -- Step 1: Temporary table to store available courses with all columns from SP_Get_Available_Enrollment_Courses_V3
    CREATE TABLE #AvailableCourses
    (
        Id INT,
        CourseCode NVARCHAR(20),
        CourseName NVARCHAR(50),
        CourseHours TINYINT,
        CourseLevel TINYINT,
        HasPractical BIT,
        HasPrerequisite BIT,
        PrerequisiteID INT NULL
    );

    -- Step 2: Populate the temporary table with results from SP_Get_Available_Enrollment_Courses_V3
    INSERT INTO #AvailableCourses (Id, CourseCode, CourseName, CourseHours, CourseLevel, HasPractical, HasPrerequisite, PrerequisiteID)
    EXEC SP_Get_Available_Enrollment_Courses @StudentNumber;

    -- Step 3: Fetch sections for the available courses
	Select ss.SectionNumber, 
        R1.CourseCode, 
        R1.ClassName,
		R1.SUN,
		R1.MON,
		R1.TUE,
		R1.WED,
		R1.THU,
		R1.StartTime,
        R1.EndTime From (
    SELECT 
        s.SectionNumber, 
        s.CourseCode, 
        s.ClassName,
		s.SUN,
		s.MON,
		s.TUE,
		S.WED,
		s.THU,
        s.StartTime,
        s.EndTime
    FROM Schedule_View s
    INNER JOIN #AvailableCourses ac
        ON s.CourseCode = ac.CourseCode
		)R1 INNER JOIN Sections ss on ss.SectionNumber= r1.SectionNumber
		where SectionType=0 and IsOpen=1 and CourseCode=@CourseCode

    -- Step 4: Clean up the temporary table
    DROP TABLE #AvailableCourses;
END;