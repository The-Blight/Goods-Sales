DROP VIEW IF EXISTS view_total_sales_per_person;

CREATE OR REPLACE VIEW view_total_sales_per_person AS
SELECT sales_item.sale_id,
       person.first_name,
       person.patronymic,
       person.last_name,
       SUM(sales_item.price_at_sale * sales_item.quantity) as total_price,
       SUM(sales_item.quantity)                            as total_item

FROM table_sales_item as sales_item
         JOIN table_sales sales ON sales_item.sale_id = sales.id
         JOIN table_persons person ON person.id = sales.person_id
GROUP BY sales_item.sale_id, person.first_name, person.patronymic,  person.last_name


