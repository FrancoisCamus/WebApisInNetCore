Largely based on https://devblogs.microsoft.com/odata/asp-net-core-odata-now-available/

Official documentation: https://www.odata.org/getting-started/basic-tutorial/#queryData

Metadata:

- http://localhost:51385/odata/v1/$metadata

Queries:

- GET http://localhost:51385/odata/v1/authors

- GET http://localhost:51385/odata/v1/authors(2)

- POST http://localhost:51385/odata/v1/authors

- Filter queries:
-- https://help.nintex.com/en-us/insight/OData/HE_CON_ODATAQueryCheatSheet.htm#Filter
-- http://localhost:51385/odata/v1/Authors?$expand=Posts,Socials&$filter=startswith(Name,'fr')

Content-Type: application/json

{
	"id":5,
	"name": "franky",
	"bio": "some developer"
}

- GET http://localhost:51385/odata/v1/authors?$expand=Posts($select=Title)&$select=Name

- GET http://localhost:51385/odata/v1/authors(1)?$expand=Socials($select=NickName,Type)&$select=Name
