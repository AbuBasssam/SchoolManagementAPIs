Create PROCEDURE SP_Check_Class_Exists
    @ClassName NVARCHAR(20)
AS
BEGIN
    IF NOT EXISTS (SELECT 1 FROM Classes WHERE ClassName = @ClassName)
    BEGIN
        RAISERROR('Class name not found.', 16, 1);
        RETURN;
    END
END;
