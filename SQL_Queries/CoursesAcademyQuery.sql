create database CoursesAcademy

create table Student
(
	Id int primary key identity(1,1),
	FName varchar(max) not null,
	LName varchar(max) not null,
	Age int not null,
	Address varchar(max) null,
)

create table Course 
(
	Id int primary key identity(1,1),
	Name varchar(max) not null,
	Duration int not null,-- Duration with hours
	Description varchar(max) not null,
)

create table Topic
(
	Id int primary key identity(1,1),
	Name varchar(max) not null,
)

create table Department
(
	Id int primary key identity(1,1),
	Name varchar(max) not null,
	Hiring_Date date not null
)

create table Instructor
(
	Id int primary key identity(1,1),
	Name varchar(max) not null,
	Bonus decimal(18,2) null,
	Salary decimal(18,2) not null,
	Hour_Rate decimal(10,2) not null,
	Address varchar(max) null
)

create table Student_Take_Course
(
	StdId int references Student(Id),
	CrsId int references Course(Id),
	primary key(StdId,CrsId),
	Grade int null-- From 0 to 100
)

create table Instructor_Teach_Course
(
	InstId int references Instructor(Id),
	CrsId int references Course(Id),
	primary key(InstId,CrsId),
	/*
	 * From 1 to 4...
	 *      1 : Means not good
	 *      2 : Means good
	 *      3 : Means very good
	 *      4 : Means Perfect
	 */
	Evaluation int null
)

alter table Student
add DptId int references Department(Id)

alter table Course
add TopicId int references Topic(Id)

alter table Department
add InstId int references Instructor(Id)

alter table Instructor
add DptId int references Department(Id)