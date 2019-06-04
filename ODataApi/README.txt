Largely based on https://devblogs.microsoft.com/odata/asp-net-core-odata-now-available/

Official documentation: https://www.odata.org/getting-started/basic-tutorial/#queryData

Queries:

- GET https://localhost:44344/odata/Books

- GET https://localhost:44344/odata/Books(2)

- POST https://localhost:44344/odata/Books

Content-Type: application/json

{
  "Id":3,"ISBN":"82-917-7192-5","Title":"Hary Potter","Author":"J. K. Rowling",
  "Price":199.99,
  "Location":{
     "City":"Shanghai",
     "Street":"Zhongshan RD"
   }
}

- GET https://localhost:44344/odata/Books?$filter=Price le 50

- GET https://localhost:44344/odata/Books?$filter=Price le 50&$expand=Press($select=Name)&$select=ISBN

- GET https://localhost:44344/odata/Books?$orderby=Id%20desc
