Largely based on https://devblogs.microsoft.com/odata/asp-net-core-odata-now-available/

Official documentation: https://www.odata.org/getting-started/basic-tutorial/#queryData

Queries:

- GET http://localhost:51385/odata/v1/authors

- GET http://localhost:51385/odata/v1/authors(2)

- POST http://localhost:51385/odata/v1/authors

Content-Type: application/json

{
  "Id":3,"ISBN":"82-917-7192-5","Title":"Hary Potter","Author":"J. K. Rowling",
  "Price":199.99,
  "Location":{
     "City":"Shanghai",
     "Street":"Zhongshan RD"
   }
}

- GET http://localhost:51385/odata/v1/authors?$expand=Posts($select=Title)&$select=Name

- GET http://localhost:51385/odata/v1/authors(1)?$expand=Socials($select=NickName,Type)&$select=Name
