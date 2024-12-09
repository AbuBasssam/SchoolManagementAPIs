Create PROCEDURE SP_AvailableTimes
@StartTime TIME(0),
@EndTime TIME(0)
AS 
BEGIN

WITH AvailableTimes AS (
        SELECT DISTINCT StartTime, EndTime
        FROM Schedules
        WHERE StartTime >= @StartTime
          AND EndTime <= @EndTime
    )
	SELECT * FROM AvailableTimes
END;
