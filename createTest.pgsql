drop schema if exists cccaTest cascade;

create schema cccaTest;

create table cccaTest.account (
	accountId uuid,
	name text,
	email text,
	document text,
	password text,
	primary key (accountId)
);