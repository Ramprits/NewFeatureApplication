Use NewApplication
SELECT * FROM MST.Department

-- Insert rows into table 'MST.Department'
INSERT INTO MST.Department
( -- columns to insert data into
 [DepartmentId], [Name], [CreatedDate],[LastModified]
)
VALUES
( -- first row: values for the columns in the list above
 '60d206dc-8d18-450e-b4a5-cbaec9b672c8',
  'Web Developer', '2017-11-16 12:31:07.093',
  '2017-11-16 12:31:07.093'
),
( 
 '98ea569c-9d42-4e98-8cb7-6519d2440032',
 'Team Leader',
 '2017-11-16 12:35:13.063',
 '2017-11-16 12:35:13.063'
)
-- add more rows here
GO

SELECT Newid()
SELECT getdate()