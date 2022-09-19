create table despesas (
id int identity(1,1) PRIMARY KEY,
descricao varchar(200),
valor decimal(19,2),
habitante_id int,
CONSTRAINT fk_habitante_despesas FOREIGN KEY (habitante_id) REFERENCES habitante(id)
);

create table receitas (
id int identity(1,1) PRIMARY KEY,
descricao varchar(200),
valor decimal(19,2),
habitante_id int,
CONSTRAINT fk_habitante_receitas FOREIGN KEY (habitante_id) REFERENCES habitante(id)
);

create table habitante (
id int identity(1,1) PRIMARY KEY,
nome varchar(150),
sobrenome varchar(200),
data_nascimento date,
renda decimal,
cpf varchar(11)
);

alter table despesas alter column descricao varchar(200) not null;
alter table despesas alter column valor decimal(19,2) not null;

alter table receitas alter column descricao varchar(200) not null;
alter table receitas alter column valor decimal(19,2) not null;

alter table habitante alter column nome varchar(150) not null;
alter table habitante alter column sobrenome varchar(200) not null;
alter table habitante alter column renda decimal(19,2) not null;
alter table habitante alter column cpf varchar(11) not null;