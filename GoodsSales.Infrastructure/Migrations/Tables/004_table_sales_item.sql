CREATE TABLE IF NOT EXISTS table_sales_item
(
    sale_id       INTEGER        NOT NULL,
    product_id    INTEGER        NOT NULL,
    price_at_sale NUMERIC(19, 4) NOT NULL CHECK ( price_at_sale > 0 ),
    quantity      INTEGER        NOT NULL CHECK ( quantity > 0 ),

    CONSTRAINT foreign_key_sale_id
        FOREIGN KEY (sale_id) REFERENCES table_sales (id) ON DELETE NO ACTION,

    CONSTRAINT foreign_key_product_id
        FOREIGN KEY (product_id) REFERENCES table_products (id) ON DELETE NO ACTION,

    CONSTRAINT primary_key_sales_item PRIMARY KEY (sale_id, product_id)
);