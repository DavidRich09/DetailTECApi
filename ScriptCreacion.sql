CREATE SCHEMA lavacar;
go

CREATE TABLE lavacar.Trabajador(
	cedula INT IDENTITY (1,1) NOT NULL PRIMARY KEY,
	nombre VARCHAR(100),
	apellidos VARCHAR(100),
	t_password VARCHAR(100),
	t_pago VARCHAR(100),
	rol VARCHAR(50),
	nacimiento DATE,
	edad INT,
	ingreso DATE,
	UNIQUE (t_password)
);

CREATE TABLE lavacar.sucursal(
	nombre VARCHAR(100)  NOT NULL PRIMARY KEY,
	provincia VARCHAR(100),
	canton VARCHAR(100),
	distrito VARCHAR(100),
	telefono INT IDENTITY (1,1),
	inicio_gerente DATE,
	apertura DATE,
	ced_gerente INT,
);

CREATE TABLE lavacar.proveedor(
	ced_juridica INT IDENTITY (1,1) NOT NULL PRIMARY KEY,
	nombre VARCHAR(100),
	contacto INT,
	correo VARCHAR(100),
	direccion VARCHAR(225),
);

CREATE TABLE lavacar.cliente(
	cedula INT IDENTITY (1,1) NOT NULL PRIMARY KEY,
	nombre VARCHAR(100),
	usuario VARCHAR(100),
	c_password VARCHAR(100),
	correo VARCHAR(100),
	UNIQUE (c_password),
);

CREATE TABLE lavacar.dir_cliente(
	direccion VARCHAR(225) NOT NULL,
	ced_cliente INT IDENTITY (1,1),
);

CREATE TABLE lavacar.tel_cliente(
	telefono INT NOT NULL,
	ced_cliente INT IDENTITY (1,1),
);

CREATE TABLE lavacar.cita(
	placa_vehiculo VARCHAR(100) NOT NULL,
	fecha DATE NOT NULL,
	tipo_lavado VARCHAR(100),
	sucursal VARCHAR(100),
	ced_empleado INT,
	ced_cliente INT IDENTITY (1,1),
);

CREATE TABLE lavacar.lavado(
	tipo_lavado VARCHAR(100) NOT NULL PRIMARY KEY,
	duracion VARCHAR(100),
	costo INT,
	precio INT,
	puntos_otorga INT,
	puntos_redimir INT,
);

CREATE TABLE lavacar.personal_lavado(
	tipo_lavado VARCHAR(100) NOT NULL,
	rol VARCHAR(100) NOT NULL,
	cantidad INT NOT NULL,
);

CREATE TABLE lavacar.producto(
	nombre VARCHAR(100) NOT NULL,
	marca VARCHAR(100) NOT NULL,
	costo INT,
	ced_proveedor INT IDENTITY (1,1),
	tipo_lavado VARCHAR(100),
);


