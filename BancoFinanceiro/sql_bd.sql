create database banco_bradesco;
use banco_bradesco;


create table cliente(
	id int not null auto_increment primary key,
	nome varchar(100),
	cpf varchar(14)
);

create table conta(
    numero int not null primary key,
    saldo float default 00.00,
    senha int not null,
    id_cliente int not null,
    foreign key(id_cliente) references cliente(id)
);

create table extrato(
	id_transacao int not null auto_increment primary key,
    num_conta int not null,
    valor float,
    tipo varchar(30),
    foreign key(num_conta) references conta(numero)
);