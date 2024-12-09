Create PROCEDURE SP_Check_Section_Conflict
    @StartTime TIME,
    @EndTime TIME,
    @ClassName NVARCHAR(20),
    @SUN BIT,
    @MON BIT,
    @TUE BIT,
    @WED BIT,
    @THU BIT,
    @ANYCONFLICT BIT OUTPUT
AS
BEGIN
   

    -- Handle case when ClassName is not found
	IF NOT EXISTS
	(
    Select ClassName from Classes where ClassName=@ClassName
	)
    BEGIN
		RAISERROR('Class name not found.', 16, 1);
        RETURN;
    END


    -- Check for conflicts
    IF EXISTS (
        SELECT 1
        FROM Schedule_View
        WHERE 
            ClassName = @ClassName
            AND (@StartTime < EndTime AND @EndTime > StartTime) -- Time overlaps
            AND (
                (@SUN = 1 AND SUN = 1) OR
                (@MON = 1 AND MON = 1) OR
                (@TUE = 1 AND TUE = 1) OR
                (@WED = 1 AND WED = 1) OR
                (@THU = 1 AND THU = 1)
            )
    )
    BEGIN
        SET @ANYCONFLICT = 1; -- Conflict exists
    END
    ELSE
    BEGIN
        SET @ANYCONFLICT = 0; -- No conflict
    END
END;
