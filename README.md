# C# 🔹 .NET 🔹 WPF 🔹 Async 🔹 DB
> ***C# Async Database Wrapper with Presentaion Framework (WPF) test UI***

## This is as simple as a DB wrapper can get for .NET
Exposes 3 basic functions

**The method inputs are same for all three**
- First parameter takes the SQL query as `string`
    - use `@param` to add parameterized values
- Second parameter takes list of values as `Dictionary<string,string>`
    - the key is the parameter name
    - the valueis the parameter value

### 1. Execute Query
Calls the `System.Data.SqlClient.SqlCommand.ExecuteReader` method  
Use this for SELECT queries that returns multiple columns and/or multiple rows  
Returns the entire result set as a `System.Data.DataTable`

### 2. Execute Scalar
Calls the `System.Data.SqlClient.SqlCommand.ExecuteScalar` method  
Use this for SELECT queries that returns a single column and a single row, or none  
Returns an `object` that must be casted to the desired data type

### 3. Execute Query
Calls the `System.Data.SqlClient.SqlCommand.ExecuteNonQuery` method  
Use this for UPDATE and DELETE queries that does not return a result set  
Returns the number of affected rows, -1 if error, 0 is no changes
