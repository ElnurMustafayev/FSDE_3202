insert into ProductTypes
values('mobile')

select * from ProductTypes

insert into Products([Name], [ProductTypeId])
values(default, 2)

select * from Products

select p.Name, pt.Name
from Products p
join ProductTypes pt on p.ProductTypeId = pt.Id