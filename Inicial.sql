use DetailTEC;
--Trabajadores

INSERT INTO lavacar.Trabajador(cedula,nombre,apellidos,t_password,t_pago,rol,nacimiento,edad,ingreso)
VALUES(1,'Noname','nolastname','123','Semanal','Lavador','12-OCT-2002',20,'1-DEC-2022'),
	  (319567348,'David','Richmond','contradedavid','Pulidor','Bisemanal','9-FEB-2002',20,'6-FEB-2020'),
	  (310527362,'Bryan','Martinez','contradebryan','Lavador','Semanal','3-MAY-2002',20,'12-APRIL-2018'),
	  (629269549,'Juan','Solano','ricoqueso28','Lavador','Bisemanal','27-APRIL-1998',24,'4-JUNE-2017'),
	  (107667192,'Carlos','Jimenez','carlosmanda','Pulidor','Bisemanal','3-JULY-2004',18,'20-FEB-2021');

--Sucursales

INSERT INTO lavacar.sucursal(nombre,provincia,canton,distrito,telefono,inicio_gerente,apertura,ced_gerente)
VALUES ('Sucursal de Cartago','Cartago','Paraiso','Santa Lucia',89674356,'15-OCT-2017','4-JUNE-2017',629269549),
	   ('Sucursal de Alajuela','Alajuela','San Carlos','Monterrey',78923478,'15-AUG-2018','7-JULY-2018',319567348);

--Clientes

INSERT INTO lavacar.cliente(cedula,nombre,usuario,c_password,correo,puntos,puntos_redimidos) 
VALUES (229691805,'Axel Rodriguez','Axel2424','axelrocks','axel@gmail.com',0,0),
       (156692872,'Carlos Jimenez','Car08','contradecarlos','carlos08@gmail.com',350,0),
	   (138280162,'Kenny Shroud','kennyS','g2kenny','kennyS@gmail.com',500,0);

--Direcciones de clientes

INSERT INTO lavacar.dir_cliente(direccion,ced_cliente)
VALUES ('Purral',229691805),
	   ('Santa Cruz',229691805),
	   ('Escazu',156692872),
	   ('San Carlos',138280162);

--Telefonos de clientes

INSERT INTO lavacar.tel_cliente(telefono,ced_cliente)
VALUES (45231278,229691805),
	   (85432367,156692872),
	   (56902312,138280162);

--Citas



--Proovedores

INSERT INTO lavacar.proveedor(ced_juridica,nombre,contacto,correo,direccion) 
VALUES (123456789,'Carlos',88997766,'carlosprov@gmail.com','Mozotal, San Jose'),
	   (135792468,'Roberto',62569085,'robertoprov@gmail.com','Nether, Bosque Carmesi'),
	   (421689523,'Marlon',81458269,'productosmarlon@gmail.com','Santa Cruz, Guanacaste'),
	   (579236180,'Maria',88997766,'madremarianegocios@gmail.com','Lima, Cartago');

--Productos

INSERT INTO lavacar.producto(nombre,marca,costo,tipo_lavado) 
VALUES ('cera','acme',30000,'string'),
	   ('esponjas','acme',2500,'string'),
	   ('aspiradora','acme',60000,'string'),
	   ('jabon','blizzard',10000,'string'),
	   ('jabon','latex',20000,'string'),
	   ('jabon','Jabonatex',15000,'string');

--Lavados

INSERT INTO lavacar.lavado(tipo_lavado,duracion,costo,precio,puntos_otorga,puntos_redimir) 
VALUES ('Lavado y Aspirado','30 min',25000,35000,50,500),
	   ('Lavado Encerado','40 min',35000,50000,100,1000),
	   ('Lavado Premium y Pulido','80 min',55000,90000,200,1500);

--Personal Lavados

INSERT INTO lavacar.personal_lavado(tipo_lavado,rol,cantidad)
VALUES ('Lavado y Aspirado','Lavador',2),
	   ('Lavado Encerado','Lavador',2),
	   ('Lavado Encerado','Pulidor',1),
	   ('Lavado Premium y Pulido','Pulidor',1),
	   ('Lavado Premium y Pulido','Lavador',2);

--Relacion proveedor con producto.

INSERT INTO lavacar.proveedor_producto(nombre,marca,ced_proveedor) 
VALUES ('cera','acme',123456789),
	   ('esponjas','acme',123456789),
	   ('aspiradora','acme',123456789),
	   ('jabon','blizzard',579236180),
	   ('jabon','latex',421689523),
	   ('jabon','Jabonatex',135792468);

--Relacion lavados con productos.

INSERT INTO lavacar.lavado_producto(nombre,marca,tipo_lavado,cantidad)
VALUES ('cera','acme','Lavado Encerado',1),
	   ('esponjas','acme','Lavado y Aspirado',1),
	   ('esponjas','acme','Lavado Encerado',1),
	   ('esponjas','acme','Lavado Premium y Pulido',1),
	   ('jabon','blizzard','Lavado y Aspirado',1),
	   ('jabon','latex','Lavado Premium y Pulido',1),
	   ('jabon','Jabonatex','Lavado Encerado',1);