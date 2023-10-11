CREATE TABLE AIRLINE(
	CODE INT PRIMARY KEY NOT NULL,
	NAME VARCHAR(255) NOT NULL UNIQUE,
	COUNTRY VARCHAR(255) NOT NULL
);

CREATE TABLE AGENCY(
	NAME VARCHAR (255) PRIMARY KEY NOT NULL,
	COUNTRY VARCHAR(255) NOT NULL,
	CITY VARCHAR(255) NOT NULL,
	PHONE VARCHAR(10)
);

CREATE TABLE AIRPORT(
	CODE INT PRIMARY KEY NOT NULL,
	NAME VARCHAR(255) NOT NULL UNIQUE,
	COUNTRY VARCHAR(255) NOT NULL,
	CITY VARCHAR(255) NOT NULL
);


CREATE TABLE AIRPLANE(
	CODE INT PRIMARY KEY NOT NULL,
	TYPE VARCHAR(47) NOT NULL,
	SEATS INT NOT NULL,
	YEAR INT NOT NULL
);

CREATE TABLE FLIGHT(
	FNUMBER INT PRIMARY KEY NOT NULL,
	�IRLINE_OPERATOR INT foreign key references AIRLINE(CODE),
	DEP_AIRPORT INT foreign key references AIRPORT(CODE),
	ARR_AIRPORT INT foreign key references AIRPORT(CODE),
	FLIGHT_TIME DATETIME NOT NULL,
	FLIGHT_DURATION TIME NOT NULL,
	AIRPLANE INT foreign key references AIRPLANE(CODE)
);



CREATE TABLE CUSTOMER(
	ID INT PRIMARY KEY NOT NULL,
	FNAME VARCHAR(255) NOT NULL,
	LNAME VARCHAR(255) NOT NULL,
	EMAIL VARCHAR(40) NOT NULL, 
	CHECK (EMAIL LIKE '%@%' AND EMAIL LIKE '%________%')
)

CREATE TABLE BOOKING(
	CODE INT PRIMARY KEY NOT NULL,
	AGENCY VARCHAR(255) foreign key references AGENCY(NAME),
	AIRLINE_CODE INT foreign key references AIRLINE(CODE),
	FLIGHT_NUMBER INT foreign key references FLIGHT(FNUMBER),
	CUSTEMER_ID INT foreign key references CUSTOMER(ID),
	BOOKING_DATE DATETIME NOT NULL,
	FLIGHT_DATE DATETIME NOT NULL,
	PRICE INT NOT NULL,
	STATUS VARCHAR(30) NOT NULL,
	CHECK (BOOKING_DATE < FLIGHT_DATE)
);

ALTER TABLE FLIGHT
ADD NUM_PASS INT;

ALTER TABLE AGENCY
ADD NUM_BOOK INT;

--CREATE TRIGGER 