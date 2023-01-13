CREATE DATABASE Xsis

CREATE TABLE Movie
(
id int Identity(1,1),
title varchar(200),
description varchar(500),
rating float,
image varchar(300),
created_at datetime,
updated_at datetime,
CONSTRAINT PK_Movie PRIMARY KEY (id)
);