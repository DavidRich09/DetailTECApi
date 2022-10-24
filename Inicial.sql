use DetailTEC;
--Trabajadores

INSERT INTO lavacar.Trabajador(cedula,nombre,apellidos,t_password,t_pago,rol,nacimiento,edad,ingreso)
VALUES(1,'Noname','nolastname','123','Semanal','Lavador','12-OCT-2002',20,'1-DEC-2022'),
	  (119567348,'David','Richmond','contradedavid','Pulidor','Bisemanal','9-FEB-2002',20,'6-FEB-2020'),
	  (310527362,'Bryan','Martinez','contradebryan','Lavador','Semanal','3-MAY-2002',20,'12-APRIL-2018'),
	  (629269549,'Juan','Solano','ricoqueso28','Lavador','Bisemanal','27-APRIL-1998',24,'4-JUNE-2017'),
	  (107667192,'Carlos','Jimenez','carlosmanda','Pulidor','Bisemanal','3-JULY-2004',18,'20-FEB-2021');

--Sucursales



--Clientes

INSERT INTO lavacar.cliente(cedula,nombre,usuario,c_password,correo,puntos,puntos_redimidos) 
VALUES (229691805,'Axel Rodriguez','Axel2424','axelrocks','axel@gmail.com',0,0),
       (156692872,'Carlos Jimenez','Car08','contradecarlos','carlos08@gmail.com',350,0),
	   (138280162,'Kenny Shroud','Car08','contradecarlos','carlos08@gmail.com',500,0);

--Direcciones de clientes



--Telefonos de clientes



--Citas



--Proovedores

INSERT INTO lavacar.proveedor(ced_juridica,nombre,contacto,correo,direccion) 
VALUES (1234567890,'Carlos',88997766,'carlosprov@gmail.com','Mozotal, San Jose'),
	   (1357924680,'Roberto',62569085,'robertoprov@gmail.com','Nether, Bosque Carmesi'),
	   (4216895237,'Marlon',81458269,'productosmarlon@gmail.com','Santa Cruz, Guanacaste'),
	   (5792361809,'Maria',88997766,'madremarianegocios@gmail.com','Lima, Cartago');

--Productos

INSERT INTO lavacar.producto(nombre,marca,costo) 
VALUES ('cera','acme',30000),
	   ('esponjas','acme',2500),
	   ('aspiradora','acme',60000),
	   ('jabon','blizzard',10000),
	   ('jabon','latex',20000),
	   ('jabon','Jabonatex',15000);

--Lavados

INSERT INTO lavacar.lavado(tipo_lavado,duracion,costo,precio,puntos_otorga,puntos_redimir) 
VALUES ('Lavado y Aspirado','30 min',25000,35000,50,500),
	   ('Lavado Encerado','40 min',35000,50000,100,1000),
	   ('Lavado Premium y Pulido','80 min',55000,90000,200,1500);

--Personal Lavados



--Relacion proveedor con producto.

INSERT INTO lavacar.proveedor_producto(nombre,marca,ced_proveedor) 
VALUES ('cera','acme',1234567890),
	   ('esponjas','acme',1234567890),
	   ('aspiradora','acme',1234567890),
	   ('jabon','blizzard',5792361809),
	   ('jabon','latex',4216895237),
	   ('jabon','Jabonatex',1357924680);

--Relacion lavados con productos.