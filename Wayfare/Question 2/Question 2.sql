-- For a given Student get all the Grades that they got. We need the following items: Student.name, Grade.grade, Course.courseName.

SELECT Student.name, Grade.grade, Course.courseName
FROM Student
JOIN Grade ON Student.id = Grade.studentId
JOIN Course ON Grade.courseId = Course.id
WHERE Student.name = '<name>'
