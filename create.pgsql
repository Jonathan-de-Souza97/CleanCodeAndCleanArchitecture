drop schema if exists ccca cascade;

create schema ccca;

create table ccca.account (
	accountId uuid,
	name text,
	email text,
	document text,
	password text,
	primary key (accountId)
);