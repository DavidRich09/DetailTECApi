use DetailTEC;

ALTER TABLE lavacar.sucursal
ADD CONSTRAINT FK_SucursalMan FOREIGN KEY (ced_gerente)
REFERENCES lavacar.Trabajador (cedula);

ALTER TABLE lavacar.dir_cliente
ADD CONSTRAINT FK_dirs_clientes FOREIGN KEY (ced_cliente)
REFERENCES lavacar.cliente (cedula);

ALTER TABLE lavacar.tel_cliente
ADD CONSTRAINT FK_tels_clientes FOREIGN KEY (ced_cliente)
REFERENCES lavacar.cliente (cedula);

ALTER TABLE lavacar.cita
ADD CONSTRAINT FK_tipolavadocita FOREIGN KEY (tipo_lavado)
REFERENCES lavacar.lavado (tipo_lavado);

ALTER TABLE lavacar.cita
ADD CONSTRAINT FK_SucursalCita FOREIGN KEY (sucursal)
REFERENCES lavacar.sucursal (nombre);

ALTER TABLE lavacar.cita
ADD CONSTRAINT FK_ResponsableCita FOREIGN KEY (ced_empleado)
REFERENCES lavacar.Trabajador (cedula);

ALTER TABLE lavacar.cita
ADD CONSTRAINT FK_ClienteCorr FOREIGN KEY (ced_cliente)
REFERENCES lavacar.cliente (cedula);

ALTER TABLE lavacar.cita
ADD CONSTRAINT PK_Citas PRIMARY KEY (placa_vehiculo,fecha);

ALTER TABLE lavacar.personal_lavado
ADD CONSTRAINT FK_RolLavado FOREIGN KEY (tipo_lavado)
REFERENCES lavacar.lavado (tipo_lavado);

ALTER TABLE lavacar.producto
ADD CONSTRAINT FK_CedProveedor FOREIGN KEY (ced_proveedor)
REFERENCES lavacar.proveedor (ced_juridica);

ALTER TABLE lavacar.producto
ADD CONSTRAINT FK_TipoLavadoProd FOREIGN KEY (tipo_lavado)
REFERENCES lavacar.lavado (tipo_lavado)

ALTER TABLE lavacar.producto
ADD CONSTRAINT PK_Productos PRIMARY KEY (nombre,marca,ced_proveedor);