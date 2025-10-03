connectstring in current session only
$env:MYSQLConnection="server=localhost;port=3306;database=studentcrud;user=root;password=yourpassword"

connectstring permanent
[System.Environment]::SetEnvironmentVariable("STUDENT_CRUD_DB", "server=localhost;port=3306;database=studentcrud;user=root;password=yourpassword", "User")
