 --创建数据库MySchool
 use master
 go

 if exists(select * from sysdatabases where name='MySchool')
drop database MySchool

create database MySchool
on
(
 Name='MySchool_data',
 filename='D:\新建文件夹\MySchool.mdf',
 size=5MB,
 filegrowth=15%
)
log on
(
 Name='MySchool_log',
 filename='D:\新建文件夹\MySchool.ldf',
 size=5MB,
 filegrowth=15%
)

use MySchool
go


--创建表Grade
 if exists(select * from sysobjects where name='Grade')
drop table Grade

create table Grade
(
GradeId int identity(1,1) not null constraint PK_GradeId primary key(GradeId) ,
GradeName nvarchar(50) not null
)


--创建表Subject
 if exists(select * from sysobjects where name='Subject')
drop table [Subject]

create table [Subject]
(
SubjectNo int identity(1,1) not null constraint PK_SubjectNo primary key(SubjectNo) ,
SubjectName nvarchar(50) not null,
ClassHour int not null constraint CK_ClassHour check(ClassHour>=0),
GradeId int not null constraint FK_Grade_Subject_GradeId foreign key(GradeId) references Grade(GradeId)
)


--创建表Student
 if exists(select * from sysobjects where name='Student')
drop table Student

create table Student
(
StudentNo int identity(1,1) not null constraint PK_StudentNo primary key(StudentNo) ,
Pwd nvarchar(50) not null constraint CK_Pwd check(len(Pwd)>=6),
StudentName nvarchar(50) not null,
Sex nvarchar(50) not null constraint CK_Sex check(Sex='男' or Sex='女'),
GradeId int not null constraint FK_Grade_Student_GradeId foreign key(GradeId) references Grade(GradeId),
Phone nvarchar(50) ,                  	
BornDate  datetime  ,               
Address  nvarchar(255) constraint DF_Address default ('北京'),                   
Email nvarchar(50) , 		 
IdentityCard varchar(18) not null constraint UQ_IdentityCard unique(IdentityCard)      

)
--创建表Result
 if exists(select * from sysobjects where name='Result')
drop table Result

create table Result
(
StudentNo int not null constraint FK_Student_Result_StudentNo foreign key(StudentNo) references Student(StudentNo),
SubjectNo int not null constraint FK_Subject_Result_SubjectNo foreign key(SubjectNo) references [Subject](SubjectNo),
ExamData datetime not null constraint DF_ExamData default getdate(),
StudentResult int not null constraint CK_StudentResult check(StudentResult>=0 and StudentResult<=100)
)


--复合主键
alter table Result
  add constraint PK_StudentNo_SubjectNo_ExamData primary key(StudentNo,SubjectNo,ExamData)




--添加Graade表数据
insert into Grade(GradeName)
values ('S1')
insert into Grade(GradeName)
values ('S2')
insert into Grade(GradeName)
values ('Y2')

--添加Student表数据
insert into Student(Pwd,StudentName,Sex,GradeId,Phone,BornDate,Address,Email,IdentityCard )
values(123321,'张三','女',1,1234567890,1997-1-6,'合肥','123@qq.com',1111111111111111)
insert into Student(Pwd,StudentName,Sex,GradeId,Phone,BornDate,Address,Email,IdentityCard )
values(321123,'李四','男',2,13554556666,1994-5-20,default,'111@qq.com',22222222222222)
insert into Student(Pwd,StudentName,Sex,GradeId,Phone,BornDate,Address,Email,IdentityCard )
values(111111,'王五','男',2,18144556677,1995-11-3,'上海','222@qq.com',33333333333333333)
insert into Student(Pwd,StudentName,Sex,GradeId,Phone,BornDate,Address,Email,IdentityCard )
values(222222,'赵六','女',1,17444556677,2003-4-1,'合肥','333@qq.com',4444444444444444)
insert into Student(Pwd,StudentName,Sex,GradeId,Phone,BornDate,Address,Email,IdentityCard )
values(333333,'小明','女',3,15844556677,1998-5-6,default,'444@qq.com',5555555555555555)
insert into Student(Pwd,StudentName,Sex,GradeId,Phone,BornDate,Address,Email,IdentityCard )
values(444444,'大明','男',1,13444556677,1999-1-6,'南京','555@qq.com',666666666666666)
insert into Student(Pwd,StudentName,Sex,GradeId,Phone,BornDate,Address,Email,IdentityCard )
values(555555,'老王','女',2,13144589677,1993-7-6,'广东','134@qq.com',77777777777777)
insert into Student(Pwd,StudentName,Sex,GradeId,Phone,BornDate,Address,Email,IdentityCard )
values(666666,'老李','男',1,13144556677,1995-5-11,default,'666@qq.com',88888888888888)
insert into Student(Pwd,StudentName,Sex,GradeId,Phone,BornDate,Address,Email,IdentityCard )
values(777777,'老赵','男',3,15144523677,1993-4-10,'合肥','777@qq.com',99999999999999)
insert into Student(Pwd,StudentName,Sex,GradeId,Phone,BornDate,Address,Email,IdentityCard )
values(888888,'小刘','女',2,18544556997,1994-5-20,default,'888@qq.com',12345678900)
insert into Student(Pwd,StudentName,Sex,GradeId,Phone,BornDate,Address,Email,IdentityCard )
values(999999,'老魏','男',3,17244556397,1994-7-8,'上海','999@qq.com',12121212121212)
insert into Student(Pwd,StudentName,Sex,GradeId,Phone,BornDate,Address,Email,IdentityCard )
values(1234567,'小黑','男',3,13144556789,1993-5-20,'合肥','234@qq.com',123123412345)

--添加Subject表数据
 insert into Subject(SubjectName,ClassHour,GradeId)
values('C#',10,1)
insert into Subject(SubjectName,ClassHour,GradeId)
values('java',20,2)
insert into Subject(SubjectName,ClassHour,GradeId)
values('.net ',30,3)

--添加Result表数据
insert into Result(StudentNo,SubjectNo,ExamData,StudentResult)
values (1,1,GETDATE(),88)
insert into Result(StudentNo,SubjectNo,ExamData,StudentResult)
values (2,3,GETDATE(),66)
insert into Result(StudentNo,SubjectNo,ExamData,StudentResult)
values (3,1,GETDATE(),70)
insert into Result(StudentNo,SubjectNo,ExamData,StudentResult)
values (4,2,GETDATE(),60)
insert into Result(StudentNo,SubjectNo,ExamData,StudentResult)
values (5,3,GETDATE(),45)
insert into Result(StudentNo,SubjectNo,ExamData,StudentResult)
values (6,3,GETDATE(),38)
insert into Result(StudentNo,SubjectNo,ExamData,StudentResult)
values (7,2,GETDATE(),55)
insert into Result(StudentNo,SubjectNo,ExamData,StudentResult)
values (8,1,GETDATE(),22) 