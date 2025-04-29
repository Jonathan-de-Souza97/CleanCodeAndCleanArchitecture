drop schema if exists cccaTest cascade;

create schema cccaTest;

create table cccaTest.account (
	account_id uuid,
	name text,
	email text,
	document text,
	password text,
	primary key (account_id)
);