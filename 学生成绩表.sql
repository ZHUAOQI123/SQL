
-------制作学生成绩单1
select StudentName  姓名,(select GradeName from  Grade where GradeId=Subject.GradeId) 课程所属年级,
SubjectName 课程名称,ExamDate 考试时间,StudentResult 学生成绩 from Result
inner join Student on Result.StudentNo=Student.StudentNo
inner join Subject on  subject.SubjectNo=Result.SubjectNo
 
where ExamDate=(select max(ExamDate) from Result 
where  Result.StudentNo=Student.StudentNo and subject.SubjectNo=Result.SubjectNo 
)

go
----制作学生成绩单2

declare @AllStudentNo int , @GoStudentNo int     --应到人数，实到人数
set @AllStudentNo=(select count(StudentNo) from  Student)
set @GoStudentNo=(select count(StudentNo) from  Result )
  
print '应到人数为'+convert(varchar(20), @AllStudentNo)
print '实到人数为'+convert(varchar(20) ,@GoStudentNo)

select StudentName 学生姓名, Result.StudentNo 学生学号,StudentResult 成绩  from Student
inner join Result on Result.StudentNo=Student.StudentNo
inner join Subject on Subject.SubjectNo=Result.SubjectNo
where SubjectName='.net' and ExamDate=(select max(ExamDate) from Result 
where StudentNo=Student.StudentNo)
print '是否通过'


--alter table  Result 
--add ispass nvchar(10)
select  ispass =case
when Result.StudentResult>60 
then '是'
else  '否'
end
from  Result

declare  @avg int
set @avg= ( select avg(StudentResult) from Result)
while 1=1
begin
  if  (not  exists (select * from Result where @avg>StudentResult))
 BREAK
 else
 UPDATE Result set StudentResult=StudentResult+1
 where StudentResult<@avg and StudentResult<97
 end 

 print' 更新 ispass'
update  Result  set ispass=case  
when StudentResult>=60 then 1
else 0
end


print'最终成绩'
select StudentName ,Result.StudentNo,StudentResult,ispass from Result 
inner  join   Student on Student.StudentNo=Result.StudentNo

print'null 替换成缺考'
select StudentResult,case
when StudentResult  is null 
then '缺考'
end
from Student 
inner  join   Result  on Student.StudentNo=Result.StudentNo

print'通过人数'
select count(ispass) from Result where ispass =1  --通过的人数
select count(studentNo) from Student   -- 所有学生人数

print 'ispass 转换'
select ispass ,case
when ispass=1 then '是'
else '否'
end 
from Result 


-- PRINT'通过率' 
  select convert(nvarchar(10),sum(ispass)*100/count(StudentNo))+'%' from Result 
 