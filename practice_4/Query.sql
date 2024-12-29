--1
SELECT model, speed, hd FROM PC WHERE price<500
--2
SELECT DISTINCT maker FROM Product WHERE type ='printer' 
--3
SELECT model, ram, screen FROM laptop WHERE price>1000 
--4
SELECT * FROM Printer WHERE color ='y' 
--5
SELECT model, speed, hd FROM PC WHERE price<600 AND cd IN('12x', '24x') 
--6
SELECT DISTINCT maker, speed FROM Product p JOIN Laptop l ON (p.model=l.model) WHERE  hd>=10  
--7
SELECT PC.model, price FROM Product JOIN PC ON (product.model=PC.model) WHERE Product.maker ='B'
UNION 
SELECT Laptop.model, price FROM Product JOIN Laptop ON (product.model=Laptop.model) WHERE Product.maker ='B'
UNION 
SELECT Printer.model, price FROM Product JOIN Printer ON (product.model=Printer.model) WHERE Product.maker ='B'
--8
SELECT maker FROM product WHERE type ='PC' 
EXCEPT
SELECT maker FROM product WHERE type ='Laptop'
--9
SELECT DISTINCT maker FROM product WHERE model IN ( SELECT model FROM PC WHERE speed>=450)  
--10
SELECT Product.model, price FROM Product JOIN Printer ON (Product.model=Printer.model) 
WHERE Product.model IN ( SELECT Printer.model FROM Printer WHERE price>=ALL (SELECT price from Printer where price>0))
--11
SELECT AVG(speed) FROM PC 
--12
SELECT AVG(speed) FROM pc
--13
SELECT AVG(speed) FROM Product JOIN PC ON (Product.model = PC.model) WHERE maker ='A' 
--14
SELECT Ships.class, Ships.name, Classes.country
FROM ships LEFT OUTER JOIN classes ON Ships.class = Classes.class
WHERE Classes.numGuns >= 10 ;
--15
SELECT hd 
FROM PC
GROUP BY hd
HAVING COUNT(model) >= 2;
--16
SELECT DISTINCT p1.model, p2.model, p1.speed, p1.ram
FROM pc p1 INNER JOIN pc p2
ON p1.speed = p2.speed
and p1.ram = p2.ram
WHERE p1.model <> p2.model
and p1.model > p2.model
--17
SELECT DISTINCT 'Laptop' AS Type, model, speed 
FROM laptop
WHERE speed < (select min(speed) from pc)
--18
SELECT DISTINCT product.maker, printer.price 
FROM product 
INNER JOIN printer 
ON product.model = printer.model
WHERE printer.price = (select min(price) 
FROM printer where color = 'y')
AND printer.color = 'y'
--19
SELECT product.maker, avg(LAPTOP.screen) as [Average Screen Size]
FROM LAPTOP 
INNER JOIN PRODUCT on laptop.model = product.model
group by product.maker
--20
SELECT maker, count(distinct model) AS Count_Model
FROM product
WHERE type = 'PC' GROUP BY maker 
having count(distinct product.model) >= 3
