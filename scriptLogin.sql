create database dbLogin;
use dbLogin;

create table tbCliente(
Id int primary key, 
Nome varchar(50) not null,
Senha varchar(50) not null,
Nasc date not null,
Sexo char(1) not null,
CPF bigint not null,
Telefone varchar(13) not null,
Email varchar(50) not null,
Situacao varchar (50) not null
);