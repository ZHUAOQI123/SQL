
-------����ѧ���ɼ���1
select StudentName  ����,(select GradeName from  Grade where GradeId=Subject.GradeId) �γ������꼶,
SubjectName �γ�����,ExamDate ����ʱ��,StudentResult ѧ���ɼ� from Result
inner join Student on Result.StudentNo=Student.StudentNo
inner join Subject on  subject.SubjectNo=Result.SubjectNo
 
where ExamDate=(select max(ExamDate) from Result 
where  Result.StudentNo=Student.StudentNo and subject.SubjectNo=Result.SubjectNo 
)

go
----����ѧ���ɼ���2

declare @AllStudentNo int , @GoStudentNo int     --Ӧ��������ʵ������
set @AllStudentNo=(select count(StudentNo) from  Student)
set @GoStudentNo=(select count(StudentNo) from  Result )
  
print 'Ӧ������Ϊ'+convert(varchar(20), @AllStudentNo)
print 'ʵ������Ϊ'+convert(varchar(20) ,@GoStudentNo)

select StudentName ѧ������, Result.StudentNo ѧ��ѧ��,StudentResult �ɼ�  from Student
inner join Result on Result.StudentNo=Student.StudentNo
inner join Subject on Subject.SubjectNo=Result.SubjectNo
where SubjectName='.net' and ExamDate=(select max(ExamDate) from Result 
where StudentNo=Student.StudentNo)
print '�Ƿ�ͨ��'


--alter table  Result 
--add ispass nvchar(10)
select  ispass =case
when Result.StudentResult>60 
then '��'
else  '��'
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

 print' ���� ispass'
update  Result  set ispass=case  
when StudentResult>=60 then 1
else 0
end


print'���ճɼ�'
select StudentName ,Result.StudentNo,StudentResult,ispass from Result 
inner  join   Student on Student.StudentNo=Result.StudentNo

print'null �滻��ȱ��'
select StudentResult,case
when StudentResult  is null 
then 'ȱ��'
end
from Student 
inner  join   Result  on Student.StudentNo=Result.StudentNo

print'ͨ������'
select count(ispass) from Result where ispass =1  --ͨ��������
select count(studentNo) from Student   -- ����ѧ������

print 'ispass ת��'
select ispass ,case
when ispass=1 then '��'
else '��'
end 
from Result 


-- PRINT'ͨ����' 
  select convert(nvarchar(10),sum(ispass)*100/count(StudentNo))+'%' from Result 
 