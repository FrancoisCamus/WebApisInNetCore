* Based on
  * https://fullstackmark.com/post/17/building-a-graphql-api-with-aspnet-core-2-and-entity-framework-core
  * https://www.red-gate.com/simple-talk/dotnet/net-development/getting-started-with-graphql-in-asp-net/

* Simple Query

```
query GetAuthors {
  authors {
    id
    name
    bio
  }
}
```

* Query with parameters

```
query GetAuthor($id: Int!) {
  author(id: $id) {
    id
    name
    posts {
      title
      comments {
        commenter
      }
    }
    socials {
      nickName
    }
  }
}

{
    "id":1
}
```

* Query with directives

```
query GetAuthor($id: Int!, $withPosts: Boolean!) {
  author(id: $id) {
    id
    name 
    posts @include(if: $withPosts) {
      title
      comments {
        commenter
      }
    }
    socials {
      nickName
    }
  }
}

{
  "id": 1,
  "withPosts": true
}
```

* Mutation

```
mutation ($author: AuthorInput!) {
  createAuthor(author: $author) {
    id
    name
    bio
  }
}

{
  "author": {
    "id": 4,
    "name": "franky",
    "bio": "some developer"
  }
}
```

* Sample POST Request

```
Content-Type: application/json

{ "query":"query GetAuthors { authors { id name bio posts { date comments { commenter } } socials { type } } }", "variables":null, "operationName":"GetAuthors" }
```
