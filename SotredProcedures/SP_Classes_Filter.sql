Create PROCEDURE SP_Classes_Filter
 @ClassType bit=NULL,
 @ClassCapacity tinyint=NULL,
 @ComparisonType tinyint=1
 AS
BEGIN
 

 
DECLARE @ClassTypeFilter TABLE(Id INT,ClassName VARCHAR(100) , ClassType bit,ClassCapacity tinyint)
insert into @ClassTypeFilter
  SELECT *
    FROM Classes
    WHERE
        (@ClassType IS NULL OR ClassType = @ClassType)




if( @ClassCapacity IS NULL)
BEGIN
SELECT * FROM @ClassTypeFilter
END

ELSE
BEGIN
SELECT * FROM @ClassTypeFilter
    WHERE(@ComparisonType IS NULL OR
	((@ComparisonType = 1 AND ClassCapacity = @ClassCapacity) OR
     (@ComparisonType = 2 AND ClassCapacity > @ClassCapacity) OR
     (@ComparisonType = 3 AND ClassCapacity < @ClassCapacity) OR
     (@ComparisonType = 4 AND ClassCapacity >= @ClassCapacity) OR
     (@ComparisonType = 5 AND ClassCapacity <= @ClassCapacity) 
	))
	
	END
END
