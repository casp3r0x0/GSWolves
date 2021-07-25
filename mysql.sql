create database accounts; 
use accounts; 
create table clients(
session_id varchar(255) primary key,   
username varchar(255) , 
password varchar(255)
);

create table status(
session_id varchar(255) primary key,   
client_level varchar(255) , 
client_status varchar(255) ,
last_video_viewed varchar(255)
);