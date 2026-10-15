/* =====================================================================
   CoursesAcademy - Fake seed data (for CRUD testing)
   الاستخدام: Restore الـ backup الأول، وبعدين شغّل السكربت ده في SSMS.
   الأسماء بالإنجليزي لأن الأعمدة varchar (مش nvarchar).
   ===================================================================== */
USE CoursesAcademy;
GO

SET NOCOUNT ON;
SET XACT_ABORT ON;   -- لو أي سطر فشل، كله يتلغي (ملوش نص نص)

BEGIN TRAN;

/* ---------------------------------------------------------------------
   اختياري: لو عايز تمسح البيانات القديمة وتبدأ من جديد، شيل التعليق
   --------------------------------------------------------------------- */
-- DELETE FROM Student_Take_Course;
-- DELETE FROM Instructor_Teach_Course;
-- DELETE FROM Student;
-- UPDATE Department SET InstId = NULL;
-- DELETE FROM Instructor;
-- DELETE FROM Department;
-- DELETE FROM Course;
-- DELETE FROM Topic;

/* ---------------------------------------------------------------------
   1) Topic
   --------------------------------------------------------------------- */
INSERT INTO Topic (Name) VALUES
('Programming'),
('Databases'),
('Web Development'),
('Networking'),
('Embedded Systems');

/* ---------------------------------------------------------------------
   2) Course   (TopicId بيتجاب بالاسم)
   Duration بالساعات
   --------------------------------------------------------------------- */
INSERT INTO Course (Name, Duration, Description, TopicId) VALUES
('C# Fundamentals',           40, 'Basics of C# syntax, OOP and collections.',              (SELECT Id FROM Topic WHERE Name = 'Programming')),
('Data Structures',           45, 'Arrays, linked lists, stacks, queues and trees.',        (SELECT Id FROM Topic WHERE Name = 'Programming')),
('Python for Beginners',      30, 'Introduction to Python programming.',                    (SELECT Id FROM Topic WHERE Name = 'Programming')),
('SQL Server Essentials',     35, 'Tables, queries, joins and constraints.',                (SELECT Id FROM Topic WHERE Name = 'Databases')),
('Advanced T-SQL',            30, 'Stored procedures, triggers and performance tuning.',    (SELECT Id FROM Topic WHERE Name = 'Databases')),
('ASP.NET Core Web API',      50, 'Building REST APIs with ASP.NET Core and EF Core.',     (SELECT Id FROM Topic WHERE Name = 'Web Development')),
('HTML, CSS and JavaScript',  40, 'Front-end fundamentals.',                                (SELECT Id FROM Topic WHERE Name = 'Web Development')),
('Computer Networks',         36, 'OSI model, TCP/IP, routing and switching.',              (SELECT Id FROM Topic WHERE Name = 'Networking')),
('Microcontrollers with ESP32', 42, 'GPIO, sensors, I2C/SPI and Wi-Fi on ESP32.',           (SELECT Id FROM Topic WHERE Name = 'Embedded Systems')),
('Embedded C',                38, 'C programming for embedded targets.',                    (SELECT Id FROM Topic WHERE Name = 'Embedded Systems'));

/* ---------------------------------------------------------------------
   3) Department
   مؤقتًا InstId = NULL، لأن Instructor لسه مش موجود
   (Department -> Instructor كمدير، و Instructor -> Department)
   --------------------------------------------------------------------- */
INSERT INTO Department (Name, Hiring_Date, InstId) VALUES
('Computer Science',          '2018-09-01', NULL),
('Information Systems',       '2019-02-15', NULL),
('Electronics Engineering',   '2020-01-10', NULL),
('Networks and Security',     '2021-06-01', NULL);

/* ---------------------------------------------------------------------
   4) Instructor
   --------------------------------------------------------------------- */
INSERT INTO Instructor (Name, Bonus, Salary, Hour_Rate, Address, DptId) VALUES
('Dr. Ahmed Hassan',   2500.00, 18000.00, 150.00, 'Cairo',      (SELECT Id FROM Department WHERE Name = 'Computer Science')),
('Dr. Mona Ibrahim',   2000.00, 16500.00, 140.00, 'Giza',       (SELECT Id FROM Department WHERE Name = 'Information Systems')),
('Eng. Khaled Samir',  1500.00, 14000.00, 120.00, 'Hurghada',   (SELECT Id FROM Department WHERE Name = 'Electronics Engineering')),
('Dr. Sara Mahmoud',   2200.00, 17000.00, 145.00, 'Alexandria', (SELECT Id FROM Department WHERE Name = 'Computer Science')),
('Eng. Omar Nabil',    1000.00, 12000.00, 100.00, 'Mansoura',   (SELECT Id FROM Department WHERE Name = 'Networks and Security')),
('Dr. Heba Farouk',    1800.00, 15500.00, 130.00, 'Cairo',      (SELECT Id FROM Department WHERE Name = 'Information Systems'));

/* ---------------------------------------------------------------------
   5) تعيين مدير لكل قسم
   --------------------------------------------------------------------- */
UPDATE Department SET InstId = (SELECT Id FROM Instructor WHERE Name = 'Dr. Ahmed Hassan')  WHERE Name = 'Computer Science';
UPDATE Department SET InstId = (SELECT Id FROM Instructor WHERE Name = 'Dr. Mona Ibrahim')  WHERE Name = 'Information Systems';
UPDATE Department SET InstId = (SELECT Id FROM Instructor WHERE Name = 'Eng. Khaled Samir') WHERE Name = 'Electronics Engineering';
UPDATE Department SET InstId = (SELECT Id FROM Instructor WHERE Name = 'Eng. Omar Nabil')   WHERE Name = 'Networks and Security';

/* ---------------------------------------------------------------------
   6) Student
   --------------------------------------------------------------------- */
INSERT INTO Student (FName, LName, Age, Address, DptId) VALUES
('Mohamed',  'Ali',      21, 'Cairo',      (SELECT Id FROM Department WHERE Name = 'Computer Science')),
('Youssef',  'Adel',     22, 'Giza',       (SELECT Id FROM Department WHERE Name = 'Computer Science')),
('Fatma',    'Saeed',    20, 'Alexandria', (SELECT Id FROM Department WHERE Name = 'Computer Science')),
('Nour',     'Hamdy',    23, 'Hurghada',   (SELECT Id FROM Department WHERE Name = 'Electronics Engineering')),
('Mostafa',  'Gamal',    21, 'Luxor',      (SELECT Id FROM Department WHERE Name = 'Electronics Engineering')),
('Aya',      'Tarek',    19, 'Cairo',      (SELECT Id FROM Department WHERE Name = 'Information Systems')),
('Karim',    'Walid',    24, 'Mansoura',   (SELECT Id FROM Department WHERE Name = 'Networks and Security')),
('Salma',    'Reda',     20, 'Tanta',      (SELECT Id FROM Department WHERE Name = 'Information Systems')),
('Hassan',   'Fawzy',    22, 'Aswan',      (SELECT Id FROM Department WHERE Name = 'Networks and Security')),
('Mariam',   'Essam',    21, 'Giza',       (SELECT Id FROM Department WHERE Name = 'Computer Science')),
('Ali',      'Mansour',  25, 'Suez',       (SELECT Id FROM Department WHERE Name = 'Electronics Engineering')),
('Dina',     'Kamal',    20, 'Cairo',      (SELECT Id FROM Department WHERE Name = 'Information Systems')),
('Ibrahim',  'Sherif',   23, 'Hurghada',   (SELECT Id FROM Department WHERE Name = 'Computer Science')),
('Rana',     'Ashraf',   19, 'Alexandria', (SELECT Id FROM Department WHERE Name = 'Information Systems')),
('Tamer',    'Zaki',     22, 'Port Said',  (SELECT Id FROM Department WHERE Name = 'Networks and Security'));

/* ---------------------------------------------------------------------
   7) Instructor_Teach_Course   (Evaluation من 1 لـ 5)
   --------------------------------------------------------------------- */
INSERT INTO Instructor_Teach_Course (InstId, CrsId, Evaluation) VALUES
((SELECT Id FROM Instructor WHERE Name = 'Dr. Ahmed Hassan'),  (SELECT Id FROM Course WHERE Name = 'C# Fundamentals'),            5),
((SELECT Id FROM Instructor WHERE Name = 'Dr. Ahmed Hassan'),  (SELECT Id FROM Course WHERE Name = 'Data Structures'),            4),
((SELECT Id FROM Instructor WHERE Name = 'Dr. Sara Mahmoud'),  (SELECT Id FROM Course WHERE Name = 'Python for Beginners'),       4),
((SELECT Id FROM Instructor WHERE Name = 'Dr. Sara Mahmoud'),  (SELECT Id FROM Course WHERE Name = 'ASP.NET Core Web API'),       5),
((SELECT Id FROM Instructor WHERE Name = 'Dr. Mona Ibrahim'),  (SELECT Id FROM Course WHERE Name = 'SQL Server Essentials'),      5),
((SELECT Id FROM Instructor WHERE Name = 'Dr. Mona Ibrahim'),  (SELECT Id FROM Course WHERE Name = 'Advanced T-SQL'),            4),
((SELECT Id FROM Instructor WHERE Name = 'Dr. Heba Farouk'),   (SELECT Id FROM Course WHERE Name = 'HTML, CSS and JavaScript'),   3),
((SELECT Id FROM Instructor WHERE Name = 'Dr. Heba Farouk'),   (SELECT Id FROM Course WHERE Name = 'SQL Server Essentials'),      4),
((SELECT Id FROM Instructor WHERE Name = 'Eng. Khaled Samir'), (SELECT Id FROM Course WHERE Name = 'Microcontrollers with ESP32'), 5),
((SELECT Id FROM Instructor WHERE Name = 'Eng. Khaled Samir'), (SELECT Id FROM Course WHERE Name = 'Embedded C'),                4),
((SELECT Id FROM Instructor WHERE Name = 'Eng. Omar Nabil'),   (SELECT Id FROM Course WHERE Name = 'Computer Networks'),         4),
((SELECT Id FROM Instructor WHERE Name = 'Eng. Omar Nabil'),   (SELECT Id FROM Course WHERE Name = 'Python for Beginners'),       3);

/* ---------------------------------------------------------------------
   8) Student_Take_Course   (Grade من 0 لـ 100)
   --------------------------------------------------------------------- */
INSERT INTO Student_Take_Course (StdId, CrsId, Grade)
SELECT s.Id, c.Id, v.Grade
FROM (VALUES
    ('Mohamed',  'C# Fundamentals',             88),
    ('Mohamed',  'Data Structures',             76),
    ('Mohamed',  'SQL Server Essentials',       91),
    ('Youssef',  'C# Fundamentals',             69),
    ('Youssef',  'ASP.NET Core Web API',        82),
    ('Fatma',    'Python for Beginners',        95),
    ('Fatma',    'Data Structures',             84),
    ('Nour',     'Microcontrollers with ESP32', 90),
    ('Nour',     'Embedded C',                  86),
    ('Mostafa',  'Embedded C',                  72),
    ('Mostafa',  'Microcontrollers with ESP32', 65),
    ('Aya',      'SQL Server Essentials',       93),
    ('Aya',      'HTML, CSS and JavaScript',    80),
    ('Karim',    'Computer Networks',           77),
    ('Karim',    'Python for Beginners',        70),
    ('Salma',    'SQL Server Essentials',       85),
    ('Salma',    'Advanced T-SQL',              79),
    ('Hassan',   'Computer Networks',           68),
    ('Mariam',   'C# Fundamentals',             92),
    ('Mariam',   'ASP.NET Core Web API',        89),
    ('Ali',      'Embedded C',                  74),
    ('Dina',     'HTML, CSS and JavaScript',    87),
    ('Dina',     'SQL Server Essentials',       81),
    ('Ibrahim',  'Data Structures',             78),
    ('Ibrahim',  'ASP.NET Core Web API',        83),
    ('Rana',     'HTML, CSS and JavaScript',    90),
    ('Tamer',    'Computer Networks',           73),
    ('Tamer',    'Python for Beginners',        66)
) AS v (FName, CourseName, Grade)
JOIN Student s ON s.FName = v.FName
JOIN Course  c ON c.Name  = v.CourseName;

COMMIT TRAN;

/* ---------------------------------------------------------------------
   تأكيد سريع: عدد الصفوف في كل جدول
   --------------------------------------------------------------------- */
SELECT 'Topic'                   AS TableName, COUNT(*) AS Total FROM Topic
UNION ALL SELECT 'Course',                  COUNT(*) FROM Course
UNION ALL SELECT 'Department',              COUNT(*) FROM Department
UNION ALL SELECT 'Instructor',              COUNT(*) FROM Instructor
UNION ALL SELECT 'Student',                 COUNT(*) FROM Student
UNION ALL SELECT 'Instructor_Teach_Course', COUNT(*) FROM Instructor_Teach_Course
UNION ALL SELECT 'Student_Take_Course',     COUNT(*) FROM Student_Take_Course;
