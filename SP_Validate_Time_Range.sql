Create PROCEDURE SP_Validate_Time_Range
    @StartTime TIME,
    @EndTime TIME
AS
BEGIN
    IF @StartTime >= @EndTime
    BEGIN
        RAISERROR('Invalid time range: StartTime must be earlier than EndTime.', 16, 1);
        RETURN;
    END
END;
