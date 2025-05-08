create database students_db;
\c students_db


create table students (
    id SERIAL primary key,
    full_name VARCHAR(100),
    age INT,
    group_name VARCHAR(20)
);

insert into students (full_name, age, group_name)
values
    ('Іван Іванов', 19, 'ІП-21'),
    ('Марія Петренко', 20, 'ІП-22');

select * from students;