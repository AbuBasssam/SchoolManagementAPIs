Create PROCEDURE SP_Section_Filter
@SectionType BIT=NULL,
@CourseCode NVARCHAR(10)=NULL,
@TeacherID INT =NULL
 AS
BEGIN

SELECT s.SectionNumber,s.SectionType ,c.CourseCode,s.TeacherID 
FROM Sections s INNER JOIN courses c
on  s.CourseID=c.Id
WHERE
(
    (@SectionType IS NULL OR SectionType=@SectionType)AND
	(@CourseCode IS NULL OR c.CourseCode=@CourseCode) AND
    (@TeacherID IS NULL OR TeacherID=@TeacherID)
 
 )
	
	END;
