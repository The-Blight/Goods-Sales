INSERT INTO table_persons (first_name, patronymic, last_name, date_of_birth)
VALUES
    ('Иван', 'Иванович', 'Иванов', '1990-05-15'),
    ('Мария', 'Сергеевна', 'Петрова', '1985-11-22'),
    ('Алексей', NULL, 'Смирнов', '1995-02-10');



INSERT INTO table_products (name, description, price)
VALUES
    ('Ноутбук', 'Игровой ноутбук', 75000.00),
    ('Мышь', 'Беспроводная оптическая мышь', 1500.50),
    ('Клавиатура', 'Механическая клавиатура с подсветкой', 4200.00);



INSERT INTO table_warehouses (product_id, quantity_in_stock)
VALUES
    (1, 10),
    (2, 50),
    (3, 20);




INSERT INTO table_sales (person_id, sale_date)
VALUES
    (1, NOW()),
    (2, '2023-10-25 14:30:00');


INSERT INTO table_sales_item (sale_id, product_id, price_at_sale, quantity)
VALUES
    (1, 1, 75000.00, 1),
    (1, 2, 1500.50, 2),
    (2, 3, 4200.00, 1);

