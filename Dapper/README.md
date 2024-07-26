# CRUD Operations with Dapper Framework

This repository demonstrates how to implement CRUD (Create, Read, Update, Delete) operations using the Dapper framework in an C# Console application.


## Features of Dapper


- Dapper is extremely fast compared to traditional ORMs.
- it maps query results to objects efficiently.
- Dapper is straightforward to use. With minimal setup, you can execute raw SQL queries and map the results to your POCO (Plain Old CLR Object) classes.
- You have full control over your SQL queries, which makes it ideal for scenarios where you need to execute custom or complex SQL.
- Dapper works seamlessly with any ADO.NET provider.
- As a micro ORM, Dapper adds minimal overhead to your application, focusing solely on data access without unnecessary abstractions.


## When to Use Dapper

- **Low-Level Control Over SQL Queries**: If you need precise control over your SQL queries and want to write raw SQL, Dapper is a perfect fit. It allows you to execute queries directly without any additional abstraction.
- **Optimized Performance**: For applications where performance is critical, Dapper's lightweight nature and efficient mapping make it a great choice. It minimizes the overhead associated with traditional ORMs.
- **Legacy Databases or Custom SQL**: When working with legacy databases or custom SQL queries that do not fit well with the conventions of full-fledged ORMs, Dapper provides the necessary flexibility and control.

