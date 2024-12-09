Create PROCEDURE SP_Get_Available_Enrollment_Courses
   
    @StudentNumber NVARCHAR(10)
AS
BEGIN
Declare  @StudentGradeLevel INT
Set @StudentGradeLevel=(Select GradeLevel From Students where UserId= (Select Id From Users where UserName =@StudentNumber) )

SET NOCOUNT ON;

    -- Declare a table variable to hold prerequisites
    DECLARE @Prerequisites TABLE (
        CourseID INT NOT NULL, 
        CourseCode NVARCHAR(10), 
        PrerequisiteCourseID INT NOT NULL
    );

    -- Populate the prerequisites table variable
    INSERT INTO @Prerequisites (CourseID, CourseCode, PrerequisiteCourseID)
    SELECT Id, CourseCode, PrerequisiteID
    FROM Courses
    WHERE PrerequisiteID IS NOT NULL; -- Corrected NULL comparison

    -- Common Table Expression to filter available courses by grade level
    WITH AvailableCourses AS
    (
        SELECT * 
        FROM Courses 
        WHERE CourseLevel = @StudentGradeLevel -- Filter courses by the specified grade level
    )

    -- Query to get available courses
    SELECT 
        ac.*
    FROM 
        AvailableCourses ac
    LEFT JOIN 
        Enrollments_View ev
        ON ac.CourseCode = ev.CourseCode AND ev.StudentNumber = @StudentNumber
    WHERE 
        (ev.CourseCode IS NULL OR ev.IsStudentPass = 0) -- Course not passed or no enrollment record
        AND ac.HasPrerequisite = 0 -- Course does not have prerequisites

    UNION ALL -- Combine results with the next query

    -- Get courses that have prerequisites and prerequisites are passed by the student
    SELECT 
        ac.*
    FROM 
        AvailableCourses ac
    INNER JOIN 
        @Prerequisites p
        ON ac.Id = p.CourseID -- Match available course with prerequisites
    INNER JOIN 
        Enrollments_View ev
        ON p.PrerequisiteCourseID = ev.CourseID -- Match prerequisites with enrollments
        AND ev.StudentNumber = @StudentNumber
    WHERE 
        ev.IsStudentPass = 1 -- Prerequisite course is passed
        AND ac.HasPrerequisite = 1; -- Course requires prerequisites

    SET NOCOUNT OFF;
END;
