Create PROCEDURE SP_GetSectionEnrollmentConflict
    @SectionNumber NVARCHAR(4),
    @StudentNumber NVARCHAR(100),
    @AnyConflict BIT OUTPUT
AS
BEGIN
    -- Initialize the output variable
    SET @AnyConflict = 0;

    -- Check for conflicts
    IF EXISTS (
        SELECT 1
        FROM Schedule_View AS s1
        INNER JOIN (
            SELECT SectionNumber, StartTime, EndTime, SUN, MON, TUE, WED, THU
            FROM Schedule_View 
            WHERE SectionNumber IN (
                SELECT SectionNumber 
                FROM Enrollments_View 
                WHERE StudentNumber = @StudentNumber AND IsStudentPass IS NULL
            )
        ) AS s2 ON s1.SectionNumber = @SectionNumber
        WHERE 
            (s1.StartTime < s2.EndTime AND s1.EndTime > s2.StartTime) -- Overlap condition
            AND (
                s1.SUN = s2.SUN OR
                s1.MON = s2.MON OR
                s1.TUE = s2.TUE OR
                s1.WED = s2.WED OR
                s1.THU = s2.THU
            )
    )
    BEGIN
        -- Set @AnyConflict to 1 if any conflict exists
        SET @AnyConflict = 1;
    END
END;