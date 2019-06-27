* Largely based on: https://devblogs.microsoft.com/odata/asp-net-core-odata-now-available/

* Official documentation: https://www.odata.org/getting-started/basic-tutorial/#queryData

* Accessing Metadata

	* http://localhost:51385/odata/v1/$metadata

* Simple Queries

	* GET http://localhost:51385/odata/v1/authors
	* GET http://localhost:51385/odata/v1/authors(2)

* Adding Author
	* POST http://localhost:51385/odata/v1/authors

```
Content-Type: application/json

{
	"id":5,
	"name": "franky",
	"bio": "some developer"
}
```

* Advanced Queries

	* Possible Filters: https://help.nintex.com/en-us/insight/OData/HE_CON_ODATAQueryCheatSheet.htm#Filter

	* GET http://localhost:51385/odata/v1/Authors?$expand=Posts,Socials&$filter=startswith(Name,'Mark')
	* GET http://localhost:51385/odata/v1/Authors?$orderby=Name%20asc
	* GET http://localhost:51385/odata/v1/authors?$expand=Posts($select=Title)&$select=Name
	* GET http://localhost:51385/odata/v1/authors(1)?$expand=Socials($select=NickName,Type)&$select=Name
