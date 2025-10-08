create database dbLogin;
use dbLogin;

create table tbCliente(
Email varchar(50) primary key,
Nome varchar(50) not null,
Senha varchar(50) not null
);