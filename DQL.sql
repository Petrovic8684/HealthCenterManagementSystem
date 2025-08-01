SELECT 
    TABLE_NAME,
    COLUMN_NAME,
    DATA_TYPE,
    CHARACTER_MAXIMUM_LENGTH,
    IS_NULLABLE,
    COLUMN_DEFAULT
FROM INFORMATION_SCHEMA.COLUMNS
WHERE TABLE_NAME = 'lekar';

SELECT 
    t.name AS TableName,
    c.name AS ColumnName,
    cc.name AS CheckConstraintName,
    cc.definition AS CheckDefinition
FROM sys.check_constraints cc
JOIN sys.objects t ON cc.parent_object_id = t.object_id
JOIN sys.columns c ON cc.parent_object_id = c.object_id 
                   AND cc.parent_column_id = c.column_id
WHERE t.type = 'U' AND t.name = 'lekar';
