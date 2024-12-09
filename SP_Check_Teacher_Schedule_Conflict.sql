Create PROCEDURE SP_Check_Teacher_Schedule_Conflict
    @StartTime TIME,
    @EndTime TIME,
    @ClassName NVARCHAR(20),
    @TeacherNumber NVARCHAR(50),
    @SUN BIT,
    @MON BIT,
    @TUE BIT,
    @WED BIT,
    @THU BIT
AS
BEGIN
 -- Validate the time range
    EXEC SP_Validate_Time_Range
	@StartTime,
	@EndTime;
    IF @@ERROR <> 0
    BEGIN
        RETURN;
    END

    -- Check if the class exists
    EXEC SP_Check_Class_Exists
	@ClassName;
    IF @@ERROR <> 0
    BEGIN
        RETURN;
    END

    SELECT SectionNumber,
        StartTime ,
        EndTime ,
         SUN,
	     MON,
		 TUE,
		 WED,
		 THU  
    FROM Schedule_View
    WHERE (TeacherNumber= @TeacherNumber)
	
    AND (@StartTime < EndTime AND @EndTime > StartTime) -- Time overlaps
    AND (
			(@SUN = 1 AND SUN = 1) OR
            (@MON = 1 AND MON = 1) OR
            (@TUE = 1 AND TUE = 1) OR
            (@WED = 1 AND WED = 1) OR
            (@THU = 1 AND THU = 1)
        );
END;