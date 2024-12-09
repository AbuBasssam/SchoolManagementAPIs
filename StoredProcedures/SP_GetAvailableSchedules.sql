Create  PROCEDURE SP_GetAvailableSchedules
    @StartTime TIME(0),
    @EndTime TIME(0),
    @TimesPerWeek TINYINT,
	@ClassName NVARCHAR(20)
AS
BEGIN
    -- Step 1: Validate the Time Range
    EXEC SP_Validate_Time_Range
        @StartTime,
        @EndTime;
    IF @@ERROR <> 0
    BEGIN
        RETURN;
    END

	 -- Step 2: Validate ClassName
    EXEC SP_Check_Class_Exists
        @ClassName
       
    IF @@ERROR <> 0
    BEGIN
        RETURN;
    END


    -- Step 3: Generate Valid Day Combinations
    DECLARE @DayCombinations TABLE (SUN BIT, MON BIT, TUE BIT, WED BIT, THU BIT);
    INSERT INTO @DayCombinations
    EXEC SP_ValidDayCombinations @TimesPerWeek;

    -- Step 4: Generate Available Time Ranges
    DECLARE @AvailableTimes TABLE (StartTime TIME(0), EndTime TIME(0));
    INSERT INTO @AvailableTimes
    EXEC SP_AvailableTimes @StartTime, @EndTime;

 
 
-- Step 5: Combine Valid Day and Time Combinations for all Classes

 SELECT 
        v.SUN,
        v.MON,
        v.TUE,
        v.WED,
        v.THU,
        AT.StartTime,
        AT.EndTime
    FROM @DayCombinations v
    CROSS JOIN @AvailableTimes AT
    WHERE NOT EXISTS (
        -- Exclude any overlapping schedules by time with the existing schedules
        SELECT 1
        FROM Schedule_View sv
        WHERE sv.ClassName = @ClassName
        AND (
            (AT.StartTime < sv.EndTime AND AT.EndTime > sv.StartTime) -- Overlapping times
            AND (
                (v.SUN = 1 AND sv.SUN = 1) OR
                (v.MON = 1 AND sv.MON = 1) OR
                (v.TUE = 1 AND sv.TUE = 1) OR
                (v.WED = 1 AND sv.WED = 1) OR
                (v.THU = 1 AND sv.THU = 1)
            ) -- Overlapping days
        )
    )
    ORDER BY AT.StartTime, AT.EndTime;
END;
