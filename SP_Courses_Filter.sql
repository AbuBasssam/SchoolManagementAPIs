Create PROCEDURE SP_Courses_Filter
    @CourseHours TINYINT = NULL,
    @CourseLevel TINYINT = NULL,
    @HasPractical BIT = NULL,
    @HasPrerequisite BIT = NULL,
	@PageSize INT = 10,
	@PageNumber INT
AS
BEGIN
    -- Declare variables for total count and page count
    DECLARE @TotalCount INT;
    DECLARE @PageCount INT;

  
  --All filter results
   with Filter_Result AS
   (
	SELECT COUNT(*) As TotalCount 
    FROM Courses
    WHERE (@CourseHours IS NULL OR CourseHours = @CourseHours)
      AND (@CourseLevel IS NULL OR CourseLevel = @CourseLevel)
      AND (@HasPractical IS NULL OR HasPractical = @HasPractical)
      AND (@HasPrerequisite IS NULL OR HasPrerequisite = @HasPrerequisite)
	)
	Select @TotalCount=TotalCount From Filter_Result  


    -- Calculate the number of pages based on the page size
    SET @PageCount = CEILING(CAST(@TotalCount AS FLOAT) / @PageSize);

    -- Select the filtered results Page
	with Filter_Result_Page AS
	(
   SELECT 
    c.CourseCode,
    c.CourseName,
    c.CourseHours,
    c.CourseLevel,
    c.HasPractical,
    c.HasPrerequisite,
    p.CourseCode AS PrerequisiteCourseCode
FROM 
    Courses c
LEFT JOIN 
    Courses p ON c.PrerequisiteID = p.Id 
    WHERE (@CourseHours IS NULL OR c.CourseHours = @CourseHours)
      AND (@CourseLevel IS NULL OR c.CourseLevel = @CourseLevel)
      AND (@HasPractical IS NULL OR c.HasPractical = @HasPractical)
      AND (@HasPrerequisite IS NULL OR c.HasPrerequisite = @HasPrerequisite)order by c.Id
	  OFFSET (@PageNumber - 1) * @PageSize ROWS
     FETCH NEXT @PageSize ROWS ONLY
	 )
	 Select * From Filter_Result_Page

    -- Return  filter results and number of pages
    SELECT @TotalCount AS TotalCount, @PageCount AS PageCount;
END
