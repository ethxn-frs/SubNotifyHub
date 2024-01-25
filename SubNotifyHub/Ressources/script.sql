CREATE TABLE subscription
(
    Id SERIAL PRIMARY KEY,
    Name VARCHAR(255) NOT NULL,
    Price DECIMAL(18,2) NOT NULL,
    Date TIMESTAMP NOT NULL,
    Requerence VARCHAR NOT NULL
);

INSERT INTO public.subscription (Name, Price, Date, Requerence) 
VALUES ('Apple Arcade', 6.99, NOW(), 'MONTHLY');
