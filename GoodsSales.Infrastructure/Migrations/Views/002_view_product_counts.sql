CREATE OR REPLACE VIEW view_product_counts AS
SELECT products.name,
       warehouse.quantity_in_stock
FROM table_warehouses as warehouse
         JOIN table_products as products ON warehouse.product_id = products.id