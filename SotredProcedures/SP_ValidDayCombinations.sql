Create Procedure SP_ValidDayCombinations
@NumDays tinyint
AS
BEGIN
WITH DayCombinations AS (
        -- Generate all combinations for 5 days (Sunday to Thursday)
        SELECT 0 AS SUN, 0 AS MON, 0 AS TUE, 0 AS WED, 0 AS THU
        UNION ALL SELECT 1, 0, 0, 0, 0
        UNION ALL SELECT 0, 1, 0, 0, 0
        UNION ALL SELECT 0, 0, 1, 0, 0
        UNION ALL SELECT 0, 0, 0, 1, 0
        UNION ALL SELECT 0, 0, 0, 0, 1
        UNION ALL SELECT 1, 1, 0, 0, 0
        UNION ALL SELECT 1, 0, 1, 0, 0
        UNION ALL SELECT 1, 0, 0, 1, 0
        UNION ALL SELECT 1, 0, 0, 0, 1
        UNION ALL SELECT 0, 1, 1, 0, 0
        UNION ALL SELECT 0, 1, 0, 1, 0
        UNION ALL SELECT 0, 1, 0, 0, 1
        UNION ALL SELECT 0, 0, 1, 1, 0
        UNION ALL SELECT 0, 0, 1, 0, 1
        UNION ALL SELECT 0, 0, 0, 1, 1
        UNION ALL SELECT 1, 1, 1, 0, 0
        UNION ALL SELECT 1, 1, 0, 1, 0
        UNION ALL SELECT 1, 1, 0, 0, 1
        UNION ALL SELECT 1, 0, 1, 1, 0
        UNION ALL SELECT 1, 0, 1, 0, 1
        UNION ALL SELECT 1, 0, 0, 1, 1
        UNION ALL SELECT 0, 1, 1, 1, 0
        UNION ALL SELECT 0, 1, 1, 0, 1
        UNION ALL SELECT 0, 1, 0, 1, 1
        UNION ALL SELECT 0, 0, 1, 1, 1
        UNION ALL SELECT 1, 1, 1, 1, 0
        UNION ALL SELECT 1, 1, 1, 0, 1
        UNION ALL SELECT 1, 1, 0, 1, 1
        UNION ALL SELECT 1, 0, 1, 1, 1
        UNION ALL SELECT 0, 1, 1, 1, 1
        UNION ALL SELECT 1, 1, 1, 1, 1
    ),
    
    -- Step 2: Filter valid day combinations based on @NumDays
    ValidDayCombinations AS (
        SELECT SUN, MON, TUE, WED, THU
        FROM DayCombinations
        WHERE (SUN + MON + TUE + WED + THU) = @NumDays
    )
	SELECT * FROM ValidDayCombinations
	END;
