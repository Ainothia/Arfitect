Developer Case Study

Problem Statement:
We would like to create an e-commerce merchandising management system for Arfitect.
Our main goal is to create a business flow for CRUD transactions in our "Product" domain.
We expect you to use ASP.Net Core. We prefer to have rest end points to support our business.

Definitions:
Product Entity means for us:
- Title
- Description
- Category (Child Entity)
- Stock Quantity

Our validation rules for the Product Entity are as follows;
- Title cannot be null or empty and have a maximum character limitation of 200.
- Product can only have one category.
- Product must have a category to be live.
- Product should have a minimum stock quantity in Category level and Products with stock quantity
under this limit cannot be live.

Our API should provide a filter product end point and it should enable us to filter the products based on
the following criteria:
1) Can provide a search keyword and it should be queried on Title, description and category name fields.
2) We should be query stock quantity range with min and max values.
