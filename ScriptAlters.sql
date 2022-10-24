use DetailTEC;

--Foranea de sucursal
ALTER TABLE lavacar.sucursal
ADD CONSTRAINT FK_SucursalMan FOREIGN KEY (ced_gerente)
REFERENCES lavacar.Trabajador (cedula);

--Foranea de multivaluado direccion de clientes
ALTER TABLE lavacar.dir_cliente
ADD CONSTRAINT FK_dirs_clientes FOREIGN KEY (ced_cliente)
REFERENCES lavacar.cliente (cedula);

--PK de direcciones de clientes
ALTER TABLE lavacar.dir_cliente
ADD CONSTRAINT PK_dirsc PRIMARY KEY (direccion, ced_cliente)

--Foranea de multivaluado telefonos de clientes
ALTER TABLE lavacar.tel_cliente
ADD CONSTRAINT FK_tels_clientes FOREIGN KEY (ced_cliente)
REFERENCES lavacar.cliente (cedula);

--PK de Telefonos de clientes
ALTER TABLE lavacar.tel_cliente
ADD CONSTRAINT PK_telsc PRIMARY KEY (telefono, ced_cliente)

--FK de lavado para tabla citas
ALTER TABLE lavacar.cita
ADD CONSTRAINT FK_tipolavadocita FOREIGN KEY (tipo_lavado)
REFERENCES lavacar.lavado (tipo_lavado);

--FK de sucursal para tabla citas
ALTER TABLE lavacar.cita
ADD CONSTRAINT FK_SucursalCita FOREIGN KEY (sucursal)
REFERENCES lavacar.sucursal (nombre);

--FK de trabajador para tabla citas
ALTER TABLE lavacar.cita
ADD CONSTRAINT FK_ResponsableCita FOREIGN KEY (ced_empleado)
REFERENCES lavacar.Trabajador (cedula);

--FK de cliente para tabla citas
ALTER TABLE lavacar.cita
ADD CONSTRAINT FK_ClienteCorr FOREIGN KEY (ced_cliente)
REFERENCES lavacar.cliente (cedula);

--PK para tabla citas
ALTER TABLE lavacar.cita
ADD CONSTRAINT PK_Citas PRIMARY KEY (placa_vehiculo,fecha);

ALTER TABLE lavacar.personal_lavado
ADD CONSTRAINT FK_RolLavado FOREIGN KEY (tipo_lavado)
REFERENCES lavacar.lavado (tipo_lavado);

--FK de lavado para tabla de relacion del personal de un lavado
ALTER TABLE lavacar.personal_lavado
ADD CONSTRAINT PK_PersonalLavado PRIMARY KEY (tipo_lavado,rol);

--PK de producto
ALTER TABLE lavacar.producto
ADD CONSTRAINT PK_Productos PRIMARY KEY (nombre,marca);

--FK de proveedor con producto
ALTER TABLE lavacar.proveedor_producto
ADD CONSTRAINT FK_ProvProd FOREIGN KEY (ced_proveedor)
REFERENCES lavacar.proveedor (ced_juridica);

--PK de tabla de relacion proveedor con producto
ALTER TABLE lavacar.proveedor_producto
ADD CONSTRAINT PK_ProvProd PRIMARY KEY (nombre,marca,ced_proveedor);

--FK de tipo de lavado con tabla de relacion lavado con producto
ALTER TABLE lavacar.lavado_producto
ADD CONSTRAINT FK_ProdLav FOREIGN KEY (tipo_lavado)
REFERENCES lavacar.lavado (tipo_lavado);

--FK de tipo de producto con tabla de relacion lavado con producto
ALTER TABLE lavacar.lavado_producto
ADD CONSTRAINT FK_ProdLav2 FOREIGN KEY (nombre,marca)
REFERENCES lavacar.producto (nombre,marca);

--PK de tabla relacion lavado con producto
ALTER TABLE lavacar.lavado_producto
ADD CONSTRAINT PK_LavProd PRIMARY KEY (nombre,marca,tipo_lavado);